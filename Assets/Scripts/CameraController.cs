using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
 
    [Header("Populate In Inspector")]
    [Tooltip("0 is default, 1 is Top, 2 Left, 3 Right")]
    public Transform[] views;
    public GameObject rotatebutton;
    public GameObject[] rotateButtons;
    public float FOVMin;
    public float FOVMax;
    public float zoomFactor;

    

    public GameObject table;
    [Tooltip("Time between tweening")]
    public float transitionTime;

    public GameObject activeCam;

    [Header("DEBUG")]
    Vector3 tablerotation;
    public int active = 0;
    public float fov;
    bool rotating = false;bool switching = false;
    bool zoomactive = false, rotateactive = false, nothingSelected = true;
    void Start()
    {
        fov = activeCam.GetComponent<Camera>().fieldOfView;
        tablerotation = new Vector3(0, 60, 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCamera(views[0]);
        }
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
        }

    }
    public void Interact(GameObject interactable)
    {
            string tag = interactable.name;
            switch (tag)
            {
                case "Rotate":
                    
                    foreach(GameObject obj in rotateButtons){
                        obj.SetActive(true);
                        
                    }
                    break;
                case "Rotate Left":
                    RotateCamera(90);
                    nothingSelected = false;
                    break;

                case "Rotate Right":
                    RotateCamera(-90);
                    nothingSelected = false;
                    break;
                case "Zoom In":
                    Zoom(+1);
                    nothingSelected = false;
                    break;
                case "Zoom Out":
                    Zoom(-1);
                    nothingSelected = false;
                    break;
                case "TopView":
                    Deactivate();
                    SwitchCamera(views[1]);
                break;
                case "DefaultView":
                    Deactivate();
                    SwitchCamera(views[0]);

                break;
                case "LeftView":
                    Deactivate();
                    SwitchCamera(views[2]);

                break;
                case "RightView":
                    Deactivate();
                    SwitchCamera(views[3]);
                break;


            
        }
    }
    void Deactivate(){
        Debug.Log("Deactivating");
        foreach(GameObject obj in rotateButtons){
                        obj.SetActive(false);
                        
        }
    }
    public void SwitchCamera(Transform t)
    {
        if (!switching)
        {
            StartCoroutine("SwitchCameraC",t);
        }
    }
    IEnumerator SwitchCameraC(Transform pos)
    {
        switching = true;
        LeanTween.move(activeCam,pos.position,transitionTime);
        LeanTween.rotate(activeCam,pos.rotation.eulerAngles,transitionTime);
        yield return new WaitForSeconds(2f);
        switching = false;
    }
    public void RotateCamera(float rot)
    {
        //        Debug.Log(rot);
        if (!rotating)
        {

            StartCoroutine("RotateTable", rot);
        }
    }
    public void Zoom(int i)
    {
        fov = Mathf.Clamp(fov + (i * zoomFactor), FOVMin, FOVMax);
        activeCam.GetComponent<Camera>().fieldOfView = fov;
    }
    IEnumerator RotateTable(float rot)
    {

        rotating = true;

        tablerotation.y += rot;

        if (tablerotation.y < 0)
        {
            tablerotation.y += 360;

        }
        if (tablerotation.y > 360)
        {
            tablerotation.y %= 360;
        }
        Debug.Log("Rotating" + tablerotation.y);
        table.LeanRotate(tablerotation, 2f);
        yield return new WaitForSeconds(2f);
        rotating = false;
    }

}
