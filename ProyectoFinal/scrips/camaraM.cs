using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraM : MonoBehaviour
{
    public float speedH;
    public float speedV;
    float yam;
    float xyam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                yam+=speedH*Input.GetAxis("Mouse X");
                xyam-=speedV*Input.GetAxis("Mouse Y");
                transform.eulerAngles=new Vector3(xyam,yam,0);
    }
}
