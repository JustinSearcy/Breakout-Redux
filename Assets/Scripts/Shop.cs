using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Shop : MonoBehaviour
{
    [Header("Shop Price Text")]
    [SerializeField] TextMeshProUGUI totalCurrencyText;
    [SerializeField] TextMeshProUGUI extraLifeCostText;
    [SerializeField] TextMeshProUGUI longerPaddleCostText;
    [SerializeField] TextMeshProUGUI secondChanceCostText;
    [SerializeField] TextMeshProUGUI explosiveBallCostText;

    [Header("Extra Life Cost")]
    [SerializeField] int extraLifeCost0 = 50;
    [SerializeField] int extraLifeCost1 = 100;
    [SerializeField] int extraLifeCost2 = 200;
    [SerializeField] int extraLifeCost3 = 350;

    [Header("Longer Paddle Cost")]
    [SerializeField] int longerPaddleCost0 = 200;
    [SerializeField] int longerPaddleCost1 = 500;

    [Header("Second Chance Cost")]
    [SerializeField] int secondChanceCost0 = 200;
    [SerializeField] int secondChanceCost1 = 400;
    [SerializeField] int secondChanceCost2 = 800;

    [Header("Explosive Ball Cost")]
    [SerializeField] int explosiveBallCost = 250;

    [Header("Buttons")]
    [SerializeField] GameObject heartButton;
    [SerializeField] GameObject paddleButton;
    [SerializeField] GameObject secondChanceButton;
    [SerializeField] GameObject explosiveBallButton;

    Currency currency;
    PowerupsAndLives powerupsAndLives;

    private void Start()
    {
        
        PlayerPrefsController.InitializeExtraLifeCost();
        PlayerPrefsController.InitializeLongerPaddleCost();
        PlayerPrefsController.InitializeSecondChanceCost();
        PlayerPrefsController.InitializeExplosiveBallCost();

        powerupsAndLives = FindObjectOfType<PowerupsAndLives>();
        currency = FindObjectOfType<Currency>();

        totalCurrencyText.text = "$" + PlayerPrefsController.GetTotalCurrency();

        DisplayExtraLifeCost();
        DisplayLongerPaddleCost();
        DisplaySecondChanceCost();
        DisplayExplosiveBallCost();
    }

    //------------------------------------------EXTRA LIFE----------------------------------------------------------

    private void DisplayExtraLifeCost() //If price is max, display OUT OF STOCK instead of price and disable button
    {
        if (PlayerPrefsController.GetExtraLifeCost() > extraLifeCost3)
        {
            extraLifeCostText.text = "OUT OF STOCK";
            heartButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            extraLifeCostText.text = "$" + PlayerPrefsController.GetExtraLifeCost();
        }
    }

    public void BuyExtraLife() //Spend the money if available, update the currency amount, increase lives, change the price
    {
        if (PlayerPrefsController.GetTotalCurrency() >= PlayerPrefsController.GetExtraLifeCost())
        {
            currency.BuyUpgrade(PlayerPrefsController.GetExtraLifeCost());
            UpdateCurrency();
            powerupsAndLives.IncreaseLives();
            NewExtraLifePrice(); 
        }
        else
        {
            return;
        }
    }

    private void NewExtraLifePrice() //Change price based on how many times bought and saves value and updates text display
    {
        if(PlayerPrefsController.GetExtraLifeCost() == extraLifeCost0)
        {
            PlayerPrefsController.SetExtraLifeCost(extraLifeCost1);
            UpdateExtraLifeCost();
        }
        else if(PlayerPrefsController.GetExtraLifeCost() == extraLifeCost1)
        {
            PlayerPrefsController.SetExtraLifeCost(extraLifeCost2);
            UpdateExtraLifeCost();
        }
        else if(PlayerPrefsController.GetExtraLifeCost() == extraLifeCost2)
        {
            PlayerPrefsController.SetExtraLifeCost(extraLifeCost3);
            UpdateExtraLifeCost();
        }
        else if (PlayerPrefsController.GetExtraLifeCost() >= extraLifeCost3)
        {
            PlayerPrefsController.SetExtraLifeCost(extraLifeCost3 + 1);
            heartButton.GetComponent<Button>().interactable = false;
            extraLifeCostText.text = "OUT OF STOCK";
        }
    }

    private void UpdateExtraLifeCost() //Updates cost of buying an extra life
    {
        extraLifeCostText.text = "$" + PlayerPrefs.GetInt("extra life cost");
    }

    public int InitialExtraLifeCost() { return extraLifeCost0; }


    //------------------------------------------LONGER PADDLE----------------------------------------------------------

    private void DisplayLongerPaddleCost() //If price is max, display OUT OF STOCK instead of price and disable button
    {
        if (PlayerPrefsController.GetLongerPaddleCost() > longerPaddleCost1)
        {
            longerPaddleCostText.text = "OUT OF STOCK";
            paddleButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            longerPaddleCostText.text = "$" + PlayerPrefsController.GetLongerPaddleCost().ToString();
        }
    }

    public void BuyLongerPaddle() //Increase paddle length, update currency total, change price
    {
        if (PlayerPrefsController.GetTotalCurrency() >= PlayerPrefsController.GetLongerPaddleCost())
        {
            currency.BuyUpgrade(PlayerPrefsController.GetLongerPaddleCost());
            UpdateCurrency();
            powerupsAndLives.IncreasePaddleSize();
            NewPaddleLengthPrice();
        }
        else
        {
            return;
        }
    }

    private void NewPaddleLengthPrice() //Change price based on how many times bought
    {
        if (PlayerPrefsController.GetLongerPaddleCost() == longerPaddleCost0)
        {
            PlayerPrefsController.SetLongerPaddleCost(longerPaddleCost1);
            UpdateLongerPaddleCost();
        }
        else if (PlayerPrefsController.GetLongerPaddleCost() >= longerPaddleCost1)
        {
            PlayerPrefsController.SetLongerPaddleCost(longerPaddleCost1 + 1);
            paddleButton.GetComponent<Button>().interactable = false;
            longerPaddleCostText.text = "OUT OF STOCK";
        }
    }

    private void UpdateLongerPaddleCost() //Updates cost of buying a longer paddle
    {
        longerPaddleCostText.text = "$" + PlayerPrefsController.GetLongerPaddleCost();
    }

    public int InitialLongerPaddleCost() { return longerPaddleCost0; }


    //------------------------------------------SECOND CHANCE----------------------------------------------------------

    private void DisplaySecondChanceCost() //If price is max, display OUT OF STOCK instead of price and disable button
    {
        if (PlayerPrefsController.GetSecondChanceCost() >= secondChanceCost2)
        {
            secondChanceCostText.text = "OUT OF STOCK";
            secondChanceButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            secondChanceCostText.text = "$" + PlayerPrefsController.GetSecondChanceCost().ToString();
        }
    }

    public void BuySecondChance() //Increase second chance rate, update currency total, change price
    {
        if (PlayerPrefsController.GetTotalCurrency() >= PlayerPrefsController.GetSecondChanceCost())
        {
            currency.BuyUpgrade(PlayerPrefsController.GetSecondChanceCost());
            UpdateCurrency();
            powerupsAndLives.IncreaseSecondChanceRate();
            NewSecondChancePrice();
        }
        else
        {
            return;
        }
    }

    private void NewSecondChancePrice() //Change price based on how many times bought
    {
        if (PlayerPrefsController.GetSecondChanceCost() == secondChanceCost0)
        {
            PlayerPrefsController.SetSecondChanceCost(secondChanceCost1);
            UpdateSecondChanceCost();
        }
        else if (PlayerPrefsController.GetSecondChanceCost() == secondChanceCost1)
        {
            PlayerPrefsController.SetSecondChanceCost(secondChanceCost2);
            UpdateSecondChanceCost();
        }
        else if (PlayerPrefsController.GetSecondChanceCost() >= secondChanceCost2)
        {
            PlayerPrefsController.SetSecondChanceCost(secondChanceCost2 + 1);
            secondChanceButton.GetComponent<Button>().interactable = false;
            secondChanceCostText.text = "OUT OF STOCK";
        }
    }

    private void UpdateSecondChanceCost() //Updates cost of buying a second chance
    {
        secondChanceCostText.text = "$" + PlayerPrefsController.GetSecondChanceCost();
    }

    public int InitialSecondChanceCost() { return secondChanceCost0; }



    //------------------------------------------Explosive Ball----------------------------------------------------------

    private void DisplayExplosiveBallCost() //If price is max, display OUT OF STOCK instead of price and disable button
    {
        if (PlayerPrefsController.GetExplosiveBallCost() > explosiveBallCost)
        {
            explosiveBallCostText.text = "OUT OF STOCK";
            explosiveBallButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            explosiveBallCostText.text = "$" + PlayerPrefsController.GetExplosiveBallCost().ToString();
        }
    }

    public void BuyExplosiveBall() //Activate explosive ball, update currency total, change price
    {
        if (PlayerPrefsController.GetTotalCurrency() >= PlayerPrefsController.GetExplosiveBallCost())
        {
            currency.BuyUpgrade(PlayerPrefsController.GetExplosiveBallCost());
            UpdateCurrency();
            powerupsAndLives.EnableExplosiveBall();
            NewExplosiveBallPrice();
        }
        else
        {
            return;
        }
    }

    private void NewExplosiveBallPrice() //Change price based on how many times bought
    {
            PlayerPrefsController.SetExplosiveBallCost(explosiveBallCost + 1);
            explosiveBallButton.GetComponent<Button>().interactable = false;
            explosiveBallCostText.text = "OUT OF STOCK";
    }

    public int InitialExplosiveBallCost() { return explosiveBallCost; }



    //--------------------------------------------CURRENCY-------------------------------------------------------------
    public void UpdateCurrency() //Updates total amount of currency owned
    {
        totalCurrencyText.text = "$" + PlayerPrefsController.GetTotalCurrency();
    }
}
