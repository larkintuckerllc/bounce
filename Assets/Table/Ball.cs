using UnityEngine;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public class Ball : MonoBehaviour
    {
        float SPEED = 0.3f;

        Mode.ModeEnum _mode = Mode.InitialState;
        Triplet _placement = Placement.InitialState;
        bool _placementValid = PlacementValid.InitialState;
        Vector3 _position;
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
                Triplet nextPlacement = Placement.PlacementGet(state);
                bool nextPlacementValid = PlacementValid.PlacementValidGet(state);
                if (
                    nextMode == _mode &&
                    nextPlacement == _placement &&
                    nextPlacementValid == _placementValid
                ) { return; }
                _mode = nextMode;
                _placement = nextPlacement;
                var firstPlacement = nextPlacementValid && !_placementValid;
                _placementValid = nextPlacementValid;
                if (_mode == Mode.ModeEnum.Placement && _placementValid)
                {
                    var positionX = (float)(_placement.X) / 100;
                    var positionY = (float)(_placement.Y) / 100 + 0.1f;
                    var positionZ = (float)(_placement.Z) / 100;
                    var position = new Vector3(positionX, positionY, positionZ);
                    _position = position;
                    if (firstPlacement)
                    {
                        transform.position = position;
                        _renderer.enabled = true;
                    }
                }
                if (_mode == Mode.ModeEnum.Aim)
                {
                    _sphereColllider.enabled = true;
                    var position = _position + (new Vector3(0.0f, 1.0f, 0.0f));
                    transform.position = position;
                    gameObject.AddComponent<Rigidbody>();
                }
            });
        }

        void Update()
        {
            if (_mode == Mode.ModeEnum.Placement)
            {
                float step = SPEED * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _position, step);
            }
        }
	}
}