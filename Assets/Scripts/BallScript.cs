using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BallScript : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI ScoreValue;
   // public GameObject winTextObject;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
       // winTextObject.SetActive(false);
    }

    // private void OnMove(InputValue movementValue)
    // {
    //     Vector2 movementVector = movementValue.Get<Vector2>();

    //     movementX = movementVector.x;
    //     movementY = movementVector.y;
    // }

    private void setCountText()
    {
        ScoreValue.text = "Count: "+ count.ToString();
        if(count >= 13){
           // winTextObject.SetActive(true);
        }
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
