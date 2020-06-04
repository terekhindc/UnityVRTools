/***
 * Предоставляет интерфейс для реализации интерактивных объектов
 */

using UnityEngine;

namespace VRCorp.VR
{
    public abstract class Interactable : MonoBehaviour
    {
        
        // Старт взаимодействия
        public virtual void PointerEnter ()
        {
                        
        }

        // Нажатие на объект
        public virtual void Click ()
        {
            
        }

        // Завершение взаимодействия
        public virtual void PointerExit()
        {
            
        }
    }
}