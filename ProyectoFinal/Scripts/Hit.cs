using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Vector3 worldPosition;
    public GameObject prefab;

    public float brushRadius = 2.0F;

    void OnGUI()
    {
        brushRadius = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), brushRadius, 0.0F, 10.0F);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked();
        }


    }

    void Clicked()
    {
        /* var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         RaycastHit hit = new RaycastHit();

         if (Physics.Raycast(ray, out hit))
         {
             Vector3 mousePos = Input.mousePosition;
             mousePos.z = Camera.main.nearClipPlane;
             Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
         }*/

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
            Debug.Log(hitData.collider.gameObject.transform.rotation);
            //prefab.transform.localPosition = worldPosition;
            //float scaleVal = Random.Range(1.0f, 5.0f);

            //prefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitData.normal);
            GameObject mossClone = Instantiate(prefab, worldPosition, Quaternion.FromToRotation(Vector3.up, hitData.normal));
            mossClone.transform.localScale = new Vector3(brushRadius, brushRadius, 1);
            mossClone.transform.Rotate(90, 0, 0);
            Vector3 objectPos = mossClone.transform.position;
            objectPos.x += 0.0001f;
            mossClone.transform.position = objectPos;
            mossClone.GetComponent<MeshRenderer>().material.SetFloat("_NoiseSize", Random.Range(0.8f, 0.95f));
            mossClone.GetComponent<MeshRenderer>().material.SetFloat("_OffsetX", Random.Range(0.0f, 1.0f));
            mossClone.GetComponent<MeshRenderer>().material.SetFloat("_OffsetY", Random.Range(0.0f, 1.0f));

        }

    }
}
