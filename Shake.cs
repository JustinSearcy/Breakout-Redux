using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAnim;

    public void CamShake() //Play the camera shake animation
    {
        camAnim.SetTrigger("Shake");
    }

    public void BigCamShake() //Play the big camera shake animation
    {
        camAnim.SetTrigger("Big Shake");
    }
}
