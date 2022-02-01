using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light;
    public Renderer board;
    private float dimValue;
    private bool increase = false;
    private Color currColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        dimValue = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (increase) {
            dimValue += .001f;
        } else {
            dimValue -= .001f;
        }
        if (dimValue < -.5) {
            increase = true;
        }
        if (dimValue > 1.5) {
            increase = false;
        }

        light.intensity = dimValue;

        changeBoardColor();
    }

    void changeBoardColor() {
        currColor.r = dimValue;
        currColor.g = dimValue;
        currColor.b = dimValue;
        board.material.color = currColor;
    }
}
