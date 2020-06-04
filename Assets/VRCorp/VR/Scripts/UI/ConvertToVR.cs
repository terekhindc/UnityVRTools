/***
 * Конвертирует элементы меню в объекты, доступные для взаимодействия в VR,
 * накладывая на них коллайдеры
 * Добавляется в качестве компонента к элементам UI, включая Canvas
 */

using UnityEngine;

namespace VRCorp.VR
{
    [ExecuteInEditMode]
    [AddComponentMenu("VRCorp/VR/UI/ConvertElement")]
    [RequireComponent(typeof(BoxCollider))]
    public class ConvertToVR : MonoBehaviour
    {
        private static int deep = 0;
        private BoxCollider _collider;
        private RectTransform _rectTransform;
        [SerializeField] private bool convertChildren = false;
        private bool isConvert = false;
        private void Awake()
        {
            Convert(gameObject);
        }
        
        public void Convert(GameObject obj)
        {
            if (!isConvert)
            {
                _rectTransform = GetComponent<RectTransform>();
                _collider = GetComponent<BoxCollider>();
                var colliderWidth = _rectTransform.rect.width;
                var colliderHeight = _rectTransform.rect.height;
                var colliderDepth = 1;
                _collider.size = new Vector3(colliderWidth,colliderHeight,colliderDepth);
                if (obj.transform.childCount > 0 && convertChildren)
                {
                    deep++;
                    for (int i = 0; i < obj.transform.childCount; i++)
                    {
                        if (!obj.transform.GetChild(i).gameObject.GetComponent<ConvertToVR>())
                        {
                            var child = obj.transform.GetChild(i).gameObject.AddComponent<ConvertToVR>();
                            child.convertChildren = true;
                            child.GetComponent<RectTransform>().transform.localPosition -= new Vector3(0,0,i);
                            child.Convert(child.gameObject);
                        }
                    }
                }

                isConvert = true;
            }
        }
    }
}
