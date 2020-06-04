/***
 * Компонент кнопки, работающей в VR
 * Реализует абстрактный класс Interactable
 * Требует для работы компонент ConvertToVR
 * Добавляется как компонент к кнопке меню
 */

using System;
using UnityEngine;
using UnityEngine.UI;
using VRCorp.VR;

[AddComponentMenu("VRCorp/VR/UI/Button")]
[RequireComponent(typeof(ConvertToVR))]
public class ButtonVR : Interactable
{
    private Button btn;
    private Image img;

    private void Awake()
    {
        btn = GetComponent<Button>();
        img = GetComponent<Image>();
    }

    public override void PointerEnter ()
    {
        img.color = btn.colors.highlightedColor;
    }

    public override void Click ()
    {
        print("Click on " + this.name);
        img.color = btn.colors.pressedColor;
        btn.onClick.Invoke();
    }

    public override void PointerExit()
    {
        img.color = btn.colors.normalColor;
    }
}
