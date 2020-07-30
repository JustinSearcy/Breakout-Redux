using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config parameters
    [Header("Audio")]
    [SerializeField] AudioClip breakSound;
    [SerializeField][Range(0f,1f)] float blockDestroyVolume = 0.6f;

    [Header("VFX")]
    [SerializeField] GameObject blockDestroyVFX;
    [SerializeField] GameObject blockContactVFX;
    [SerializeField] float particleTime = 2f;

    [Header("Hit # and Sprites")]
    [SerializeField] Sprite[] hitSprites;

    //Cached reference
    Level level;
    GameSession gameStatus;
    Shake shake;
    Material material;
    Ball ball;

    bool isDissolving = false;
    bool isBreaking = false;
    float fade = 1f;

    //State Parameters
    [SerializeField] int timesHit; //Serialized for degub purposes

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        shake = FindObjectOfType<Shake>();
        gameStatus = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (isDissolving)
        {
            fade -= Time.deltaTime;

            if (fade <= 0)
            {
                fade = 0;
                isDissolving = false;
            }

            material.SetFloat("_Fade", fade);
        }
    }
    private void CountBreakableBlocks() //Count initial breakable block total for level progression
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //If ball contacts breakable block, handle explosive hit if that is active, else handle normal hit
    {
        if (tag == "Breakable")
        {
            if (ball.ExplosiveBall())
            {
                ball.HandleExplosiveHit();
            }
            else
            {
                HandleHit();
            }
        }
    }


    private void HandleHit() //If block has hits left, change sprite, if not break it
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            shake.CamShake();
            DestroyBlock();
        }
        else
        {
            TriggerBlockContactVFX();
            gameStatus.AddScoreHit();
            ShownNextHitSprite();
        }
    }

    private void ShownNextHitSprite() //Display next sprite in hit list
    {
        int spriteIndex = timesHit - 1; 
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is Missing from Array" + gameObject.name);
        }
    }

    private void DestroyBlock() //Destroy the block, play audio at cam
    {
        TriggerBlockDestroyedVFX();
        level.RemoveBreakableBlocks();
        AudioSource.PlayClipAtPoint(breakSound, FindObjectOfType<Camera>().transform.position, blockDestroyVolume);
        Destroy(gameObject);
        gameStatus.AddScoreDestroyed();
    }

    private void TriggerBlockDestroyedVFX() //Create particles where the block was destroyed
    {
        GameObject particles = Instantiate(blockDestroyVFX, transform.position, transform.rotation);
        Destroy(particles, particleTime);
    }

    private void TriggerBlockContactVFX() //Create particles where the block was hit
    {
        GameObject hitParticles = Instantiate(blockContactVFX, transform.position, transform.rotation);
        Destroy(hitParticles, particleTime);
    }

    public void BlockDissolve()
    {
        isDissolving = true;
    }
}
