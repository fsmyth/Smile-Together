using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(TimerCoroutine());
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        Destroy(gameObject); 
        }
    }

    IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        }
}
