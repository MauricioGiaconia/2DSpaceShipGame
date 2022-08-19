using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 3;
    [SerializeField] private GameObject deathEffect;
    private Color originalColor;

    //Color rojo para indicar cuando la nave del jugador recibe daño
    private Color hitColor = new Color(1, 0, 0, 1);

    private float changeToNormalColor = 0.25f, waitToChange = 0f;
    private bool hitted = false;

    public GameObject restartButton;
    
    private void Start() {
        originalColor = this.GetComponent<Renderer>().material.color;
    }

    private void Update() {
        
        
        //Si la nave fue golpeada entonces se cambia el color de la nave
        if (hitted){

            this.GetComponent<Renderer>().material.color = hitColor;

            //La duracion del color nuevo es changeToNormalColor, una vez cumplida la duracion
            //la nave regresara a su color original
            if (changeToNormalColor > waitToChange){

                waitToChange += Time.deltaTime;
               
            } else{
                waitToChange = 0f;
                this.GetComponent<Renderer>().material.color = originalColor;
                hitted = false;
            }

           
        }
    }
        
    public void takeDamage(int dmg){

        health -= dmg;

        if (health <= 0){
            Die();
        } else{
           
           hitted = true;
  
        }
    }

    void Die(){

        Restart reset = restartButton.GetComponent<Restart>();

        Instantiate(deathEffect, this.transform.position, Quaternion.identity);

        Destroy(this.gameObject);

        if (reset != null){
            reset.setDeath(true);
        }

        
    }
    
}
