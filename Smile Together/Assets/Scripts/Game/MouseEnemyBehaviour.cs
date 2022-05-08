
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MouseEnemyBehaviour : MonoBehaviour
{

public GameObject mouseEnemy;
public CapsuleCollider mouseCol;
public Animator anim;
public float moveSpeed = 10f;
public AudioSource mouseAudio;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MouseCoroutine());
            mouseAudio.Play();
        } else if (other.CompareTag("MissBox")) {
            Destroy(mouseEnemy);
        }
    }

    IEnumerator MouseCoroutine()
    {
        Destroy(mouseCol);
        moveSpeed = 0f;
        anim.Play("MouseCatch");
        yield return new WaitForSeconds(1);
        Destroy(mouseEnemy);
    }
}
