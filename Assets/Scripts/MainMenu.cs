using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    [SerializeField] private AudioSource selectSound;

    public void PlayGame() {
        Selected();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carga la siguiente escena (La del juego)
    }

    public void SwithMenuOrOptions(){

        Selected();

        if (mainMenu.activeSelf == true){
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
        } else{
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        
    }

    /// AGREGAR ARRAY CON EL QUE SE HARÁ LA PAGINACION CON LAS INSTRUCICONES DEL JUEGO

    public void QuitGame(){
        Selected();
        Application.Quit();
    }

    public void Selected(){
        
        selectSound.Play();
    }
}
