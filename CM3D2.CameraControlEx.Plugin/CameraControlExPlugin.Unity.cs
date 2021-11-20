// --------------------------------------------------
// CM3D2_CameraControlEx - CameraControlExPlugin.Unity.cs
// --------------------------------------------------

using System;
using System.Reflection;

using UnityEngine;

namespace COM3D2.CameraControlEx.Plugin
{
    partial class CameraControlExPlugin
    {
        public void OnLevelWasLoaded(int level)
        {
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
    }
}
