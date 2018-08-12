using UnityEngine;

namespace Com.Larkintuckerllc.Bounce
{
    public class WorldHeadLockCanvas : MonoBehaviour
    {
        static float DISTANCE = 2.5f;
        static float SPEED = 5.0f;
        void Update()
        {
            var step = SPEED * Time.deltaTime;
            var position = Global.mainCameraPosition + Global.mainCameraForward * DISTANCE;
            Quaternion rotation = Quaternion.LookRotation(transform.position - Global.mainCameraPosition);
            transform.position = Vector3.SlerpUnclamped(transform.position, position, step);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);
        }
    }
}
