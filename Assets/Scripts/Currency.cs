using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] int startingCurrency = 0;
    private void Awake()
    {
        PlayerPrefsController.InitializeTotalCurrency();
    }

    public void BuyUpgrade(int amount) //If total currency is greater than the amount, save new total to old minus that amount
    {
        if(PlayerPrefsController.GetTotalCurrency() >= amount)
        {
            PlayerPrefsController.SetTotalCurrency(PlayerPrefsController.GetTotalCurrency() - amount);
        }
        
    }

    public void FindSessionCurrency(int sessionCurrency) //Finds currency for current session, adds and saves to the total
    {
        PlayerPrefsController.SetTotalCurrency(PlayerPrefsController.GetTotalCurrency() + sessionCurrency);
    }

    public int ReturnStartingCurrency()
    {
        return startingCurrency;
    }
}
