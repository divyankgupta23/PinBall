using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShakeManager : MonoBehaviour
{
    private Vector3 startPos , shakePos;
    public float speed , amount , duration, defaultDuration = 10;
    // Start is called before the first frame update
    void Start()
    {
      shakePos = startPos = transform.position;
      speed = 20;
      amount = 5;
      duration = defaultDuration;
    }
    // Update is called once per frame
    void Update()
    {
      if (duration > 0 && duration < 5){
        Shake();
        duration -= Time.deltaTime;
      } else {
        transform.position = Vector3.MoveTowards(transform.position , startPos , Time.deltaTime * Mathf.Abs(speed));
      }

      if(duration <= 0){
          duration = defaultDuration;
      }
      duration -= Time.deltaTime;
    }
    void Shake(){
      if (transform.position == shakePos){
        shakePos=startPos + new Vector3(Random.Range(-amount , amount) , Random.Range(-amount , amount) , 0);
      }else{
        transform.position = Vector3.MoveTowards(transform.position , shakePos , Time.deltaTime * Mathf.Abs(speed));
      }
    }
}