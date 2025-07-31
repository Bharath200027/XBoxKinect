using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class MenuTrigger : MonoBehaviour
{
    public Vector3 init,finalpos;
    public GameObject menu;
    bool active = false;
    private void OnTriggerExit(Collider other) {
        if(active){
        LeanTween.move(menu,finalpos,1f).setEaseInOutElastic();
        
        }else{
            LeanTween.move(menu,init,1f).setEaseInOutElastic();
        }
        active =!active;
    }

}
