using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{

   
    public GameObject deadMenu;
    private bool isDead;
    

    private void Start() {
       
        isDead = false;
        
    }

    private void Update() {
  
        if (isDead){
            deadMenu.SetActive(true);
        }else{
            deadMenu.SetActive(false);
        }

    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Carga la escena actual
    }

    public void  BackToMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Carga la escena anterior
    }

    public void setDeath(bool _isDead){
        this.isDead = _isDead; // Cambiar el estado de muerte segun el parametro entrante
    }
}
