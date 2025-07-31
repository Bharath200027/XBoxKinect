using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRaycast : MonoBehaviour
{
    public Material LineRendererMaterial;
    LineRenderer Ray;
    public GameObject StartPointObject;
    
    public GameObject EndPointObject;
    float count = 0;
    float distance = 0;
    float linedrawspeed = 20f;

    public float timeToSetOFF = 20f;
    float time = 0f;

    GameObject LineRendererObject;

    public GameObject ObjectToEnable;

    private bool temp = false;

    private void Awake()
    {
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        LineRendererObject = new GameObject();
        distance = Vector3.Distance(StartPointObject.transform.position, EndPointObject.transform.position);
        LineRendererObject.AddComponent<LineRenderer>();
        Ray = LineRendererObject.GetComponent<LineRenderer>();
        Ray.material = LineRendererMaterial;
        Ray.startColor = Color.yellow;
        Ray.endColor = Color.yellow;
        Ray.startWidth = 0.03f;
        Ray.endWidth = 0.03f;
        Ray.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        if (ObjectToEnable != null)
        {
            ObjectToEnable.SetActive(false);
        }
        Ray.SetPosition(0, StartPointObject.transform.position);
        Ray.SetPosition(1, StartPointObject.transform.position);
        
    }
    private void LateUpdate()
    {
        Ray.SetPosition(0, StartPointObject.transform.position);

    }
    private void Update()
    {

        time += Time.deltaTime;
        distance = Vector3.Distance(StartPointObject.transform.position, EndPointObject.transform.position);
        if (count < distance)
        {
            count += 0.1f / linedrawspeed;
            float x = Mathf.Lerp(0, distance, count);
            Vector3 A = StartPointObject.transform.position;
            Vector3 B = EndPointObject.transform.position;

            Vector3 PAL = x * Vector3.Normalize(B - A) + A;
            Ray.SetPosition(1, PAL);
            if (PAL == EndPointObject.transform.position)
            {
                if (ObjectToEnable != null)
                {
                    ObjectToEnable.SetActive(true);
                    //temp = true;
                }
            }
            //Debug.Log(count); 
        }
        if (time >= timeToSetOFF)
        {
            Ray.enabled = false;
        }

    }
    //void DrawLine(Vector3 start, Vector3 end, Color color)
    //{
    //    GameObject myLine = new GameObject();
    //    myLine.transform.position = start;
    //    myLine.AddComponent<LineRenderer>();
    //    LineRenderer lr = myLine.GetComponent<LineRenderer>();
    //    lr.material = LineRendererMaterial;
    //    lr.startColor = color;
    //    lr.endColor = color;
    //    lr.startWidth = 0.03f;
    //    lr.endWidth = 0.03f;
    //    lr.SetPosition(0, start);
    //    lr.SetPosition(1, end);
    //}

    //IEnumerator DrawlineEnumerator(Vector3 start, Vector3 end, Color color)
    //{
    //    GameObject myLine = new GameObject();
    //    myLine.AddComponent<LineRenderer>();
    //    LineRenderer lr = myLine.GetComponent<LineRenderer>();
    //    while (count < 0.003)
    //    {
    //        //GameObject myLine = new GameObject();
    //        //myLine.transform.position = start;
    //        //myLine.AddComponent<LineRenderer>();
    //        //LineRenderer lr = myLine.GetComponent<LineRenderer>();
    //        //lr.material = LineRendererMaterial;
    //        //lr.startColor = color;
    //        //lr.endColor = color;
    //        //lr.startWidth = 0.03f;
    //        //lr.endWidth = 0.03f;
    //        //lr.SetPosition(0, start);
    //        //lr.SetPosition(1, end);
            
    //        Vector3 newStart = start - end;
    //        Vector3 newStartNormalized = Vector3.Normalize(newStart);
    //        myLine.transform.position = start + (newStartNormalized * count * 0.001f);
    //        count = count + 0.001f;
    //        lr.material = LineRendererMaterial;
    //        lr.startColor = color;
    //        lr.endColor = color;
    //        lr.startWidth = 0.03f;
    //        lr.endWidth = 0.03f;
    //        lr.SetPosition(0, newStart);
    //        lr.SetPosition(1, myLine.transform.position);
    //        yield return new WaitForSeconds(0.02f);
    //    }
    //}
}
