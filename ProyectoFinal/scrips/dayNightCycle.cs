using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightCycle : MonoBehaviour
{
    // Start is called before the first frame update
    public int rotationScale=50;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationScale*Time.deltaTime,0,0);
    }
}
