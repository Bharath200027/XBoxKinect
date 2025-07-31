using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
public class Buttons : MonoBehaviour
{
    
    public GameObject[] childButtons;
    public ParticleSystem[] particles;
    public Vector3 originalScale;
    private void Start() {
        originalScale = transform.localScale;
    }
    private void OnTriggerEnter(Collider other) 
    {
        
       foreach(ParticleSystem particle in particles){
            Debug.Log("toggling Particle Systems..");
            particle.Play(true);
        }
        LeanTween.scale(gameObject,gameObject.transform.localScale*1.2f,.5f);
        foreach(GameObject buttons in childButtons){
            buttons.SetActive(true);
        }
        //gameObject.SetActive(false);
    }
    private void OnTriggerExit(Collider other) {
        LeanTween.scale(gameObject,originalScale,.5f);
        
        foreach(ParticleSystem particle in particles){
            particle.Stop(true);
            
        }

    }
}
