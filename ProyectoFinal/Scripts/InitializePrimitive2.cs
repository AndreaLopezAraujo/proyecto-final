using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePrimitive2 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        float scaleValX = this.transform.localScale.x;
        float scaleValY = this.transform.localScale.z;

        Debug.Log(scaleValX);

        this.GetComponent<MeshRenderer>().material.SetFloat("_ScaleX", scaleValX);
        this.GetComponent<MeshRenderer>().material.SetFloat("_ScaleY", scaleValY);
    }

    // Update is called once per frame
    void Update()
    {



    }

}
