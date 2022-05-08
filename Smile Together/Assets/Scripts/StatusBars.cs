using UnityEngine;
using UnityEngine.UI;
public class StatusBars : MonoBehaviour
{
  public Image healthBar;
  public Image hungerBar;
  public Image funBar;
  public Image energyBar;

  int health;
  int hunger;
  int fun;
  int energy;
  public PetStatus petStatus;
  
  void Update() {
    health = petStatus.getStatus("health");
    hunger = petStatus.getStatus("hunger");
    fun = petStatus.getStatus("fun");
    energy = petStatus.getStatus("energy");

    if(health>100) {health = 100;}
    else if(health<0) {health = 0;} 
    if(hunger>100) {hunger = 100;}
    else if(hunger<0) {hunger = 0;} 
    if(fun>100) {fun = 100;}
    else if(fun<0) {fun = 0;} 
    if(energy>100) {energy = 100;}
    else if(energy<0) {energy = 0;}

    healthBar.fillAmount = Mathf.Clamp(health / 100f, 0, 1f);
    hungerBar.fillAmount = Mathf.Clamp(hunger / 100f, 0, 1f);
    funBar.fillAmount = Mathf.Clamp(fun / 100f, 0, 1f);
    energyBar.fillAmount = Mathf.Clamp(energy / 100f, 0, 1f);
  }
}
