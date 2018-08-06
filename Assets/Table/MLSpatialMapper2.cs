using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public class MLSpatialMapper2 : MonoBehaviour
    {
        Mode.ModeEnum _mode = Mode.InitialState;
        MLSpatialMapper _mLSpatialMapper;
        int _positionX = MZPositionX.InitialState;
        int _positionZ = MZPositionZ.InitialState;
        int _scaleX = MZScaleX.InitialState;
        int _scaleZ = MZScaleZ.InitialState;

		private void Awake()
		{
            _mLSpatialMapper = GetComponent<MLSpatialMapper>();
		}

		void Start()
        {
            Provider.Store.Subscribe(state =>
            {
                Mode.ModeEnum nextMode = Mode.ModeGet(state);
                int nextPositionX = MZPositionX.MZPositionXGet(state);
                int nextPositionZ = MZPositionZ.MZPositionZGet(state);
                int nextScaleX = MZScaleX.MZScaleXGet(state);
                int nextScaleZ = MZScaleZ.MZScaleZGet(state);
                if (
                    nextMode == _mode &&
                    nextPositionX == _positionX &&
                    nextPositionZ == _positionZ &&
                    nextScaleX == _scaleX &&
                    nextScaleZ == _scaleZ
                ) { return; }
                _mode = nextMode;
                _positionX = nextPositionX;
                _positionZ = nextPositionZ;
                _scaleX = nextScaleX;
                _scaleZ = nextScaleZ;
                if (_mode == Mode.ModeEnum.Meshing)
                {
                    var position = new Vector3((float)_positionX / 100, 0.0f, (float)_positionZ / 100);
                    var scale = new Vector3((float)_scaleX, 2.0f, (float)_scaleZ);
                    _mLSpatialMapper.enabled = true;
                }
            });
        }
    }
}