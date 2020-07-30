using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] int breakableBlocks; //Serialized for debugging
    [SerializeField] float timeBeforeLoad = 3f;

    //Cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks() //Increases the count of blocks
    {
        breakableBlocks++;
    }

    public void RemoveBreakableBlocks() //Removes blocks, if zero starts coroutine to load scene
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            FindObjectOfType<Timer>().StopTimer();
            FindObjectOfType<Ball>().DestroyBall();
            StartCoroutine(WaitAndLoad());
        }
    }

    IEnumerator WaitAndLoad() //Waits and then loads the next scene
    {
        yield return new WaitForSeconds(timeBeforeLoad);
        sceneloader.LoadNextScene();
    }
}
