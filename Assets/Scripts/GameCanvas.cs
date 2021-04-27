using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject explosiveBall;

    public Animator secondChanceAnim;

    private void Start()
    {
        if(PlayerPrefsController.GetExplosiveBallEnabled() == 1)
        {
            EnableExplosiveBall();
        }
        else { return; }
    }
    public void DisplayScore(int score)
    {
        scoreText.text = score.ToString(); //Displays current score
    }

    public void DisplayLevel(int level)
    {
        levelText.text = level.ToString(); //Displays current level
    }

    public void DisplayLives(int lives)
    {
        livesText.text = "X" + lives.ToString(); //Displays current lives
    }

    public void SecondChanceAnimation()
    {
        secondChanceAnim.SetBool("Second Chance",true);
        StartCoroutine(ResetSecondChance());
    }

    IEnumerator ResetSecondChance()
    {
        yield return new WaitForSeconds(2f);
        secondChanceAnim.SetBool("Second Chance", false);
    }

    public void EnableExplosiveBall()
    {
        explosiveBall.SetActive(true);
    }
}
