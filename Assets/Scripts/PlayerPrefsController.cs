using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string EXTRA_LIFE_COST_KEY = "extra life cost";
    const string TOTAL_LIVES_KEY = "total lives";    
    const string LONGER_PADDLE_COST_KEY = "longer paddle cost";
    const string PADDLE_SIZE_KEY = "paddle size";
    const string SECOND_CHANCE_COST_KEY = "second chance cost";
    const string SECOND_CHANCE_RATE_KEY = "second chance rate";
    const string EXPLOSIVE_BALL_COST_KEY = "explosive ball cost";
    const string EXPLOSIVE_BALL_ACTIVE_KEY = "explosive ball active";

    const string TOTAL_CURRENCY_KEY = "total currency";

    const string CONTROLS_TYPE_KEY = "control type";

    //----------------------------------SHOP SAVE DATA----------------------------------------------
    public static void InitializeExtraLifeCost() //If there is not cost value, set it to the inital
    {
        if (!PlayerPrefs.HasKey(EXTRA_LIFE_COST_KEY))
        {
            PlayerPrefs.SetInt(EXTRA_LIFE_COST_KEY, FindObjectOfType<Shop>().InitialExtraLifeCost());
        }
        else
        {
            return;
        }
    }

    public static void SetExtraLifeCost(int extraLifeCost) //Saves new extra life cost
    {
        PlayerPrefs.SetInt(EXTRA_LIFE_COST_KEY, extraLifeCost);
    } 

    public static int GetExtraLifeCost() //Returns current extra life cost
    {
        return PlayerPrefs.GetInt(EXTRA_LIFE_COST_KEY);
    } 

    public static void InitializeLongerPaddleCost() //If there is not cost value, set it to the inital
    {
        if (!PlayerPrefs.HasKey(LONGER_PADDLE_COST_KEY))
        {
            PlayerPrefs.SetInt(LONGER_PADDLE_COST_KEY, FindObjectOfType<Shop>().InitialLongerPaddleCost());
        }
        else
        {
            return;
        }
    }

    public static void SetLongerPaddleCost(int longerPaddleCost) //Saves new longer paddle cost
    {
        PlayerPrefs.SetInt(LONGER_PADDLE_COST_KEY, longerPaddleCost);
    } 

    public static int GetLongerPaddleCost() //Returns current longer paddle cost
    {
        return PlayerPrefs.GetInt(LONGER_PADDLE_COST_KEY);
    }

    public static void InitializeSecondChanceCost() //If there is not cost value, set it to the inital
    {
        if (!PlayerPrefs.HasKey(SECOND_CHANCE_COST_KEY))
        {
            PlayerPrefs.SetInt(SECOND_CHANCE_COST_KEY, FindObjectOfType<Shop>().InitialSecondChanceCost());
        }
        else
        {
            return;
        }
    }

    public static void SetSecondChanceCost(int secondChanceCost) //Saves new second chance cost
    {
        PlayerPrefs.SetInt(SECOND_CHANCE_COST_KEY, secondChanceCost);
    }

    public static int GetSecondChanceCost() //Returns current second chance cost
    {
        return PlayerPrefs.GetInt(SECOND_CHANCE_COST_KEY);
    }

    public static void InitializeExplosiveBallCost() //If there is not cost value, set it to the inital
    {
        if (!PlayerPrefs.HasKey(EXPLOSIVE_BALL_COST_KEY))
        {
            PlayerPrefs.SetInt(EXPLOSIVE_BALL_COST_KEY, FindObjectOfType<Shop>().InitialExplosiveBallCost());
        }
        else
        {
            return;
        }
    }

    public static void SetExplosiveBallCost(int explosiveBallCost) //Saves new explosive ball cost
    {
        PlayerPrefs.SetInt(EXPLOSIVE_BALL_COST_KEY, explosiveBallCost);
    }

    public static int GetExplosiveBallCost() //Returns current explosive ball cost
    {
        return PlayerPrefs.GetInt(EXPLOSIVE_BALL_COST_KEY);
    }



    //----------------------------------CURRENCY SAVE DATA------------------------------------------

    public static void InitializeTotalCurrency() //If there is not currency, set it to starting currency
    {
        if (!PlayerPrefs.HasKey(TOTAL_CURRENCY_KEY))
        {
            PlayerPrefs.SetInt(TOTAL_CURRENCY_KEY, FindObjectOfType<Currency>().ReturnStartingCurrency());
        }
        else
        {
            return;
        }
    }

    public static void SetTotalCurrency(int currency) //Saves new amount of total currency
    {
        PlayerPrefs.SetInt(TOTAL_CURRENCY_KEY, currency);
    }

    public static int GetTotalCurrency() //Returns current amount of total currency
    {
        return PlayerPrefs.GetInt(TOTAL_CURRENCY_KEY);
    }



    //----------------------------------POWERUP SAVE DATA-------------------------------------------

    public static void InitializeTotalLives() //If there is not lives, set it to starting lives
    {
        if (!PlayerPrefs.HasKey(TOTAL_LIVES_KEY))
        {
            PlayerPrefs.SetInt(TOTAL_LIVES_KEY, FindObjectOfType<PowerupsAndLives>().GetInitialLives());
        }
        else
        {
            return;
        }
    }

    public static void SetTotalLives(int lives) //Saves new amount of total lives
    {
        PlayerPrefs.SetInt(TOTAL_LIVES_KEY, lives);
    }

    public static int GetTotalLives() //Returns current amount of total lives
    {
        return PlayerPrefs.GetInt(TOTAL_LIVES_KEY);
    }

    public static void InitializePaddleSize() //If there is no paddle size, set it to starting size
    {
        if (!PlayerPrefs.HasKey(PADDLE_SIZE_KEY))
        {
            PlayerPrefs.SetFloat(PADDLE_SIZE_KEY, FindObjectOfType<PowerupsAndLives>().GetInitialPaddleSize());
        }
        else
        {
            return;
        }
    }

    public static void SetPaddleSize(float size) //Saves new paddle size
    {
        PlayerPrefs.SetFloat(PADDLE_SIZE_KEY, size);
    }

    public static float GetPaddleSize() //Returns current paddle size
    {
        return PlayerPrefs.GetFloat(PADDLE_SIZE_KEY);
    }

    public static void InitializeSecondChanceRate() //If there is no second chance rate, set it to starting rate
    {
        if (!PlayerPrefs.HasKey(SECOND_CHANCE_RATE_KEY))
        {
            PlayerPrefs.SetFloat(SECOND_CHANCE_RATE_KEY, FindObjectOfType<PowerupsAndLives>().GetInitialSecondChanceRate());
        }
        else
        {
            return;
        }
    }

    public static void SetSecondChanceRate(float rate) //Saves new second chance rate
    {
        PlayerPrefs.SetFloat(SECOND_CHANCE_RATE_KEY, rate);
    }

    public static float GetSecondChanceRate() //Returns current second chance rate
    {
        return PlayerPrefs.GetFloat(SECOND_CHANCE_RATE_KEY);
    }

    public static void InitializeExplosiveBallEnabled() //If there is not explosive ball data, set it to starting value
    {
        if (!PlayerPrefs.HasKey(EXPLOSIVE_BALL_ACTIVE_KEY))
        {
            PlayerPrefs.SetInt(EXPLOSIVE_BALL_ACTIVE_KEY, FindObjectOfType<PowerupsAndLives>().GetInitialExplosiveBallEnabled());
        }
        else
        {
            return;
        }
    }

    public static void SetExplosiveBallEnabled(int enabled) //Saves new amount of total lives
    {
        PlayerPrefs.SetInt(EXPLOSIVE_BALL_ACTIVE_KEY, enabled);
    }

    public static int GetExplosiveBallEnabled() //Returns current status of explosive ball
    {
        return PlayerPrefs.GetInt(EXPLOSIVE_BALL_ACTIVE_KEY);
    }


    //----------------------------------Controls DATA-------------------------------------------
    //0 is mouse, 1 is keyboard

    public static void InitializeControlType()
    {
        if (!PlayerPrefs.HasKey(CONTROLS_TYPE_KEY))
        {
            PlayerPrefs.SetInt(CONTROLS_TYPE_KEY, 0);
        }
        else
        {
            return;
        }
    }

    public static void SetControlType(int controls) //Saves new control type
    {
        PlayerPrefs.SetInt(CONTROLS_TYPE_KEY, controls);
    }

    public static float GetControlType() //Returns current control type
    {
        return PlayerPrefs.GetInt(CONTROLS_TYPE_KEY);
    }
}
