using UnityEngine;
using UnityEngine.UI;

namespace VRCorp.VR
{
    public class TestMenu : MonoBehaviour
    {
        public static TestMenu Instance;

        private void Awake()
        {
            Instance = this;
        }

        public Text btnText;

    
    }
}
