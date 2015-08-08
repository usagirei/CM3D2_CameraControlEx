// --------------------------------------------------
// CM3D2_CameraControlEx - CameraControlExPlugin.Properties.cs
// --------------------------------------------------

using UnityEngine;

namespace CM3D2.CameraControlEx.Plugin
{
    partial class CameraControlExPlugin
    {
        private float DefaultDistance { get; set; }
        private float DefaultFOV { get; set; }
        private Maid.EyeMoveType EyeToCamMode { get; set; } = Maid.EyeMoveType.無視する;
        private bool FineTuneMode { get; set; }
        private bool FirstUpdate { get; set; }
        private CameraMain MainCamera { get; set; }
        private UltimateOrbitCamera OrbitCamera { get; set; }
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
    }
}
