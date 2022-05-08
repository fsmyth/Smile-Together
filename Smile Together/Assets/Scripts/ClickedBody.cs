using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedBody : MonoBehaviour
{
    public Text comment;
    public Animator anim;
    public Animator textAnim;
    void Update()
    {
   }

    void OnMouseDown() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            comment.text="that tickles!";
            anim.Play("tickle");
            textAnim.Play("ChatTextFade");
        }
        
    }
}
