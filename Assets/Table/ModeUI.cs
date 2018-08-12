using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public class ModeUI : MonoBehaviour
    {

        Mode.ModeEnum _mode = Mode.InitialState;
        Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _text.text = _mode.ToString();
        }

        void Start()
        {
            Provider.Store.Subscribe(state =>
            {
                Mode.ModeEnum nextMode = Mode.ModeGet(state);
                if (nextMode == _mode) { return; }
                _mode = nextMode;
                _text.text = _mode.ToString();
            });
        }

    }
}
