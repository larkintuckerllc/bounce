using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public class KeyPoseHandler : MonoBehaviour
    {
        static MLHandKeyPose KEY_POSE = MLHandKeyPose.Ok;
        static float KEY_POSE_CONFIDENCE_THRESHOLD = 0.5f;

        Mode.ModeEnum _mode = Mode.InitialState;
        bool _first = true;
        bool _posed = false;

        void Awake()
        {
            MLResult result = MLHands.Start();
            if (!result.IsOk)
            {
                Debug.LogError("Error starting MLHand, disabling script.");
                enabled = false;
                return;
            }
            var enabledPoses = new MLHandKeyPose[] {
                MLHandKeyPose.Ok
            };
            MLHands.KeyPoseManager.EnableKeyPoses(enabledPoses, true);
        }

        void Start()
        {
            Provider.Store.Subscribe(state =>
            {
                Mode.ModeEnum nextMode = Mode.ModeGet(state);
                if ( nextMode == _mode ) { return; }
                _mode = nextMode;
            });
        }

        void Update()
        {
            if (_first) {
                _posed = Posed(); // DOESN'T RETURN CORRECTLY UNTIL UPDATE
                _first = false;
                return;
            }
            var newPosed = Posed();
            if (newPosed == _posed) {
                return;
            }
            _posed = newPosed;
            if (!_posed) { return; }
            switch (_mode) {
                case Mode.ModeEnum.Positioning:
                    Provider.Dispatch(Mode.Instance.ModeSet(Mode.ModeEnum.Scaling));
                    break;
                case Mode.ModeEnum.Scaling:
                    Provider.Dispatch(Mode.Instance.ModeSet(Mode.ModeEnum.Meshing));
                    break;
                case Mode.ModeEnum.Meshing:
                    Provider.Dispatch(Mode.Instance.ModeSet(Mode.ModeEnum.Placement));
                    break;
                case Mode.ModeEnum.Placement:
                    Provider.Dispatch(Mode.Instance.ModeSet(Mode.ModeEnum.Aim));
                    break;
            }
        }

        void OnDestroy()
        {
            MLHands.Stop();
        }

        bool Posed() {
            var hand = MLHands.Right;
            return (
                hand.KeyPose == KEY_POSE &&
                hand.KeyPoseConfidence > KEY_POSE_CONFIDENCE_THRESHOLD
            );
        }
    }
}