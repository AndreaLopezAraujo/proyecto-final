using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePrimitive : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        float scaleValX = this.transform.localScale.x;
        float scaleValY = this.transform.localScale.z;

        float centerX = Random.Range(0.0f, 1.0f);
        float centerY = Random.Range(0.0f, 1.0f);
        float spreadLim = Random.Range(0.5f, 0.9f);

        Debug.Log(scaleValX);

        this.GetComponent<MeshRenderer>().material.SetFloat("_ScaleX", scaleValX);
        this.GetComponent<MeshRenderer>().material.SetFloat("_ScaleY", scaleValY);
        this.GetComponent<MeshRenderer>().material.SetFloat("_centerX", centerX);
        this.GetComponent<MeshRenderer>().material.SetFloat("_centerY", centerY);
        this.GetComponent<MeshRenderer>().material.SetFloat("_SpreadLim", spreadLim);
        this.GetComponent<MeshRenderer>().material.SetFloat("_OffsetY", Random.Range(0.0f, 1.0f));
        this.GetComponent<MeshRenderer>().material.SetFloat("_mySlider", 6.3f);
    }

    // Update is called once per frame
    void Update()
    {



    }

}
