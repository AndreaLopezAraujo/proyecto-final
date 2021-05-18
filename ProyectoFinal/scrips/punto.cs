using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punto : MonoBehaviour
{
     Renderer m_Renderer;

    void Start()
    {
        //Fetch the Renderer component of the GameObject
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.color = Color.cyan;
    }
}