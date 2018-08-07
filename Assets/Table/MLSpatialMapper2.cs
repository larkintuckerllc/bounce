using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public class MLSpatialMapper2 : MonoBehaviour
    {
        Mode.ModeEnum _mode = Mode.InitialState;
        MLSpatialMapper _mLSpatialMapper;
        GameObject _meshingZone; // REFERENCE FOR PERFORMANCE

		private void Awake()
		{
            _mLSpatialMapper = GetComponent<MLSpatialMapper>();
            _meshingZone = GameObject.Find("MeshingZone");
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
                    transform.position = _meshingZone.transform.position;
                    transform.localScale = _meshingZone.transform.localScale;
                    _mLSpatialMapper.enabled = true;
                }
            });
        }
    }
}