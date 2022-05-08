using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawSwipe : MonoBehaviour
{
    public GameObject paw;
    public BoxCollider pawCol;
    public GameObject spawner;
    public Spawner spawn;
    public PawSpawner pawSpawner;
    public AudioSource pawdio;
    GameObject targetObj;
    Transform target;
    float speed = 20f; 

    void Awake() {
    targetObj = GameObject.FindGameObjectWithTag("Target");
    spawner = GameObject.FindGameObjectWithTag("Spawner");
    target = targetObj.transform;
    transform.LookAt(target);
    spawn=spawner.GetComponent<Spawner>();
    pawSpawner=spawner.GetComponent<PawSpawner>();
    }
    void Update()
    {
            transform.position += transform.forward*speed*Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit!");
            pawdio.Play();
            Destroy(pawCol);
            Destroy(targetObj);
            pawSpawner.Free();
            spawn.MouseCatch();
            Destroy(paw);
        } else if (other.CompareTag("Target") || other.CompareTag("EndBox") )
        {
            Debug.Log("Miss!");
            StartCoroutine(ReverseCoroutine());
        }
    }

    IEnumerator ReverseCoroutine()
    {
        speed=speed*-1f;
        // Destroy(pawCol);
        Destroy(targetObj);
        yield return new WaitForSeconds(1);
        pawSpawner.Free();
        Destroy(paw);
    }
}
