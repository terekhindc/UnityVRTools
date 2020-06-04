/***
 * Компонент контроллера OculusGO
 * Добавить в качестве компонента на объект, представляющий контроллер
 */

using System;
using UnityEngine;

namespace VRCorp.VR
{
    [AddComponentMenu("VRCorp/VR/Controllers/OculusGo")]
    [RequireComponent(typeof(OVRManager))]
    public class OculusGoController : MonoBehaviour
    {
        private void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) InputControllerSystem.TriggerDown();
            if (OVRInput.GetDown(OVRInput.Button.Back)) InputControllerSystem.BackDown();
            if (OVRInput.GetDown(OVRInput.Touch.PrimaryTouchpad)) InputControllerSystem.TouchPad();
        }
    }
}
