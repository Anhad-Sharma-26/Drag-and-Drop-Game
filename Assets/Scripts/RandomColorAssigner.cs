using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorAssigner : MonoBehaviour
{
    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        if(colors.Length != null && colors.Length > 0)
        {
            Color chosenColor = colors[Random.Range(0, colors.Length)];

            Renderer renderer = GetComponent<Renderer>();
            if(renderer != null)
            {
                renderer.material = new Material(renderer.material);
                renderer.material.color = chosenColor;
            }
        }
    }

    /*// Update is called once per frame
    void Update()
    {
        
    }*/
}
