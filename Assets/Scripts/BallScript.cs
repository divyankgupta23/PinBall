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
        }
    }

    private void startNewGame()
    {
        NewGame.gameObject.SetActive(false);
        WinText.text = "";
        timeRemaining = 10;
        count = 0;
        Debug.Log("new");
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
            setCountText();
        }
        
    }
}
