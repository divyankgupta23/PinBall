using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamage = 150f;
    HingeJoint hingeJoint;
    public string inputName;
    public float timer = 0f;
    public float growTime = 6f;
    public float maxSize = 2f;

    public bool isMaxSize = false;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
        //Vector3 startSize = transform.localScale;

        if (isMaxSize == false)
        {
          StartCoroutine(Grow());
        }
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamage;

        if(Input.GetAxis(inputName) == 0){
            spring.targetPosition = restPosition;
        }
        else{
            spring.targetPosition = pressedPosition;
        }

        hingeJoint.spring = spring;
        hingeJoint.useLimits = true;
    }

    private IEnumerator Grow()
    {
       Vector3 size = transform.localScale;
       Vector3 maxScale = new Vector3(size.x - 1f, size.y, size.z );

      do{
        transform.localScale = Vector3.Lerp(maxScale , size , timer / growTime);
        timer += Time.deltaTime;
        yield return null;

      }
      while(timer < growTime);

      isMaxSize = true;
    }
}
