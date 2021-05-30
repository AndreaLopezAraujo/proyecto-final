using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExplosionController : MonoBehaviour
{
    public int explosionCount = 0;
    public List<GameObject> destroyableObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("explosion"))
        {

            destroyableObjects.Add(fooObj);
        }

        StartCoroutine("ExplodeSequence");
    }

    IEnumerator ExplodeSequence()
    {
        DestroySetOfObjects(10);
        yield return new WaitForSeconds(15f);
        DestroySetOfObjects(10);
        yield return new WaitForSeconds(15f);
        DestroySetOfObjects(10);
        yield return new WaitForSeconds(15f);
        DestroySetOfObjects(10);
        yield return new WaitForSeconds(15f);
        DestroySetOfObjects(7);
    }

    public void DestroySetOfObjects(int numberToDestroy)
    {
        for (int i = 0; i < numberToDestroy; i++)
        {
            int itemIndex = Random.Range(0, (destroyableObjects.Count - 1));
            destroyableObjects[itemIndex].SendMessage("StartExplosion");
            destroyableObjects.Remove(destroyableObjects[itemIndex]);
        }
    }

    public void increaseExplosionCount()
    {
        explosionCount++;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        } 
    }
}
