// --------------------------------------------------
// CM3D2_CameraControlEx - CameraControlExPlugin.Unity.cs
// --------------------------------------------------

using System;
using System.Reflection;
using System.IO;

using UnityEngine;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using HarmonyLib.Tools;

namespace COM3D2.CameraControlEx.Plugin
{
    partial class CameraControlExPlugin
    {
        public void Awake()
        {
            OldConfigCheck();
            InitConfig();
        }

        public void OnLevelWasLoaded(int level)
        {
            SybarisCheck();
            FirstUpdate = true;
        }

        public void Start()
        {
            var fld = typeof (CameraMain).GetField("m_UOCamera", BindingFlags.NonPublic | BindingFlags.Instance);
            OrbitCamera = (UltimateOrbitCamera) fld.GetValue(GameMain.Instance.MainCamera);
            MainCamera = GameMain.Instance.MainCamera;
        }

        public void Update()
        {
            if (OrbitCamera?.GetComponent<Camera>() == null)
                return;

            if (FirstUpdate)
            {
                var cameraComponent = OrbitCamera.GetComponent<Camera>();
                OriginalPosition = OrbitCamera.target.position;
                OriginalRotation = cameraComponent.transform.rotation;
                DefaultDistance = OrbitCamera.distance;

                if (FOV > 0)
                    cameraComponent.fieldOfView = FOV;
                DefaultFOV = cameraComponent.fieldOfView;
                Console.WriteLine("Setting FOV: " + cameraComponent.fieldOfView);
                FirstUpdate = false;
            }

            HandleHotkeys();

            if (Input.GetKey(Modifier))
                HandleRotation();
            else
                HandleMovement();
        }

        private void OldConfigCheck()
        {
            var oldConfigPath = Path.Combine(Paths.GameRootPath, "Sybaris\\UnityInjector\\Config\\CameraControlExPlugin.ini");
            if (File.Exists(oldConfigPath))
            {
                Logger.LogWarning($"Detected old sybaris configuration at [{oldConfigPath}]. Make sure to migrate your configuration to the new configuration path. See plugin README.md for details.");
                this.transitionalConfigFile = new ConfigFile(oldConfigPath, false);
            }
        }

        private void SybarisCheck()
        {
            var injector = GameObject.Find("UnityInjector");
            var component = injector?.GetComponent("CameraControlExPlugin");
            
            if(component != null)
            {
                var assemblyLocation = component.GetType().Assembly.Location;
                Logger.LogWarning($"Detected old sybaris plugin at [{assemblyLocation}]. Disabling this plugin but you are advised to uninstall this properly. See plugin README.md for details.");
                GameObject.Destroy(component);
            }
        }

        private ConfigFile transitionalConfigFile;

        new ConfigFile Config
        {
            get => transitionalConfigFile ?? base.Config;
        }
    }
}
