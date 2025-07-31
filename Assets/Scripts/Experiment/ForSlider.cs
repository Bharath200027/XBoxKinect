using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForSlider : MonoBehaviour
{

    
    public Slider forMovement;
    public float speed = 0.01f;
    private float oldValue;
    // Start is called before the first frame update
    void Start()
    {
        oldValue = forMovement.value;
    }

    // Update is called once per frame
    void Update()
    {
        float difference = oldValue - forMovement.value;

            //transform.localPosition = new Vector3(transform.localPosition.x + forMovement.value * speed, transform.localPosition.y, transform.localPosition.z);
            transform.Translate(difference * speed * forMovement.value, 0, 0, Space.World);
            oldValue = forMovement.value;

        //else if (oldValue - forMovement.value > 0)
        //{

        //    transform.localPosition = new Vector3(transform.localPosition.x - forMovement.value * speed, transform.localPosition.y, transform.localPosition.z);
        //    oldValue = forMovement.value;
        //}

        

    }
}
