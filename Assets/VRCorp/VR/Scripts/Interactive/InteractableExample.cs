/***
 * Пример реализации абстрактного класса Interactable 
 */
using UnityEngine;
using VRCorp.VR;

[AddComponentMenu("VRCorp/VR/Examples/InteractiveChangeColor")]
public class InteractableExample : Interactable
{
    private Material _material;
    private Color defaultColor;
    [SerializeField]private Color targetColor;
    
    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        defaultColor = _material.color;
    }

    // смена цвета при наведении
    public override void PointerEnter()
    {
        _material.color = targetColor;
    }

    // событие при нажатии
    public override void Click()
    {
        print("Click on " + this.name);
    }

    // возврат прежнего цвета, если с объектом нет взаимодействия
    public override void PointerExit()
    {
        _material.color = defaultColor;
    }
}
