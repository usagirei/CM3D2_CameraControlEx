// --------------------------------------------------
// CM3D2.CameraControlEx.Plugin - CameraControlExPlugin.cs
// --------------------------------------------------

#region Usings

using System;
using System.Reflection;
using UnityEngine;
using UnityInjector;
using UnityInjector.Attributes;

#endregion

namespace CM3D2.CameraControlEx.Plugin
{
    [PluginName("Extended Camera Controls")]
    [PluginFilter("CM3D2x64")]
    [PluginFilter("CM3D2x86")]
    [PluginFilter("CM3D2VRx86")]
    [PluginFilter("CM3D2VRx64")]
    public partial class CameraControlExPlugin : PluginBase
    {
        #region Properties

        public CameraMain MainCamera { get; private set; }
        public UltimateOrbitCamera OrbitCamera { get; private set; }
        private float DefaultDistance { get; set; }
        private float DefaultFOV { get; set; }
        private bool FirstUpdate { get; set; }
        private Vector3 OriginalPosition { get; set; }
        private Quaternion OriginalRotation { get; set; }

        #endregion

        #region (De)Constructors

        public CameraControlExPlugin()
        {
            InitConfig();
        }

        #endregion

        #region Public Methods

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
            if (OrbitCamera?.camera == null)
                return;

            if (FirstUpdate)
            {
                OriginalPosition = OrbitCamera.target.position;
                OriginalRotation = OrbitCamera.camera.transform.rotation;
                DefaultDistance = OrbitCamera.distance;

                if (FOV > 0)
                    OrbitCamera.camera.fieldOfView = FOV;
                DefaultFOV = OrbitCamera.camera.fieldOfView;
                Console.WriteLine("Setting FOV: " + OrbitCamera.camera.fieldOfView);
                FirstUpdate = false;
            }

            HandleHotkeys();

            if (Input.GetKey(Modifier))
                HandleRotation();
            else
                HandleMovement();

        }

        #endregion

        #region Public Static Methods

        public static T ParseEnum<T>(string value, T @default = default(T))
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

        #region Methods

        private void HandleHotkeys()
        {
            if (Input.GetKey(ZoomIn))
            {
                if (Input.GetKey(Modifier))
                    OrbitCamera.SetDistance(OrbitCamera.distance - MoveRate);
                else
                    OrbitCamera.camera.fieldOfView -= 0.25f;
            }
            else if (Input.GetKey(ZoomOut))
            {
                if (Input.GetKey(Modifier))
                    OrbitCamera.SetDistance(OrbitCamera.distance + MoveRate);
                else
                    OrbitCamera.camera.fieldOfView += 0.25f;
            }

            if (Input.GetKey(FOVReset))
            {
                OrbitCamera.camera.fieldOfView = DefaultFOV;
            }

            if (Input.GetKey(ScreenShot))
            {
                MainCamera.ScreenShot(Input.GetKey(Modifier));
            }

            if (Input.GetKey(Reset))
            {
                if (Input.GetKey(Modifier))
                {
                    OrbitCamera.camera.transform.rotation = OriginalRotation;
                    OrbitCamera.SetDistance(DefaultDistance);
                }
                else
                {
                    OrbitCamera.SetTargetPos(OriginalPosition);
                }
            }
        }

        private void HandleMovement()
        {
            Vector3 pos = OrbitCamera.target.position;
            var rot = OrbitCamera.transform.rotation;

            if (Input.GetKey(MoveLeft))
            {
                pos += rot * Vector3.left * MoveRate;
            }
            else if (Input.GetKey(MoveRight))
            {
                pos += rot * Vector3.right * MoveRate;
            }

            if (Input.GetKey(MoveForward))
            {
                pos += rot * Vector3.forward * MoveRate;
            }
            else if (Input.GetKey(MoveBackward))
            {
                pos += rot * Vector3.back * MoveRate;
            }

            if (Input.GetKey(MoveUp))
            {
                pos += Vector3.up * MoveRate;
            }
            else if (Input.GetKey(MoveDown))
            {
                pos += Vector3.down * MoveRate;
            }
            OrbitCamera.SetTargetPos(pos);
        }

        private void HandleRotation()
        {

            if (Input.GetKey(MoveLeft))
            {
                OrbitCamera.camera.transform.Rotate(0, SpinRate, 0);
            }
            else if (Input.GetKey(MoveRight))
            {
                OrbitCamera.camera.transform.Rotate(0, -SpinRate, 0);
            }

            if (Input.GetKey(MoveForward))
            {
                OrbitCamera.camera.transform.Rotate(SpinRate, 0, 0);
            }
            else if (Input.GetKey(MoveBackward))
            {
                OrbitCamera.camera.transform.Rotate(-SpinRate, 0, 0);
            }

            if (Input.GetKey(MoveUp))
            {
                OrbitCamera.camera.transform.Rotate(0, 0, -SpinRate);
            }
            else if (Input.GetKey(MoveDown))
            {
                OrbitCamera.camera.transform.Rotate(0, 0, SpinRate);
            }

        }

        #endregion
    }
}
