/***
 * Абстрактный класс для создания управляющих компонентов для взаимодействия с интерактивными объектами 
 */

using UnityEngine;

namespace VRCorp.VR
{
    public abstract class Interactor : MonoBehaviour
    {
        private protected Interactable _currentTarget;

        /***
         * Метод, вызываемый при старте взаимодействия с интерактивным объектом
         */
        public virtual void SetInteractiveObject(Interactable target)
        {
            InputControllerSystem.Add_InteractableObject(target);
            target.PointerEnter();
            _currentTarget = target;
        }

        /***
         * Метод, вызываемый при прекращении взаимодействия
         */
        public virtual void LostInteractiveObject()
        {
            InputControllerSystem.Remove_InteractableObject(_currentTarget);
            _currentTarget.PointerExit();
            _currentTarget = null;
        }
    }
}