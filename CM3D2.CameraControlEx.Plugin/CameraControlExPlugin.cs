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
        private Maid.EyeMoveType EyeToCamMode { get; set; } = Maid.EyeMoveType.無視する;
        private bool FineTuneMode { get; set; }
        private bool FirstUpdate { get; set; }
        private Vector3 OriginalPosition { get; set; }
        private Quaternion OriginalRotation { get; set; }

        private float TrueFOVChange => FineTuneMode
            ? FOVChange / 10
            : FOVChange;

        private float TrueMoveRate => FineTuneMode
            ? MoveRate / 10
            : MoveRate;

        private float TrueSpinRate => FineTuneMode
            ? SpinRate / 10
            : SpinRate;

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

        #endregion

        #region Methods

        private void HandleHotkeys()
        {
            var cameraComponent = OrbitCamera.GetComponent<Camera>();

            if (Input.GetKeyDown(ToggleFine))
                FineTuneMode ^= true;

            if (Input.GetKey(ZoomIn))
            {
                if (Input.GetKey(Modifier))
                    OrbitCamera.SetDistance(OrbitCamera.distance - TrueMoveRate);
                else
                    cameraComponent.fieldOfView -= TrueFOVChange;
            }
            else if (Input.GetKey(ZoomOut))
            {
                if (Input.GetKey(Modifier))
                    OrbitCamera.SetDistance(OrbitCamera.distance + TrueMoveRate);
                else
                    cameraComponent.fieldOfView += TrueFOVChange;
            }

            if (Input.GetKeyDown(EyeToCam))
            {
                if (GameMain.Instance.CharacterMgr.GetMaidCount() > 0)
                {
                    GameMain.Instance.CharacterMgr.GetMaid(0).EyeToCamera(EyeToCamMode, 0.8f);
                    EyeToCamMode = EyeToCamMode.NextEnum(1);
                }
            }

            if (Input.GetKey(FOVReset))
            {
                cameraComponent.fieldOfView = DefaultFOV;
            }

            if (Input.GetKeyDown(Screenshot))
            {
                MainCamera.ScreenShot(Input.GetKey(Modifier));
            }

            if (Input.GetKey(Reset))
            {
                if (Input.GetKey(Modifier))
                {
                    cameraComponent.transform.rotation = OriginalRotation;
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
                pos += rot * Vector3.left * TrueMoveRate;
            }
            else if (Input.GetKey(MoveRight))
            {
                pos += rot * Vector3.right * TrueMoveRate;
            }

            if (Input.GetKey(MoveForward))
            {
                pos += rot * Vector3.forward * TrueMoveRate;
            }
            else if (Input.GetKey(MoveBackward))
            {
                pos += rot * Vector3.back * TrueMoveRate;
            }

            if (Input.GetKey(MoveUp))
            {
                pos += Vector3.up * TrueMoveRate;
            }
            else if (Input.GetKey(MoveDown))
            {
                pos += Vector3.down * TrueMoveRate;
            }
            OrbitCamera.SetTargetPos(pos);
        }

        private void HandleRotation()
        {
            var cameraComponent = OrbitCamera.GetComponent<Camera>();
            if (Input.GetKey(MoveLeft))
            {
                cameraComponent.transform.Rotate(0, TrueSpinRate, 0);
            }
            else if (Input.GetKey(MoveRight))
            {
                cameraComponent.transform.Rotate(0, -TrueSpinRate, 0);
            }

            if (Input.GetKey(MoveForward))
            {
                cameraComponent.transform.Rotate(TrueSpinRate, 0, 0);
            }
            else if (Input.GetKey(MoveBackward))
            {
                cameraComponent.transform.Rotate(-TrueSpinRate, 0, 0);
            }

            if (Input.GetKey(MoveUp))
            {
                cameraComponent.transform.Rotate(0, 0, -TrueSpinRate);
            }
            else if (Input.GetKey(MoveDown))
            {
                cameraComponent.transform.Rotate(0, 0, TrueSpinRate);
            }
        }

        #endregion
    }

    public static class Extensions
    {
        #region Public Static Methods

        public static T NextEnum<T>(this T value, int start = 0) where T : struct
        {
            if (!typeof (T).IsEnum)
                throw new ArgumentException($"Argumnent {typeof (T).FullName} is not an Enum");

            var array = (T[]) Enum.GetValues(value.GetType());
            var j = Array.IndexOf(array, value) + 1;
            return (array.Length == j)
                ? array[start]
                : array[j];
        }

        #endregion
    }
}
