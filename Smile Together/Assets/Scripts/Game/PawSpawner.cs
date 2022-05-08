using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawSpawner : MonoBehaviour
{

    public GameObject paw;
    public GameObject spawnerL;
    public GameObject spawnerR;
    public GameObject target;


    [SerializeField] private Camera myCamera;
    [SerializeField] private LayerMask layerMask;

    bool leftBusy = false;
    bool rightBusy = false;

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask)) {
            target.transform.position = raycastHit.point;
            // Debug.Log(raycastHit.point);
        }
            if(!leftBusy) {
                Instantiate(target);
                leftBusy = true;
                Instantiate(paw, spawnerL.transform.position, Quaternion.identity);
                // StartCoroutine(FreeCoroutine("Left")); 
            } else if (!rightBusy) {
                Instantiate(target);
                rightBusy = true;
                Instantiate(paw, spawnerR.transform.position, Quaternion.identity); 
                // StartCoroutine(FreeCoroutine("Right")); 
            }
        }
    }

    // IEnumerator FreeCoroutine(string side)
    // {
    //     yield return new WaitForSeconds(2);
    //     if (side=="Left") {
    //         LeftFree();
    //     } else if (side=="Right") {
    //         RightFree();
    //     }
    // }

    public void LeftFree() {
        leftBusy = false;
    }

    public void RightFree() {
        rightBusy = false;
    }

    public void Free() {
            LeftFree();
            RightFree();

    }
}
