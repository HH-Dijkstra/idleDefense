using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopToggle : MonoBehaviour
{
    public GameObject ShopUI;
    private TMP_Text text;
    public bool ShopUIenabled = true;

    private void Start()
    {
        text = transform.GetComponentInChildren<TMP_Text>();
    }
    public void ToggleShop()
    {
        ShopUIenabled = !ShopUIenabled;
        ShopUI.SetActive(ShopUIenabled);
        if (ShopUIenabled)
        {
            text.SetText(">");
        }
        else
        {
            text.SetText("v");
        }
    }
}
