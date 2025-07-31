using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConvexSetValue : MonoBehaviour
{

    public Transform focalLength, convexLens;
    public Vector3 oldPos;
    public float threshold = 0f;
    public bool isFocused = false;
    public bool locked = false;
    public string firstInstruction = "Move the lens across the table such that you get a sharp image. ";

    // Start is called before the first frame update
    void Start()
    { 
        GetComponent<MeshRenderer>().sharedMaterial.SetFloat("radius", 0f);
        oldPos = convexLens.position;
       
    }

    // Update is called once per frame
    void Update()
    {

        if ((convexLens.position.z >= (focalLength.position.z) && convexLens.position.z <= (focalLength.position.z + threshold))
            || (convexLens.position.z <= (focalLength.position.z) && convexLens.position.z >= (focalLength.position.z - threshold)))
        {
            isFocused = true;
            locked = !locked;

        }
        else
        {
            isFocused = false;
            locked = !locked;

        }

        if (isFocused)
        {
            if (!locked)
            {
                GetComponent<MeshRenderer>().sharedMaterial.SetFloat("radius", 0f);
                locked = true;                
            }
        }
        else 
        {
            if (!locked)
            {
                GetComponent<MeshRenderer>().sharedMaterial.SetFloat("radius", 30f);
                locked = true;
               
                
            }
        }


    }
}