using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    public float maxSize;
    public float groupRate;
    public float scale=0.0f;
    public float iterations;
    public float actual=0;
    // Start is called before the first frame update
    void Start()
    {
         maxSize=Random.Range(1.5f,2.5f);
         groupRate=Random.Range(0.03f,0.05f);
         iterations=Random.Range(1200f,2000f);
         this.transform.localScale = new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update()
    {
        actual++;
        if(scale<maxSize&& iterations<actual)
        {
            this.transform.localScale = new Vector3(1,1,1)*scale;
            float time=Time.deltaTime;
            scale+=groupRate*time;
        }
    }
}
