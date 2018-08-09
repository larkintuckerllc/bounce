using UnityEngine;
using UnityEngine.XR.MagicLeap;

namespace Com.Larkintuckerllc.Bounce
{
    public class InputHandler : MonoBehaviour
    {
        static uint TOUCH_CONTROL = 0;

        MLInputController _controller;

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
            Global.touchX = touch.x;
            Global.touchY = touch.y;
        }

        void OnDestroy()
        {
            MLInput.Stop();
        }
    }
}