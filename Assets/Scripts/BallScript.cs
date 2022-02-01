using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BallScript : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI ScoreValue;
    public TextMeshProUGUI TimeValue;
    public TextMeshProUGUI WinText;
    public Button NewGame;
    public Button NewBall;
    public GameObject ball;
    public float timeRemaining;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        timeRemaining = 60;
        NewGame.gameObject.SetActive(false);
        NewGame.onClick.AddListener(startNewGame);
        NewBall.onClick.AddListener(resetBall);
        setCountText();
        WinText.text = "";
    }
 
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            setCountText();
        }
    }

    // private void OnMove(InputValue movementValue)
    // {
    //     Vector2 movementVector = movementValue.Get<Vector2>();

    //     movementX = movementVector.x;
    //     movementY = movementVector.y;
    // }

    private void setCountText()
    {
        ScoreValue.text = count.ToString();
        float timeRemainingFormat = Mathf.Round(timeRemaining * 100f) / 100f;
        TimeValue.text = "Time: " + timeRemainingFormat.ToString();
        if(timeRemaining <= 0){
           WinText.text = "Time is up!";
           NewGame.gameObject.SetActive(true);
           NewBall.gameObject.SetActive(false);
           ball.gameObject.SetActive(false);
        }
    }

    private void startNewGame()
    {
        NewGame.gameObject.SetActive(false);
        NewBall.gameObject.SetActive(true);
        ball.gameObject.SetActive(true);
        WinText.text = "";
        timeRemaining = 60;
        count = 0;
        resetBall();
        Debug.Log("new");
    }

    private void resetBall()
    {
        ball.transform.position = new Vector3(5.32f, 0.3f, -6.53f);
        movementX = 0;
        movementY = 0;
        speed = 0;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("PickUps")) 
        {
            other.gameObject.SetActive(false);
            count++;
            timeRemaining += 10;
            setCountText();
        }
        
    }
}
