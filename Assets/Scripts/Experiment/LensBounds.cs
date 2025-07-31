using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LensBounds : MonoBehaviour
{
    public Slider slider;

    public float min_x = -10f;
    public float max_x = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        
      this.transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x,min_x ,max_x), this.transform.localPosition.y, this.transform.localPosition.z);

    }

    public void ApplyPosition()
    {
        this.transform.localPosition = new Vector3(slider.value, this.transform.localPosition.y, this.transform.localPosition.z);

    }
}
