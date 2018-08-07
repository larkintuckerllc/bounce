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
        int _touchX = TouchX.InitialState;
        int _touchY = TouchY.InitialState;

		private void Awake()
		{
            _renderer = GetComponent<Renderer>();
		}

		void Start()
        {
            Provider.Store.Subscribe(state =>
            {
                Mode.ModeEnum nextMode = Mode.ModeGet(state);
                int nextTouchX = TouchX.TouchXGet(state);
                int nextTouchY = TouchY.TouchYGet(state);
                if (
                    nextMode == _mode &&
                    nextTouchX == _touchX &&
                    nextTouchY == _touchY
                ) { return; }

                _mode = nextMode;
                _touchX = nextTouchX;
                _touchY = nextTouchY;
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
                    position.x += POSITIONING_SPEED * (float)_touchX / 10 * deltaTime;
                    position.z += POSITIONING_SPEED * (float)_touchY / 10 * deltaTime;
                    transform.position = position;
                    break;
                case Mode.ModeEnum.Scaling:
                    if (
                        (scale.x <= 1 && _touchX < 0) ||
                        (scale.z <= 1 && _touchY < 0)
                    )
                    {
                        break;
                    }
                    scale.x += SCALING_SPEED * (float)_touchX / 10 * deltaTime;
                    scale.z += SCALING_SPEED * (float)_touchY / 10 * deltaTime;
                    transform.localScale = scale;
                    break;
            }
        }
    }
}
