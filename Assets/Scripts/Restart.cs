using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

   
    public GameObject restartButton;
    private bool isDead;
    

    private void Start() {
       
        isDead = false;
    }
    private void Update() {
        
       
        if (isDead){
            restartButton.SetActive(true);
        }else{
            restartButton.SetActive(false);
        }

    }

    public void RestartGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Carga la escena actual
    }

    public void setDeath(bool _isDead){
        this.isDead = _isDead;
    }
}
