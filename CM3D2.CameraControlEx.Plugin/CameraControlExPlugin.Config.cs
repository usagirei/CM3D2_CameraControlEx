namespace CM3D2.CameraControlEx.Plugin
{
    partial class CameraControlExPlugin
    {
        #region Constants

        private const string CFG_SEC_CONFIG = "Config";

        #endregion

        #region Methods

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

        private void InitConfig()
        {
            var init = false;
            init |= InitConfig(CFG_SEC_CONFIG, nameof(Modifier), DEF_MODIFIER);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(Reset), DEF_RESET);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(ScreenShot), DEF_SCREENSHOT);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(MoveRate), DEF_MOVERATE);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(SpinRate), DEF_SPINRATE);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(FOV), DEF_FOV);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(MoveLeft), DEF_MOVELEFT);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(MoveRight), DEF_MOVERIGHT);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(MoveUp), DEF_MOVEUP);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(MoveDown), DEF_MOVEDOWN);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(ZoomIn), DEF_ZOOMIN);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(ZoomOut), DEF_ZOOMOUT);
            init |= InitConfig(CFG_SEC_CONFIG, nameof(FOVReset), DEF_FOVRESET);
            if (init)
                SaveConfig();
        }

        #endregion
    }
}