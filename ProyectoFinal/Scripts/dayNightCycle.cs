using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightCycle : MonoBehaviour
{
    // Start is called before the first frame update
    public int rotationScale=100;
    public int numero=1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //rotationScale+=10*numero;
        transform.Rotate(rotationScale*Time.deltaTime,0,0);
        numero+=1;
    }
}
