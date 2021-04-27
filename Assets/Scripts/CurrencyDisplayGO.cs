using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCurrency : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyText;

    public void DisplaySessionCurrency(int sessionCurrency)
    {
        currencyText.text = "$" + sessionCurrency;
    }
}
