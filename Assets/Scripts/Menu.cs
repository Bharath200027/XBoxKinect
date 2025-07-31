using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject[] menuObjs;
    public GameObject zoom,rotate;
    public bool activate = false;
    private void OnTriggerExit(Collider other) {
        if(activate){
            foreach(GameObject obj in menuObjs){
                obj.SetActive(false);
                activate =!activate;
            }
        }else{
            rotate.SetActive(true);
            activate = !activate;    
        }
    }
}
