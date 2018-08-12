using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Com.Larkintuckerllc.Bounce
{
    public class ScoreUI : MonoBehaviour
    {
        int _score = Score.InitialState;
        Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _text.text = _score.ToString();
        }

        void Start()
        {
            Provider.Store.Subscribe(state =>
            {
                int nextScore = Score.ScoreGet(state);
                if (nextScore == _score) { return; }
                _score = nextScore;
                _text.text = _score.ToString();
            });
        }

    }
}