using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameSession gameSession;
    Timer timer;

    [SerializeField] AudioClip buttonClick;
    [SerializeField][Range(0f,1f)] float uIVolume;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        timer = FindObjectOfType<Timer>();
    }
    public void LoadNextScene() //Loads next scene in build index
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
        gameSession.LevelIncrease();
    }

    public void LoadStartScene() //Loads first scene in build index (menu)
    {
        SceneManager.LoadScene(0);
        gameSession.ResetGame();
        timer.TimerReset();
        Cursor.visible = true;
    }
    public void LoadShopScene() //Loads shop menu
    {
        SceneManager.LoadScene("Shop Menu");
        Cursor.visible = true;
    }
    public void SaveAndExitShop() //Loads first scene in build index (menu) SAVE UPGRADES PURCHASED
    {
        SceneManager.LoadScene(0);
        gameSession.UpdateCurrentLives();
        Cursor.visible = true;
    }

    public void LoadSceneEasy() //Loads the scene and applies EASY in game session
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        gameSession.EasyModifiers();
        Cursor.visible = false;
        gameSession.LevelIncrease();
    }

    public void LoadSceneNormal() //Loads the scene and applies NORMAL in game session
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        gameSession.NormalModifiers();
        Cursor.visible = false;
        gameSession.LevelIncrease();
    }

    public void LoadSceneHard() //Loads the scene and applies HARD in game session
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        gameSession.HardModifiers();
        Cursor.visible = false;
        gameSession.LevelIncrease();
    }

    public void QuitGame() //Quits the game
    {
        Application.Quit();
    }
}
