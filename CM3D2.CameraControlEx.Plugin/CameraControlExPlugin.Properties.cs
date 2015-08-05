using UnityEngine;

namespace CM3D2.CameraControlEx.Plugin
{
    partial class CameraControlExPlugin
    {
        #region Constants

        private const float DEF_FOV = -1f;
        private const KeyCode DEF_FOVRESET = KeyCode.KeypadMultiply;
        private const KeyCode DEF_MODIFIER = KeyCode.LeftAlt;
        private const KeyCode DEF_MOVEBACKWARD = KeyCode.Keypad2;
        private const KeyCode DEF_MOVEDOWN = KeyCode.Keypad1;
        private const KeyCode DEF_MOVEFORWARD = KeyCode.Keypad8;
        private const KeyCode DEF_MOVELEFT = KeyCode.Keypad4;
        private const float DEF_MOVERATE = 0.05f;
        private const KeyCode DEF_MOVERIGHT = KeyCode.Keypad6;
        private const KeyCode DEF_MOVEUP = KeyCode.Keypad3;
        private const KeyCode DEF_RESET = KeyCode.Keypad5;
        private const KeyCode DEF_SCREENSHOT = KeyCode.Keypad0;
        private const float DEF_SPINRATE = 1f;
        private const KeyCode DEF_ZOOMIN = KeyCode.KeypadPlus;
        private const KeyCode DEF_ZOOMOUT = KeyCode.KeypadMinus;

        #endregion

        #region Properties

        public float FOV
        {
            get
            {
                float fov;
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(FOV)].Value;
                return float.TryParse(cfgVal, out fov)
                    ? fov
                    : DEF_FOV;
            }
        }

        public KeyCode FOVReset
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(FOVReset)].Value;
                return ParseEnum(cfgVal, DEF_FOVRESET);
            }
        }

        public KeyCode Modifier
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(Modifier)].Value;
                return ParseEnum(cfgVal, DEF_MODIFIER);
            }
        }

        public KeyCode MoveBackward
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(MoveBackward)].Value;
                return ParseEnum(cfgVal, DEF_MOVEBACKWARD);
            }
        }

        public KeyCode MoveDown
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(MoveDown)].Value;
                return ParseEnum(cfgVal, DEF_MOVEDOWN);
            }
        }

        public KeyCode MoveForward
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(MoveForward)].Value;
                return ParseEnum(cfgVal, DEF_MOVEFORWARD);
            }
        }

        public KeyCode MoveLeft
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(MoveLeft)].Value;
                return ParseEnum(cfgVal, DEF_MOVELEFT);
            }
        }

        public float MoveRate
        {
            get
            {
                float rate;
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(MoveRate)].Value;
                return float.TryParse(cfgVal, out rate)
                    ? rate
                    : DEF_MOVERATE;
            }
        }

        public KeyCode MoveRight
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(MoveRight)].Value;
                return ParseEnum(cfgVal, DEF_MOVERIGHT);
            }
        }

        public KeyCode MoveUp
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(MoveUp)].Value;
                return ParseEnum(cfgVal, DEF_MOVEUP);
            }
        }

        public KeyCode Reset
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(Reset)].Value;
                return ParseEnum(cfgVal, DEF_RESET);
            }
        }

        public KeyCode ScreenShot
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(ScreenShot)].Value;
                return ParseEnum(cfgVal, DEF_SCREENSHOT);
            }
        }

        public float SpinRate
        {
            get
            {
                float rate;
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(SpinRate)].Value;
                return float.TryParse(cfgVal, out rate)
                    ? rate
                    : DEF_SPINRATE;
            }
        }

        public KeyCode ZoomIn
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(ZoomIn)].Value;
                return ParseEnum(cfgVal, DEF_ZOOMIN);
            }
        }

        public KeyCode ZoomOut
        {
            get
            {
                var cfgVal = Preferences[CFG_SEC_CONFIG][nameof(ZoomOut)].Value;
                return ParseEnum(cfgVal, DEF_ZOOMOUT);
            }
        }

        #endregion
    }
}