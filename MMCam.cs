using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMCam : MonoBehaviour
{
    [SerializeField] Canvas mainMenu;
    
    void Start()
    {
        mainMenu.worldCamera = Camera.main;
    }
}
