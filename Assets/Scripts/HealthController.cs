using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    [SerializeField] private Player player;
    private Image blackBar, healthBar;

    private void Start() {

        GetBars();

        player.onHealthChangedCallback = UpdateHealthHud;
       
        if (blackBar != null && healthBar != null){
            UpdateHealthHud();
        }
    }

    private void GetBars(){

        Image[] bars = this.transform.GetComponentsInChildren<Image>();;

        if (bars != null){

            for (int i = 0; i<bars.Length; i++){
                if (bars[i].name == "HealthBarTotal"){
                 
                    this.blackBar = bars[i];

                } else if (bars[i].name == "HealthBarTotalActual"){
            
                    this.healthBar = bars[i];

                }
            }
        }
    }

    public void UpdateHealthHud(){
        FillBlackBar();
        FillHealthBar();
    }

    private void FillBlackBar(){

         if (this.blackBar != null){
           
            this.blackBar.fillAmount = player.MaxHealth / 10;
       }
    }

    private void FillHealthBar(){

        if (this.healthBar != null){
           
            this.healthBar.fillAmount = player.Health / 10;
       }
    }
}
