using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MMCurrency : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyText;
    public Toggle mouseControls;

    void Start()
    {
        currencyText.text = "$" + PlayerPrefsController.GetTotalCurrency();
        PlayerPrefsController.InitializeControlType();
        if (PlayerPrefsController.GetControlType() == 0)
        {
            mouseControls.isOn = true;
        }
        else
        {
            mouseControls.isOn = false;
        }
    }

    public void ActiveToggle()
    {
        if (mouseControls.isOn)
        {
            PlayerPrefsController.SetControlType(0);
        }
        else
        {
            PlayerPrefsController.SetControlType(1);
        }
    }
}
