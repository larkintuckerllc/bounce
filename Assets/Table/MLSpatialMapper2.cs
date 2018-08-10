using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public class MLSpatialMapper2 : MonoBehaviour
    {
        Mode.ModeEnum _mode = Mode.InitialState;
        MLSpatialMapper _mLSpatialMapper;

        private void Awake()
        {
            _mLSpatialMapper = GetComponent<MLSpatialMapper>();
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
                    transform.position = Global.mZPosition;
                    transform.localScale = Global.mZLocalScale;
                    _mLSpatialMapper.enabled = true;
                } else {
                    _mLSpatialMapper.enabled = false;
                }
            });
        }
    }
}