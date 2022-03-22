// ------------------------------------
// Auto-Generated with T4 Templating on Microsoft Visual Studio 16.0
// Template File: CameraControlExPlugin.Generated.tt
// ------------------------------------
// Install T4 Toolbox if having troubles
// ------------------------------------

using System;
using System.Globalization;
using System.Runtime.CompilerServices;

using UnityEngine;
using BepInEx.Configuration;


namespace COM3D2.CameraControlEx.Plugin
{
    partial class CameraControlExPlugin
    {
        [CompilerGenerated]
        partial void InitConfig() {
            ConfigEntryEyeToCam = Config.Bind("Config", "EyeToCam", KeyCode.KeypadPeriod);
            ConfigEntryFOVReset = Config.Bind("Config", "FOVReset", KeyCode.KeypadMultiply);
            ConfigEntryModifier = Config.Bind("Config", "Modifier", KeyCode.LeftAlt);
            ConfigEntryMoveBackward = Config.Bind("Config", "MoveBackward", KeyCode.Keypad2);
            ConfigEntryMoveDown = Config.Bind("Config", "MoveDown", KeyCode.Keypad1);
            ConfigEntryMoveForward = Config.Bind("Config", "MoveForward", KeyCode.Keypad8);
            ConfigEntryMoveLeft = Config.Bind("Config", "MoveLeft", KeyCode.Keypad4);
            ConfigEntryMoveRight = Config.Bind("Config", "MoveRight", KeyCode.Keypad6);
            ConfigEntryMoveUp = Config.Bind("Config", "MoveUp", KeyCode.Keypad3);
            ConfigEntryReset = Config.Bind("Config", "Reset", KeyCode.Keypad5);
            ConfigEntryScreenshot = Config.Bind("Config", "Screenshot", KeyCode.Keypad0);
            ConfigEntryToggleFine = Config.Bind("Config", "ToggleFine", KeyCode.KeypadDivide);
            ConfigEntryZoomIn = Config.Bind("Config", "ZoomIn", KeyCode.KeypadPlus);
            ConfigEntryZoomOut = Config.Bind("Config", "ZoomOut", KeyCode.KeypadMinus);
            ConfigEntryFOV = Config.Bind("Config", "FOV", -1f);
            ConfigEntryFOVChange = Config.Bind("Config", "FOVChange", 0.25f);
            ConfigEntryMoveRate = Config.Bind("Config", "MoveRate", 0.05f);
            ConfigEntrySpinRate = Config.Bind("Config", "SpinRate", 1f);
        }
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryEyeToCam;
        [CompilerGenerated]
        private KeyCode EyeToCam => ConfigEntryEyeToCam.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryFOVReset;
        [CompilerGenerated]
        private KeyCode FOVReset => ConfigEntryFOVReset.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryModifier;
        [CompilerGenerated]
        private KeyCode Modifier => ConfigEntryModifier.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryMoveBackward;
        [CompilerGenerated]
        private KeyCode MoveBackward => ConfigEntryMoveBackward.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryMoveDown;
        [CompilerGenerated]
        private KeyCode MoveDown => ConfigEntryMoveDown.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryMoveForward;
        [CompilerGenerated]
        private KeyCode MoveForward => ConfigEntryMoveForward.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryMoveLeft;
        [CompilerGenerated]
        private KeyCode MoveLeft => ConfigEntryMoveLeft.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryMoveRight;
        [CompilerGenerated]
        private KeyCode MoveRight => ConfigEntryMoveRight.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryMoveUp;
        [CompilerGenerated]
        private KeyCode MoveUp => ConfigEntryMoveUp.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryReset;
        [CompilerGenerated]
        private KeyCode Reset => ConfigEntryReset.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryScreenshot;
        [CompilerGenerated]
        private KeyCode Screenshot => ConfigEntryScreenshot.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryToggleFine;
        [CompilerGenerated]
        private KeyCode ToggleFine => ConfigEntryToggleFine.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryZoomIn;
        [CompilerGenerated]
        private KeyCode ZoomIn => ConfigEntryZoomIn.Value;
        
        [CompilerGenerated]
        private ConfigEntry<KeyCode> ConfigEntryZoomOut;
        [CompilerGenerated]
        private KeyCode ZoomOut => ConfigEntryZoomOut.Value;
        
        [CompilerGenerated]
        private ConfigEntry<Single> ConfigEntryFOV;
        [CompilerGenerated]
        private Single FOV => ConfigEntryFOV.Value;
        
        [CompilerGenerated]
        private ConfigEntry<Single> ConfigEntryFOVChange;
        [CompilerGenerated]
        private Single FOVChange => ConfigEntryFOVChange.Value;
        
        [CompilerGenerated]
        private ConfigEntry<Single> ConfigEntryMoveRate;
        [CompilerGenerated]
        private Single MoveRate => ConfigEntryMoveRate.Value;
        
        [CompilerGenerated]
        private ConfigEntry<Single> ConfigEntrySpinRate;
        [CompilerGenerated]
        private Single SpinRate => ConfigEntrySpinRate.Value;
 
    }
}
