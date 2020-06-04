/***
 * Симулятор работы в VR на ПК.
 * Используется в основном для тестирования.
 * Для работы добавить на игровой объект контроллера.
 * Требует ссылку на Transform камеры
 */

using System;
using UnityEngine;
using UnityEngine.XR;

namespace VRCorp.VR
{
    [AddComponentMenu("VRCorp/VR/Tools/Emulator")]
    public class Simulator : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;

        private void Awake()
        {
            
            if (XRSettings.isDeviceActive) Destroy(this);
            else
            {
                if (cameraTransform == null) throw new Exception("Добавьте ссылку на VR-камеру в компонент симулятора");
                transform.localPosition = new Vector3(0.15f, -0.15f, 0.5f);
                transform.parent = cameraTransform;
            }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                Rotate(cameraTransform);
            }

            if (Input.GetMouseButton(1))
            {
                Rotate(transform);
            }

            if (Input.GetMouseButtonDown(0))
            {
                InputControllerSystem.TriggerDown();
            }
        }

        public void Rotate(Transform transform)
        {
            float rotY = Input.GetAxis("Mouse X");
            float rotX = Input.GetAxis("Mouse Y") * -1;

            Vector3 rot = transform.eulerAngles;
            rot += new Vector3(rotX, rotY, 0);

            transform.eulerAngles = rot;
        }

        private void OnGUI()
        {
            GUI.TextArea(new Rect(10,10, 300, 100), 
                "Управление:"+
                "\nкамерой: "+ "левый Alt + поворот мыши" +
                "\nконтроллером: " + "зажатая правая клавиша мыши + поворот мыши" +
                "\nнажатие триггера: " + "нажатие левой клавиши мыши");
        }
    }
}
