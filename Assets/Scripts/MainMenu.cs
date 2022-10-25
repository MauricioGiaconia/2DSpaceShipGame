using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public void PlayGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Carga la siguiente escena (La del juego)
    }

    public void SwithMenuOrOptions(){

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
        Application.Quit();
    }
}
