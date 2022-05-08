using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Animator anim;
    public Animator textAnim;
    public PetStatus petStatus;
    public Text comment;
    int hunger;
    int health;

//////////////////////////////////// FEEDING SECTION

    public void feedMeFish()
    {
            hunger = petStatus.getStatus("hunger");
            if(hunger<90) {
            comment.text = "Yum!";
            } else {
            comment.text = "Too much!";
            }
            textAnim.Play("ChatTextFade");
            anim.Play("feedPet");
            petStatus.feedPet("Fish");
    }

    public void feedMeMeat()
    {
            comment.text = "Blegh!";
            textAnim.Play("ChatTextFade");
            anim.Play("feedPetMeat");
            petStatus.feedPet("Meat");
    }

    public void feedMeCheese()
    {
            comment.text = "Blegh!";
            textAnim.Play("ChatTextFade");
            anim.Play("feedPetCheese");
            petStatus.feedPet("Cheese");
    }

////////////////////////////////////// CARE SECTION
    public void giveMeMedicine()
    {
            health = petStatus.getStatus("health");
            if(health<=50) {
            comment.text = "Thank you...";
            } else {
            comment.text = "Blegh!";
            }
            textAnim.Play("ChatTextFade");
            anim.Play("givePetMeds");
            petStatus.givePet("Meds");
    }
    public void giveMeComb()
    {
            comment.text = "Ahh...";
            textAnim.Play("ChatTextFade");
            anim.Play("givePetComb");
            petStatus.givePet("Comb");
    }
}
