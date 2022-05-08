using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedHead : MonoBehaviour
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
            comment.text="that's nice";
            anim.Play("Pet");
            textAnim.Play("ChatTextFade");
        }
        
    }
}
