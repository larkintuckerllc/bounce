using UnityEngine;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public class MeshingZone : MonoBehaviour
    {

        static float POSITIONING_SPEED = 0.3f;
        static float SCALING_SPEED = 0.3f;

        Mode.ModeEnum _mode = Mode.InitialState;
        Renderer _renderer;

		private void Awake()
		{
            _renderer = GetComponent<Renderer>();
		}

		void Start()
        {
            Provider.Store.Subscribe(state =>
            {
                Mode.ModeEnum nextMode = Mode.ModeGet(state);
                if (nextMode == _mode) { return; }
                _mode = nextMode;
                if (_mode == Mode.ModeEnum.Meshing)
                {
                    _renderer.enabled = false;
                }
            });
        }

        void Update()
        {
            float deltaTime = Time.deltaTime;
            var position = transform.position;
            var scale = transform.localScale;
            switch (_mode)
            {
                case Mode.ModeEnum.Positioning:
                    position.x += POSITIONING_SPEED * Global.touchX * deltaTime;
                    position.z += POSITIONING_SPEED * Global.touchY * deltaTime;
                    transform.position = position;
                    Global.mZPosition = position;
                    break;
                case Mode.ModeEnum.Scaling:
                    if (
                        (scale.x <= 1 && Global.touchX < 0) ||
                        (scale.z <= 1 && Global.touchY < 0)
                    )
                    {
                        break;
                    }
                    scale.x += SCALING_SPEED * Global.touchX * deltaTime;
                    scale.z += SCALING_SPEED * Global.touchY * deltaTime;
                    transform.localScale = scale;
                    Global.mZLocalScale = scale;
                    break;
            }
        }
    }
}
