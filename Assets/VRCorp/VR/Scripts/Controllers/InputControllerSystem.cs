/***
 * Управляет перечнем событий, вызываемых при нажатии на кнопки контроллера.
 * Служит хранителем событий с интерактивных объектов, добавляемых для вызова
 */

using System;
using UnityEngine;
using UnityEngine.Events;

namespace VRCorp.VR
{
    public class InputControllerSystem
    {
        public static Transform transform;
        
        static UnityEvent trigger = new UnityEvent();
        static UnityEvent back = new UnityEvent();
        static UnityEvent touchPad = new UnityEvent();

        public static void Add_InteractableObject(Interactable target)
        {
            trigger.AddListener(target.Click);
        }
        
        public static void Remove_InteractableObject(Interactable target)
        {
            trigger.RemoveListener(target.Click);
        }

        public static void TriggerDown ()
        {
            trigger.Invoke();
        }
        
        public static void BackDown ()
        {
            back.Invoke();
        }
        
        public static void TouchPad ()
        {
            touchPad.Invoke();
        }

    }
}
