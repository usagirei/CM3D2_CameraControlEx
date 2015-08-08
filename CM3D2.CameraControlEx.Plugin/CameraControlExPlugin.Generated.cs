// ------------------------------------
// Auto-Generated with T4 Templating on Microsoft Visual Studio 14.0
// Template File: CameraControlExPlugin.Generated.tt
// ------------------------------------
// Install T4 Toolbox if having troubles
// ------------------------------------

using System;
using System.Globalization;
using System.Runtime.CompilerServices;

using UnityEngine;

namespace CM3D2.CameraControlEx.Plugin
{
    partial class CameraControlExPlugin
    {
        #region Initialization

        [CompilerGenerated]
        private void InitConfig() {
            bool changed = false;
            changed |= InitConfig("Config", "EyeToCam", KeyCode.KeypadPeriod);
            changed |= InitConfig("Config", "FOVReset", KeyCode.KeypadMultiply);
            changed |= InitConfig("Config", "Modifier", KeyCode.LeftAlt);
            changed |= InitConfig("Config", "MoveBackward", KeyCode.Keypad2);
            changed |= InitConfig("Config", "MoveDown", KeyCode.Keypad1);
            changed |= InitConfig("Config", "MoveForward", KeyCode.Keypad8);
            changed |= InitConfig("Config", "MoveLeft", KeyCode.Keypad4);
            changed |= InitConfig("Config", "MoveRight", KeyCode.Keypad6);
            changed |= InitConfig("Config", "MoveUp", KeyCode.Keypad3);
            changed |= InitConfig("Config", "Reset", KeyCode.Keypad5);
            changed |= InitConfig("Config", "Screenshot", KeyCode.Keypad0);
            changed |= InitConfig("Config", "ToggleFine", KeyCode.KeypadDivide);
            changed |= InitConfig("Config", "ZoomIn", KeyCode.KeypadPlus);
            changed |= InitConfig("Config", "ZoomOut", KeyCode.KeypadMinus);
            changed |= InitConfig("Config", "FOV", -1f);
            changed |= InitConfig("Config", "FOVChange", 0.25f);
            changed |= InitConfig("Config", "MoveRate", 0.05f);
            changed |= InitConfig("Config", "SpinRate", 1f);
            if(changed)
            	SaveConfig();
        }
        
        #endregion
        
        #region Properties
        
        [CompilerGenerated]
        public KeyCode EyeToCam => ParseEnum(Preferences["Config"]["EyeToCam"].Value, KeyCode.KeypadPeriod);
        
        [CompilerGenerated]
        public KeyCode FOVReset => ParseEnum(Preferences["Config"]["FOVReset"].Value, KeyCode.KeypadMultiply);
        
        [CompilerGenerated]
        public KeyCode Modifier => ParseEnum(Preferences["Config"]["Modifier"].Value, KeyCode.LeftAlt);
        
        [CompilerGenerated]
        public KeyCode MoveBackward => ParseEnum(Preferences["Config"]["MoveBackward"].Value, KeyCode.Keypad2);
        
        [CompilerGenerated]
        public KeyCode MoveDown => ParseEnum(Preferences["Config"]["MoveDown"].Value, KeyCode.Keypad1);
        
        [CompilerGenerated]
        public KeyCode MoveForward => ParseEnum(Preferences["Config"]["MoveForward"].Value, KeyCode.Keypad8);
        
        [CompilerGenerated]
        public KeyCode MoveLeft => ParseEnum(Preferences["Config"]["MoveLeft"].Value, KeyCode.Keypad4);
        
        [CompilerGenerated]
        public KeyCode MoveRight => ParseEnum(Preferences["Config"]["MoveRight"].Value, KeyCode.Keypad6);
        
        [CompilerGenerated]
        public KeyCode MoveUp => ParseEnum(Preferences["Config"]["MoveUp"].Value, KeyCode.Keypad3);
        
        [CompilerGenerated]
        public KeyCode Reset => ParseEnum(Preferences["Config"]["Reset"].Value, KeyCode.Keypad5);
        
        [CompilerGenerated]
        public KeyCode Screenshot => ParseEnum(Preferences["Config"]["Screenshot"].Value, KeyCode.Keypad0);
        
        [CompilerGenerated]
        public KeyCode ToggleFine => ParseEnum(Preferences["Config"]["ToggleFine"].Value, KeyCode.KeypadDivide);
        
        [CompilerGenerated]
        public KeyCode ZoomIn => ParseEnum(Preferences["Config"]["ZoomIn"].Value, KeyCode.KeypadPlus);
        
        [CompilerGenerated]
        public KeyCode ZoomOut => ParseEnum(Preferences["Config"]["ZoomOut"].Value, KeyCode.KeypadMinus);
        
        [CompilerGenerated]
        public Single FOV => ParseConvertible(Preferences["Config"]["FOV"].Value, -1f);
        
        [CompilerGenerated]
        public Single FOVChange => ParseConvertible(Preferences["Config"]["FOVChange"].Value, 0.25f);
        
        [CompilerGenerated]
        public Single MoveRate => ParseConvertible(Preferences["Config"]["MoveRate"].Value, 0.05f);
        
        [CompilerGenerated]
        public Single SpinRate => ParseConvertible(Preferences["Config"]["SpinRate"].Value, 1f);
        
        #endregion

        #region Helper Methods

        [CompilerGenerated]
        private bool InitConfig(string section, string key, object value)
        {
            if (!Preferences.HasSection(section)
                || !Preferences[section].HasKey(key)
                || string.IsNullOrEmpty(Preferences[section][key].Value))
            {
                Preferences[section][key].Value = value.ToString();
                return true;
            }
            return false;
        }

        [CompilerGenerated]
        private static T ParseConvertible<T>(string value, T @default) where T : IConvertible
        {
            T retVal;
            try
            {
                retVal = (T) ((IConvertible) value).ToType(typeof (T), CultureInfo.InvariantCulture);
            }
            catch
            {
                retVal = @default;
            }
            return retVal;
        }

        [CompilerGenerated]
        private static T ParseEnum<T>(string value, T @default)
            where T : struct, IConvertible
        {
            var exists = string.IsNullOrEmpty(value)
                ? false
                : Enum.IsDefined(typeof (T), value);
            return exists
                ? (T) Enum.Parse(typeof (T), value)
                : @default;
        }

        #endregion
    }
}
