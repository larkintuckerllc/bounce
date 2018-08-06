using UnityEngine;
using UnityEngine.XR.MagicLeap;

namespace Com.Larkintuckerllc.Bounce
{
    public class InputHandler : MonoBehaviour
    {
        static uint TOUCH_CONTROL = 0;

        MLInputController _controller;
        int touchX = TouchX.InitialState;
        int touchY = TouchY.InitialState;

        void Awake()
        {
            MLResult result = MLInput.Start();
            if (!result.IsOk)
            {
                Debug.LogError("Error starting MLInput, disabling script.");
                enabled = false;
                return;
            }
            _controller = MLInput.GetController(MLInput.Hand.Left);
        }

        void Update()
        {
            var touch = _controller.State.TouchPosAndForce[TOUCH_CONTROL];
            var nextTouchX = (int)(touch.x * 10);
            var nextTouchY = (int)(touch.y * 10);
            if (nextTouchX != touchX)
            {
                Provider.Dispatch(TouchX.Instance.TouchXSet(nextTouchX));
                touchX = nextTouchX;
            }
            if (nextTouchY != touchY)
            {
                Provider.Dispatch(TouchY.Instance.TouchYSet(nextTouchY));
                touchY = nextTouchY;
            }
        }

        void OnDestroy()
        {
            MLInput.Stop();
        }
    }
}