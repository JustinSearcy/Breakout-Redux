using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Misc")]
    [SerializeField] Paddle paddle1;
    [SerializeField] GameObject ballDestroyVFX;

    [Header("Forces")]
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 8f;
    [SerializeField] float randomFactor = 0.2f;

    [Header("Audio")]
    [SerializeField] AudioClip[] ballsounds;
    [SerializeField] AudioClip explosion;

    [Header("Explosion")]
    [SerializeField] float explosionRadius = 2f;
    [SerializeField] float explosionTimer = 5f;
    [SerializeField] GameObject explosionParticles;
    [SerializeField] float particleTime;

    [Header("Debug")]
    [SerializeField] bool isExplosive = false;
    [SerializeField] bool explosiveBallAvailable = false;
    [SerializeField] bool hasStarted = false;

    //State
    Vector2 paddleToBallVector;
    Vector2 originalPos;
  
    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    GameSession gameSession;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        timer = FindObjectOfType<Timer>();
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle1.transform.position;
        originalPos = new Vector2(
            gameObject.transform.position.x,
            gameObject.transform.position.y);
        SetBallSpeed();
    }

    void Update()
    {
        ActivateExplosiveBall();
        if(hasStarted == false)//If ball hasn't been launched, keep on paddle and launch on click
        {
            BallPosition();
            LaunchOnMouseClick();
        }
    }

     public void SetBallSpeed() //Changes the speed of the ball based on the difficulty
     {
        if (gameSession.ReturnEasy())
        {
            yPush = yPush * 0.75f;
        }
        else if (gameSession.ReturnNormal())
        {
            return;
        }
        else if (gameSession.ReturnHard())
        {
            yPush = yPush * 1.5f;
        }
     }

    private void LaunchOnMouseClick() //When left click happens, launch the ball and start the timer
    {
        if (PlayerPrefsController.GetControlType() == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (FindObjectOfType<ExplosiveBallSlider>() != null)
                {
                    FindObjectOfType<ExplosiveBallSlider>().Reset();
                    hasStarted = true;
                    myRigidBody2D.velocity = new Vector2(xPush, yPush);
                    timer.StartTimer();
                }
                else
                {
                    hasStarted = true;
                    myRigidBody2D.velocity = new Vector2(xPush, yPush);
                    timer.StartTimer();
                }
            }
            
        }
        if (PlayerPrefsController.GetControlType() == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (FindObjectOfType<ExplosiveBallSlider>() != null)
                {
                    FindObjectOfType<ExplosiveBallSlider>().Reset();
                    hasStarted = true;
                    myRigidBody2D.velocity = new Vector2(xPush, yPush);
                    timer.StartTimer();
                }
                else
                {
                    hasStarted = true;
                    myRigidBody2D.velocity = new Vector2(xPush, yPush);
                    timer.StartTimer();
                }
            }

        }
    }

    private void BallPosition() //Keeps the ball's position on the paddle
    { 
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddleToBallVector + paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision) //When another object is hit, add the slight random velocity and play sound effect
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0, randomFactor), UnityEngine.Random.Range(0, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballsounds[UnityEngine.Random.Range(0, ballsounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    public void DestroyBall() //Destroys the ball
    {
        Instantiate(ballDestroyVFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void ResetBall() //Resets ball position
    {
        transform.position = originalPos;
        hasStarted = false;
        gameObject.GetComponent<TrailRenderer>().enabled = true;
    }

    public bool ExplosiveBall()
    {
        return isExplosive;
    }

    public void ExplosiveBallAvailable() //Ball is able to be made explosive
    {
        explosiveBallAvailable = true;
    }

    private void ActivateExplosiveBall() //If explosive ball is off cooldown and you right click, set ball to explosive
    {
        if (explosiveBallAvailable)
        {
            if (PlayerPrefsController.GetControlType() == 0)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    isExplosive = true;
                    GetComponent<SpriteRenderer>().color = Color.red;
                }
            }

            if (PlayerPrefsController.GetControlType() == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isExplosive = true;
                    GetComponent<SpriteRenderer>().color = Color.red;
                }
            }

        }
    }

    public void HandleExplosiveHit()
    {
        myAudioSource.PlayOneShot(explosion);
        InstantiateExplosionVFX();
        FindObjectOfType<Shake>().BigCamShake();
        var hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, LayerMask.GetMask("Breakable"));
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].SendMessage("HandleHit");
        }
        isExplosive = false;
        explosiveBallAvailable = false;
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<ExplosiveBallSlider>().Reset();
    }

    void InstantiateExplosionVFX()
    {
        GameObject particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(particles, particleTime);
    }

    public void StopBall()
    {
        myRigidBody2D.velocity = new Vector2(0, 0);
    }

    public bool ReturnHasStarted() { return hasStarted; }
}
