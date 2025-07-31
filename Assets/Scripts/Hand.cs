using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public DragObject drag;
    public enum hand{
        Left,Right
    }
    public hand h;
     private void OnTriggerEnter(Collider other) {
        drag.selectedObject = other.gameObject;
        drag.h = h;
    }
    private void OnTriggerExit(Collider other) {
        drag.selectedObject = null;
    }
}
