﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GetFileSc.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Config.ini")]
        public string ConfigName {
            get {
                return ((string)(this["ConfigName"]));
            }
            set {
                this["ConfigName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=vmdwh02)(PORT=1521))(CONNEC" +
            "T_DATA=(SERVER=dedicated)(SID=STAB)));User ID=sync;Password=sync")]
        public string OraTNS {
            get {
                return ((string)(this["OraTNS"]));
            }
            set {
                this["OraTNS"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ПРЕРЕКВИЗИТЫ")]
        public string RNItemLastWords1 {
            get {
                return ((string)(this["RNItemLastWords1"]));
            }
            set {
                this["RNItemLastWords1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ВО ВРЕМЯ УСТАНОВКИ")]
        public string RNItemLastWords2 {
            get {
                return ((string)(this["RNItemLastWords2"]));
            }
            set {
                this["RNItemLastWords2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ПОСЛЕ ИНКРЕМЕНТА")]
        public string RNItemLastWords3 {
            get {
                return ((string)(this["RNItemLastWords3"]));
            }
            set {
                this["RNItemLastWords3"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ЦИКЛИЧЕСКАЯ ЗАГРУЗКА)")]
        public string RNItemLastWords4 {
            get {
                return ((string)(this["RNItemLastWords4"]));
            }
            set {
                this["RNItemLastWords4"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("К ПРИМЕРУ, ДЛЯ СРЕДЫ ФТ)")]
        public string RNItemLastWords5 {
            get {
                return ((string)(this["RNItemLastWords5"]));
            }
            set {
                this["RNItemLastWords5"] = value;
            }
        }
    }
}