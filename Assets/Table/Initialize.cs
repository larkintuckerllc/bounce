using UnityEngine;

namespace Com.Larkintuckerllc.Bounce
{
    public class Initialize : MonoBehaviour
    {
        static bool Initialized = false;

        void Awake()
        {
            if (Initialized) {
                return;
            }
            Provider.Initialize();
            Initialized = true;
        }
	}
}
