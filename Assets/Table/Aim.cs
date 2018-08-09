using UnityEngine;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public class Aim : MonoBehaviour
    {
        static float SPEED = 90.0f;

        Mode.ModeEnum _mode = Mode.InitialState;
        Renderer _renderer;

        void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        void Start()
        {
            Provider.Store.Subscribe(state =>
            {
                Mode.ModeEnum nextMode = Mode.ModeGet(state);
                if (
                    nextMode == _mode
                ) { return; }
                _mode = nextMode;
                if (_mode == Mode.ModeEnum.Aim)
                {
                    var position = Global.placement + (new Vector3(0.0f, 0.1f, 0.0f));
                    transform.position = position;
                    _renderer.enabled = true;
                }
                if (_mode == Mode.ModeEnum.Action)
                {
                    _renderer.enabled = false;
                }
            });
        }

        void Update()
        {
            if (_mode != Mode.ModeEnum.Aim) { return; }
            float step = SPEED * Time.deltaTime * Global.touchX;
            transform.Rotate(Vector3.up * step);
            Global.aimEulerAngles = transform.eulerAngles;
        }
	}
}
