using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayVisualiser : MonoBehaviour
{
    public GameObject ConvergeTarget;
    public GameObject PointOnLens;
    public float RayLength;
    //public GameObject ObjectToEnable;
    private Ray ray = new Ray();
    private LineRenderer lr;
    private Vector3 endPoint;

    //public float timeToSetOFF = 20f;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
        lr.enabled = true;
        lr.startWidth = 0.03f;
        lr.endWidth = 0.02f;
        lr.positionCount = 2;
        //if (ObjectToEnable != null)
        //{
        //    ObjectToEnable.SetActive(true);
        //    //temp = true;
        //}
        ray.origin = PointOnLens.transform.position;
        ray.direction = ConvergeTarget.transform.position - PointOnLens.transform.position;
        endPoint = ray.GetPoint(RayLength);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        lr.SetPosition(0, PointOnLens.transform.position);
        lr.SetPosition(1, endPoint);
        ray.origin = PointOnLens.transform.position;
        ray.direction = ConvergeTarget.transform.position - PointOnLens.transform.position;
        endPoint = ray.GetPoint(RayLength);
        //if (time >= timeToSetOFF)
        //{
        //    lr.enabled = false;
        //}

    }

    public void quit()
    {
        Application.Quit();
    }
}
