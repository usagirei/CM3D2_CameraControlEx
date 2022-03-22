// --------------------------------------------------
// CM3D2_CameraControlEx - CameraControlExPlugin.cs
// --------------------------------------------------

using UnityEngine;

using BepInEx;

namespace COM3D2.CameraControlEx.Plugin
{
    [BepInPlugin("CameraControlExPlugin", "CameraControlEx", "1.1.0.0")]
    public partial class CameraControlExPlugin : BaseUnityPlugin
    {
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
            var pos = OrbitCamera.target.position;
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

        partial void InitConfig();
    }
}
