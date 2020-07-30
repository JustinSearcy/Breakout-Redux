using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosiveBallSlider : MonoBehaviour
{
    [SerializeField] Slider explosiveBallSlider;
    [SerializeField] float explosiveBallCooldown = 5f;


    public void Start()
    {
        explosiveBallSlider.GetComponent<Slider>();
    }


    public void Reset()
    {
        explosiveBallSlider.minValue = Time.time;
        explosiveBallSlider.maxValue = Time.time + explosiveBallCooldown;
    }

    private void Update()
    {
        if(FindObjectOfType<Ball>() != null)
        {
            if (FindObjectOfType<Ball>().ReturnHasStarted())
            {
                explosiveBallSlider.value = Time.time;
                if (explosiveBallSlider.value >= explosiveBallSlider.maxValue)
                {
                    FindObjectOfType<Ball>().ExplosiveBallAvailable();
                }
            }
        }
        else
        {
            return;
        }
    }
}
