using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration parameters

    [SerializeField] float screenWidth = 17.6667f;
    [SerializeField] float minX = 4.5f;
    [SerializeField] float maxX = 13.2f;
    [SerializeField] float minX2 = 4.65f;
    [SerializeField] float maxX2 = 13.05f;
    [SerializeField] float minX3 = 4.8f;
    [SerializeField] float maxX3= 12.9f;
    [SerializeField] float moveSpeed = 10f;

    Vector2 originalPos;

    Ball ball;
    GameSession gameSession;

    float paddleSize;

    // Start is called before the first frame update
    void Start()
    {
        paddleSize = PlayerPrefsController.GetPaddleSize();
        SetSize();
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
        originalPos = new Vector2(
            gameObject.transform.position.x,
            gameObject.transform.position.y);
    }


    void Update() //Move and clamps paddle based on size
    {
        if (PlayerPrefsController.GetControlType() == 0)
        {
            if (paddleSize == 1f)
            {
                Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
                paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX); //Move to the x coordinate with set boundaries
                transform.position = paddlePos;
            }
            if (paddleSize == 1.25f)
            {
                Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
                paddlePos.x = Mathf.Clamp(GetXPos(), minX2, maxX2); //Move to the x coordinate with set boundaries
                transform.position = paddlePos;
            }
            if (paddleSize == 1.5f)
            {
                Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
                paddlePos.x = Mathf.Clamp(GetXPos(), minX3, maxX3); //Move to the x coordinate with set boundaries
                transform.position = paddlePos;
            }
        }

        if(PlayerPrefsController.GetControlType() == 1)
        {
            if (paddleSize == 1f)
            {
                var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
                var newXPos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
                transform.position = new Vector2(newXPos, transform.position.y);
            }
            if (paddleSize == 1.25f)
            {
                var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
                var newXPos = Mathf.Clamp(transform.position.x + deltaX, minX2, maxX2);
                transform.position = new Vector2(newXPos, transform.position.y);
            }
            if (paddleSize == 1.5f)
            {
                var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
                var newXPos = Mathf.Clamp(transform.position.x + deltaX, minX3, maxX3);
                transform.position = new Vector2(newXPos, transform.position.y);
            }
        }
       
    }                                                   

    private float GetXPos() //Find the x coordinate for the paddle
    {
        if (gameSession.IsAutoPlayEnabled() && ball != null)
        {
                return ball.transform.position.x; //x coordinate is the same as the ball
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth; //x coordinate is the same as the mouse
        }
    }

    public void ResetPaddle()
    {
        transform.position = originalPos;
    }

    public void SetSize()
    {
        Vector3 standard = new Vector3(1,1,1);
        standard.x *= paddleSize;
        gameObject.transform.localScale = standard;
    }
}
