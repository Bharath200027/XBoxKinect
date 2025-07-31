using UnityEngine;
using System.Collections;

public class WebTexture_AR : MonoBehaviour
{
    WebCamTexture webcamTexture;
    //WebCamDevice[] devices = WebCamTexture.devices;
    // Gets the list of devices and prints them to the console.
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        //webcamTexture.Play();
        //for (int i = 0; i < devices.Length; i++)
        //    Debug.Log(devices[i].name);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            webcamTexture.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            webcamTexture.Play();
        }
    }


}