using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraM : MonoBehaviour
{
    public float speedH;
    public float speedV;
    float yam;
    float xyam;
    private float ScrollSpeed = 10;

    private Camera ZoomCamara;

    public float max;

    public float min;
    private Vector3 initialPos;
    private bool restrictCamera = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, -90, 0);
        ZoomCamara = Camera.main;
        initialPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            if (restrictCamera) { 
            restrictCamera = false;
            }
            else 
            {
                restrictCamera = true;
            }
        }
        if (restrictCamera) { 
        yam += speedH * Input.GetAxis("Mouse X");
        xyam -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(xyam, yam - 90, 0);
        }   
        float val = ZoomCamara.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
            
        if (val < max && val >= min)

        {
            ZoomCamara.fieldOfView = val;

        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {

            Camera.main.transform.position = Camera.main.transform.position + new Vector3(-0.3f,0,0);

        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

            Camera.main.transform.position = Camera.main.transform.position + new Vector3(0.3f, 0, 0);

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Camera.main.transform.position = Camera.main.transform.position + new Vector3(0, 0, -0.3f);

        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            Camera.main.transform.position = Camera.main.transform.position + new Vector3(0, 0, 0.3f);

        }
        if (Input.GetKey(KeyCode.Space))
        {

            Camera.main.transform.position = Camera.main.transform.position + new Vector3(0, 0.3f, 0);

        }
        if (Input.GetKey(KeyCode.LeftControl)|| Input.GetKey(KeyCode.RightControl))
        {

            Camera.main.transform.position = Camera.main.transform.position + new Vector3(0, -0.3f, 0);

        }

        if (Input.GetKey(KeyCode.Tab))
        {

            Camera.main.transform.position = initialPos;

        }
    }
}
