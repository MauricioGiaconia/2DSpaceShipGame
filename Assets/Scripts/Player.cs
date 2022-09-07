using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;
    [SerializeField] private float health = 3f,
    maxHealth = 3f,
    maxTotalHealth = 10f;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    [SerializeField] private GameObject deathEffect;
    private Color originalColor;

    //Color rojo para indicar cuando la nave del jugador recibe daño
    private Color hitColor = new Color(1, 0, 0, 1);

    private float changeToNormalColor = 0.25f, waitToChange = 0f;
    private bool hitted = false;

    private DeadMenu restartButton;

    //Variable para saber si el jugador esta afectado por un buff o nerf
    private bool affectedByItem = false;

    public bool AffectedByItem {get {return this.affectedByItem;}
                                set {this.affectedByItem = value;}}
    
    private void Start() {

        originalColor = this.GetComponent<Renderer>().material.color;
        restartButton = FindObjectOfType<DeadMenu>();
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

    public void Heal(float health)
    {
        if (health < maxHealth){
            this.health += health;
            ClampHealth();
        }
        
    
    }

        
    public void TakeDamage(float dmg){

        health -= dmg;

        if (health <= 0f){
            Die();
        } else{
           
           hitted = true;

        }

        ClampHealth();
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }   
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

    void Die(){

      

        Instantiate(deathEffect, this.transform.position, Quaternion.identity);

        Destroy(this.gameObject);

        if (restartButton != null){
            restartButton.setDeath(true);
        }
    }
    
}
