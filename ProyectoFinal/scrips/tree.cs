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
         maxSize=Random.Range(0.3f,1.5f);
         groupRate=Random.Range(0.1f,0.3f);
         iterations=Random.Range(100f,1300f);
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
