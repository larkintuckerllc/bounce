using UnityEngine;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public class Ball : MonoBehaviour
    {
        float SPEED = 0.3f;

        Mode.ModeEnum _mode = Mode.InitialState;
        bool _placementValid = PlacementValid.InitialState;
        Renderer _renderer;
        SphereCollider _sphereColllider;

        void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _sphereColllider = GetComponent<SphereCollider>();
        }

		void Start()
        {
            Provider.Store.Subscribe(state =>
            {
                Mode.ModeEnum nextMode = Mode.ModeGet(state);
                bool nextPlacementValid = PlacementValid.PlacementValidGet(state);
                if (
                    nextMode == _mode &&
                    nextPlacementValid == _placementValid
                ) { return; }
                _mode = nextMode;
                var firstPlacement = nextPlacementValid && !_placementValid;
                _placementValid = nextPlacementValid;
                if (firstPlacement)
                {
                    var position = Global.placement + (new Vector3(0.0f, 0.1f, 0.0f));
                    transform.position = position;
                    _renderer.enabled = true;
                }
                if (_mode == Mode.ModeEnum.Action)
                {
                    _sphereColllider.enabled = true;
                    var rb = gameObject.AddComponent<Rigidbody>();
                    rb.angularDrag = 0.0f;
                    rb.velocity = Quaternion.Euler(Global.aimEulerAngles) * (new Vector3(0.0f, 0.0f, 1.1f));
                }

            });
        }

        void Update()
        {
            if (_mode == Mode.ModeEnum.Placement)
            {
                float step = SPEED * Time.deltaTime;
                var position = Global.placement + (new Vector3(0.0f, 0.1f, 0.0f));
                transform.position = Vector3.MoveTowards(transform.position, position, step);
            }
        }

		private void OnCollisionEnter(Collision collision)
		{
            Provider.Dispatch(Score.Instance.ScoreIncrement());
		}
	}
}