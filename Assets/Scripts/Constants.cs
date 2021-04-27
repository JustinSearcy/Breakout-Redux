using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    private void Awake() //Singleton pattern to only have one game session
    {
        int constantsCount = FindObjectsOfType<Constants>().Length;
        if (constantsCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
