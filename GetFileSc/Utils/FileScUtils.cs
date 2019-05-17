using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace GetFileSc
{
    class FileScUtils
    {
        public static string[] GetTextsFromPatches(string[] subfolders, out string scfilesNotExistsMessage)
        {
            scfilesNotExistsMessage = "";
            int count = subfolders.Length;
            string[] texts = new string[count];
            for (int i = 0; i < count; ++i)
            {
                if (File.Exists(subfolders[i] + "\\file_sc.txt"))
                {
                    texts[i] = (new StreamReader(subfolders[i] + "\\file_sc.txt")).ReadToEnd();
                }
                else
                {
                    scfilesNotExistsMessage += subfolders[i] + Environment.NewLine;
                }
            }
            return texts;
        }

        //компаратор нужен для того, чтобы в сортированный список можно было добавлять пары с одинаковыми ключами
        public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);

                if (result == 0)
                    return 1;   // обрабатываем равенство как "больше"
                else
                    return result;
            }
        }

        //метод для отсечения файлов, не используемых в сценарии
        private static bool IsValidFileName(string relFileName)
        {
            return relFileName != "RELEASE_NOTES.DOCX" &&
                        relFileName != "RELEASE_NOTES.DOC" &&
                        relFileName != "FILE_SC.TXT" &&
                        relFileName != "VSSVER2.SCC" &&
                        relFileName.IndexOf(".XLS") == -1;
        }

        //главное, чтобы каждый элемент содержал конец полной строки пункта
        public static string[] RNItemLastWords = new string[]
        {
            Properties.Settings.Default.RNItemLastWords1,
            Properties.Settings.Default.RNItemLastWords2,
            Properties.Settings.Default.RNItemLastWords3,
            Properties.Settings.Default.RNItemLastWords4,
            Properties.Settings.Default.RNItemLastWords5
        };

        private static void AddReport(ref bool reported, ref string report, string rnPath, string item, string line)
        {
            //если еще не сообщали про этот патч
            if (!reported)
            {
                report += "Файл: " + Environment.NewLine +
                          rnPath + ";" + Environment.NewLine +
                          "Пункт: " + Environment.NewLine +
                          item + ";" + Environment.NewLine +
                          "Значение: " + Environment.NewLine;
                reported = true;
            }
            report += line + Environment.NewLine;
        }

        public static string RNReport(string [] subfolders)
        {
            List<string> rnList = new List<string>();
            foreach(string subfolder in subfolders)
            {
                if(File.Exists(subfolder + "\\release_notes.doc"))
                {
                    rnList.Add(subfolder + "\\release_notes.doc");
                }
                else if(File.Exists(subfolder + "\\release_notes.docx"))
                {
                    rnList.Add(subfolder + "\\release_notes.docx");
                }
                else
                {
                    MessageBox.Show("В папке " + subfolder + " не найден RN", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

            string report = "";

            object missing = System.Type.Missing;
            foreach (string rnPath in rnList)
            {
                Document doc = wordApp.Documents.Open(rnPath, missing, true);
                //разделяем строки
                string[] lines = doc.Content.Text.Split('\r', '\v');
                //текущий искомый пункт рн
                int rnItem = 0;
                for(int i = 0; i < lines.Length && rnItem < RNItemLastWords.Length; ++i)
                {
                    //позиция в строке, когда начинается заголовок пункта
                    int itemIndex = lines[i].ToUpper().IndexOf(RNItemLastWords[rnItem]);
                    //если нашел строку - название пункта рн
                    if (itemIndex != -1 && i + 1 < lines.Length)
                    {
                        //позиция в строке, когда кончается заголовок пункта
                        int indexItemEnd = itemIndex + RNItemLastWords[rnItem].Length;
                        bool reported = false;
                        //если в строке пункта осталось что-то лишнее
                        if (indexItemEnd != lines[i].Length)
                        {
                            AddReport(ref reported, ref report, rnPath, lines[i].Substring(0, indexItemEnd), lines[i].Substring(indexItemEnd));
                        }
                        //идем по всем строчкам этого пункта
                        for(int k = i + 1; //со следующей строки
                            k < lines.Length &&  //и остались строки 
                            (!(rnItem + 1 < RNItemLastWords.Length) || //и или не осталось пунктов 
                            lines[k].ToUpper().IndexOf(RNItemLastWords[rnItem + 1]) == -1);  //или, если остались, это не такой пункт
                            ++k)
                        {
                            string itemLine = lines[k].Trim();
                            //если оказалось что-то непустое
                            if (!string.IsNullOrWhiteSpace(itemLine) && itemLine != "-")
                            {
                                AddReport(ref reported, ref report, rnPath, lines[i], lines[k]);
                            }
                        }
                        //если сообщили, то отделяем подчеркиванием
                        if (reported)
                        {
                            report += "____________________________" + Environment.NewLine;
                        }
                        rnItem++;
                    }
                }
                doc.Close();

            }
            wordApp.Quit();
            return report;
        }

        public static void GetFileScFromFiles(string folder, string[] subfolders, out string[] texts)
        {
            DialogResultExt dialogResult = DialogResultExt.Yes;
            bool isUsrTs = false;
            Forms.AddUsrTsForm addUsrTsForm;
            texts = new string[subfolders.Length];

            for (int i = 0; i < subfolders.Length; ++i)
            {
                //сортированный список строк патча. ключи - приоритеты, значения - строки
                SortedList<int, string> lines = new SortedList<int, string>(new DuplicateKeyComparer<int>());
                foreach (string filename in Directory.EnumerateFiles(subfolders[i], "*.*", SearchOption.AllDirectories))
                {
                    string filenameUPPER = filename.ToUpper();
                    string relFileName = new FileInfo(filenameUPPER).Name;
                    if (IsValidFileName(relFileName))
                    {
                        string prefix;
                        int priority = Priority(filename, out prefix);
                        string schema = "";
                        if (prefix == "ORA")
                        {
                            if (dialogResult != DialogResultExt.YesAll) //если решили добавлять все, то добавляем 
                            {
                                if (filename.ToUpper().IndexOf("\\USER\\") != -1 || filename.ToUpper().IndexOf("\\TABLESPACE\\") != -1)
                                {
                                    isUsrTs = true;
                                    if (dialogResult != DialogResultExt.NoAll) //если решили не добавлять все, то не спрашиваем снова
                                    {
                                        addUsrTsForm = new Forms.AddUsrTsForm(filename);
                                        addUsrTsForm.ShowDialog();
                                        dialogResult = addUsrTsForm.dialogResult;
                                    }
                                }
                                else
                                {
                                    isUsrTs = false;
                                }
                            }

                            if (!isUsrTs || dialogResult == DialogResultExt.Yes || dialogResult == DialogResultExt.YesAll) //если это не добавление пользователя или тс, или если мы решили все равно добавлять
                            {
                                int startIndex = filename.ToUpper().IndexOf("DB_SCRIPTS") + "DB_SCRIPTS".Length + 1;
                                int endIndex = filename.IndexOf("@");
                                schema = "||" + filename.Substring(startIndex, endIndex - startIndex);
                                lines.Add(priority, prefix + "||" + filename.Substring(folder.Length + 1) + schema);
                            }
                            isUsrTs = false;
                        }
                        else
                        {
                            lines.Add(priority, prefix + "||" + filename.Substring(folder.Length + 1));
                        }
                    }
                }
                texts[i] = string.Join(Environment.NewLine, lines.Values);
            }
        }

        //сохраняется в texts
        public static void GetFileScFromScs(string folder, string[] subfolders, string[] texts,
                                              out string dbxmlFilesNotExistsMessage,
                                              out string linesNotExistsMessage,
                                              ref bool quit)
        {
            DialogResultExt dialogResult = DialogResultExt.Yes;
            Forms.AddUsrTsForm addUsrTsForm;
            dbxmlFilesNotExistsMessage = ""; //не найденные файлы, указанные в сценарии
            linesNotExistsMessage = ""; //не указанные в сценарии, но существующие в папках патчей

            for (int i = 0; i < subfolders.Length; ++i)
            {
                if (texts[i] != null)
                {
                    string[] lines = texts[i].Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> newLines = new List<string>();
                    string relSubfolderName = new DirectoryInfo(subfolders[i]).Name;

                    //первые 2 строчки не исполняемые
                    for (int j = 2; j < lines.Length; ++j)
                    {
                        int startPath = lines[j].IndexOf("||") + 2; //находим, где кончается первые ||
                        lines[j] = lines[j].Insert(startPath, relSubfolderName + "\\"); //вставляем туда название подпапки
                        string prefix = lines[j].Substring(0, startPath - 2); //ORA, IPC или STWF
                        int endPath = lines[j].IndexOf("||", startPath); //находим вторые ||
                        endPath = endPath == -1 ? lines[j].Length : endPath; //если их нет, берем до конца
                        string relPath = lines[j].Substring(startPath, endPath - startPath); //получаем путь до файла
                        string fullPath = folder + "\\" + relPath; //получаем полный путь
                        bool isUsrTs = false;

                        if (prefix == "ORA" && dialogResult != DialogResultExt.YesAll) //если решили добавлять все, то добавляем 
                        {
                            if (lines[j].ToUpper().IndexOf("\\USER\\") != -1 || lines[j].ToUpper().IndexOf("\\TABLESPACE\\") != -1) //пользователи и табличные пространства обычно добавляются вручную
                            {
                                isUsrTs = true;
                                if (dialogResult != DialogResultExt.NoAll) //если решили не добавлять все, то не спрашиваем снова
                                {
                                    addUsrTsForm = new Forms.AddUsrTsForm(fullPath);
                                    addUsrTsForm.ShowDialog();
                                    dialogResult = addUsrTsForm.dialogResult;
                                }
                            }
                            else
                            {
                                isUsrTs = false;
                            }
                        }

                        if (!isUsrTs || dialogResult == DialogResultExt.Yes || dialogResult == DialogResultExt.YesAll) //если это не добавление пользователя или тс, или если мы решили все равно добавлять
                        {
                            if (IsValidFileName(new FileInfo(relPath).Name.ToUpper())) //если это накатываемый файл
                            {
                                newLines.Add(lines[j]);
                            }

                            if (!File.Exists(fullPath))
                            {
                                dbxmlFilesNotExistsMessage += relPath + Environment.NewLine;
                            }
                        }
                        isUsrTs = false; //для следующей строки предполагаем, что все в порядке
                    }
                    texts[i] = String.Join(Environment.NewLine, newLines); //объединяем полученные строчки

                    //проверка, что все файлы в папках присутствуют в файле сценария
                    foreach (string filename in Directory.EnumerateFiles(folder + "\\" + relSubfolderName, "*.*", SearchOption.AllDirectories))
                    {
                        string filenameUPPER = filename.ToUpper();
                        string relFileName = new FileInfo(filenameUPPER).Name;
                        //отсечение rn, файлов сценария и файлов vss
                        if (IsValidFileName(relFileName))
                        {
                            bool found = false;
                            for (int j = 2; j < lines.Length && !found; ++j)
                            {
                                //получаем название файлов из строк
                                int startPath = lines[j].IndexOf("||") + 2;
                                int endPath = lines[j].IndexOf("||", startPath);
                                endPath = endPath == -1 ? lines[j].Length : endPath;

                                string fileFromSc = (folder + "\\" + lines[j].Substring(startPath, endPath - startPath)).ToUpper();
                                //сверяем с файлом в папке
                                found = filenameUPPER == fileFromSc;
                            }
                            if (!found) //если не нашли нужного, добавляем строку к ошибке
                            {
                                linesNotExistsMessage += filename.Substring(folder.Length + 1) + Environment.NewLine;
                            }
                        }
                    }
                }
            }

            //все dbatools ставим после всех dwh
            for (int k = 0; k < texts.Length; ++k)
            {
                List<string> lines = texts[k].Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                List<string> dbatoolsLines = new List<string>();
                bool dwhSchemaFound = false;

                for (int i = 0; i < lines.Count; ++i)
                {
                    Match matchSchema = Regex.Match(lines[i], @"ORA.*\|\|([^\|]*)$");
                    if (matchSchema.Success)
                    {
                        string schema1 = matchSchema.Groups[1].Value;
                        //находим строчку DWH
                        if (schema1.Equals("DWH", StringComparison.CurrentCultureIgnoreCase))
                        {
                            dwhSchemaFound = true;
                            break;
                        }
                    }
                }

                if (dwhSchemaFound)
                {
                    for (int i = lines.Count - 1; i >= 0; --i)
                    {
                        Match matchSchema = Regex.Match(lines[i], @"ORA.*\|\|([^\|]*)$");
                        if (matchSchema.Success)
                        {
                            string schema1 = matchSchema.Groups[1].Value;
                            //находим строчку DBATOOLS
                            if (schema1.Equals("DBATOOLS", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //вставляем в начало, тк идем с конца
                                dbatoolsLines.Insert(0, lines[i]);
                                lines.RemoveAt(i);
                            }
                        }
                    }

                    int dwhSchemaIndex = 0;
                    for (int i = lines.Count - 1; i >= 0; --i)
                    {
                        Match matchSchema = Regex.Match(lines[i], @"ORA.*\|\|([^\|]*)$");
                        if (matchSchema.Success)
                        {
                            string schema1 = matchSchema.Groups[1].Value;
                            //находим строчку DWH
                            if (schema1.Equals("DWH", StringComparison.CurrentCultureIgnoreCase))
                            {
                                dwhSchemaIndex = i;
                                break;
                            }
                        }
                    }

                    lines.InsertRange(dwhSchemaIndex + 1, dbatoolsLines);
                }

                texts[k] = string.Join(Environment.NewLine, lines);
            }

            if (dbxmlFilesNotExistsMessage != "" || linesNotExistsMessage != "")
            {
                using (ShowWarningsForm swf = new ShowWarningsForm(dbxmlFilesNotExistsMessage, linesNotExistsMessage))
                {
                    swf.ShowDialog();
                    quit = swf.dialogResult != DialogResult.Yes;
                }
            }
        }

        public static void CheckFP(string folder)
        {
            string dbxmlFilesNotExistsMessage = ""; //не найденные файлы, указанные в сценарии
            string linesNotExistsMessage = ""; //не указанные в сценарии, но существующие в папках патчей
            string scfilesNotExistsMessage;
            string fileScText = GetTextsFromPatches(new string[] { folder }, out scfilesNotExistsMessage)[0];

            bool quit = false;

            if(!string.IsNullOrWhiteSpace(scfilesNotExistsMessage))
            {
                quit = MessageBox.Show("Отсутствуют файлы сценария в папках:" + Environment.NewLine + scfilesNotExistsMessage + Environment.NewLine + "Продолжить?",
                    "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes ? false : true;
            }

            if (!quit)
            {
                string[] lines = fileScText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                //проверка, что все файлы в папках присутствуют в файле сценария
                foreach (string filename in Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories))
                {
                    string filenameUPPER = filename.ToUpper();
                    string relFileName = new FileInfo(filenameUPPER).Name;
                    //отсечение rn, файлов сценария и файлов vss
                    if (IsValidFileName(relFileName))
                    {
                        bool found = false;
                        for (int j = 2; j < lines.Length && !found; ++j)
                        {
                            //получаем название файлов из строк
                            int startPath = lines[j].IndexOf("||") + 2;
                            int endPath = lines[j].IndexOf("||", startPath);
                            endPath = endPath == -1 ? lines[j].Length : endPath;

                            string fileFromSc = (folder + "\\" + lines[j].Substring(startPath, endPath - startPath)).ToUpper();
                            //сверяем с файлом в папке
                            found = filenameUPPER == fileFromSc;
                        }
                        if (!found) //если не нашли нужного, добавляем строку к ошибке
                        {
                            linesNotExistsMessage += filename.Substring(folder.Length + 1) + Environment.NewLine;
                        }
                    }
                }

                //проверка, что для всех строк из сценария есть файл
                for (int j = 2; j < lines.Length; ++j)
                {
                    //получаем название файлов из строк
                    int startPath = lines[j].IndexOf("||") + 2;
                    int endPath = lines[j].IndexOf("||", startPath);
                    endPath = endPath == -1 ? lines[j].Length : endPath;
                        
                    string fileFromSc = (folder + "\\" + lines[j].Substring(startPath, endPath - startPath)).ToUpper();
                    if (!File.Exists(fileFromSc))
                    {
                        dbxmlFilesNotExistsMessage += lines[j] + Environment.NewLine;
                    }
                }

                if (dbxmlFilesNotExistsMessage != "" || linesNotExistsMessage != "")
                {
                    using (ShowWarningsForm swf = new ShowWarningsForm(dbxmlFilesNotExistsMessage, linesNotExistsMessage))
                    {
                        swf.ShowDialog();
                        quit = swf.dialogResult != DialogResult.Yes;
                    }
                }
                else
                {
                    MessageBox.Show("Файл сценария и внутренние файлы соответствуют", "Проверка пройдена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        public static void SaveFileSc(string folder, IEnumerable<string> texts)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            sfd.Filter = "Текстовый файл|*.txt";
            sfd.FileName = "file_sc";
            sfd.InitialDirectory = folder;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Delete(sfd.FileName);
                using (File.Create(sfd.FileName)) { }
                using (StreamWriter tw = new StreamWriter(sfd.FileName, false, Encoding.GetEncoding("Windows-1251")))
                {
                    tw.WriteLine(new DirectoryInfo(folder).Name);
                    tw.WriteLine(new DirectoryInfo(folder).Name);
                    foreach (var text in texts)
                    {
                        if (text != null)
                            tw.WriteLine(text);
                    }
                }
                MessageBox.Show("Файл сценария создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static int Priority(string line, out string prefix)
        {
            string upperLine = line.ToUpper();
            int priority = 0;
            prefix = "";

            //скрипты
            if (upperLine.IndexOf("\\DB_SCRIPT") != -1)
            {
                prefix = "ORA";
                priority += 1000;

                //порядок в скриптах
                if (upperLine.IndexOf("\\SEQUENCE") != -1) priority += 5;
                else if (upperLine.IndexOf("\\TABLE") != -1) priority += 10;
                else if (upperLine.IndexOf("\\INDEX") != -1) priority += 15;
                else if (upperLine.IndexOf("\\VIEW") != -1) priority += 20;
                else if (upperLine.IndexOf("\\FUNCTION") != -1) priority += 25;
                else if (upperLine.IndexOf("\\PROCEDURE") != -1) priority += 30;
                else if (upperLine.IndexOf("\\PACKAGE") != -1) priority += 35;
                else if (upperLine.IndexOf("\\SCRIPT") != -1) priority += 40;
            }

            //информатика
            else if (upperLine.IndexOf("\\INFA_XML") != -1)
            {
                prefix = "IPC";
                priority += 2000;

                //сначала shared
                if (upperLine.IndexOf("\\SHARED") != -1) priority += 100;
                else priority += 200;

                //порядок в информатике 
                if (upperLine.IndexOf("\\SOURCE") != -1) priority += 5;
                else if (upperLine.IndexOf("\\TARGET") != -1) priority += 10;
                else if (upperLine.IndexOf("\\USER-DEFINED FUNCTION") != -1)
                    priority += 15;
                else if (upperLine.IndexOf("\\EXP_") != -1) priority += 20;
                else if (upperLine.IndexOf("\\SEQ_") != -1) priority += 25;
                else if (upperLine.IndexOf("\\LKP_") != -1) priority += 30;
                else if (upperLine.IndexOf("\\MPL_") != -1) priority += 35;
                else if (upperLine.IndexOf("\\M_") != -1) priority += 40;
                else if (upperLine.IndexOf("\\CMD_") != -1) priority += 45;
                else if (upperLine.IndexOf("\\S_") != -1) priority += 50;
                else if (upperLine.IndexOf("\\WKLT_") != -1) priority += 55;
                else if (upperLine.IndexOf("\\WF_") != -1) priority += 60;
            }

            //старты потоков
            else if (upperLine.IndexOf("\\START_WF") != -1)
            {
                prefix = "STWF";
                priority += 3000;
            }

            return priority;
        }

        public static int GetPatchOrderNumber(string nameWithOrderNum)
        {
            return Convert.ToInt32(nameWithOrderNum.Substring(0, nameWithOrderNum.IndexOf('-')));
        }
    }
}