using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeadMenu : MonoBehaviour
{

   
    public GameObject deadMenu;
    private bool isDead;
    private ScoreController highscore;
    private TMP_Text highscoreText;
    [SerializeField] private GameObject congrats;
    

    private void Start() {
       
        isDead = false;
        highscore = GameObject.FindWithTag("score").GetComponent<ScoreController>();
        highscoreText = GameObject.FindWithTag("highscore").GetComponent<TMP_Text>();
        
    }

    private void Update() {
  
        if (isDead){

            deadMenu.SetActive(true);

             if (highscore.IsNewHighScore){
                congrats.SetActive(true);
            } else{
                congrats.SetActive(false);
            }

            if (highscore != null && highscoreText != null){
                
                highscoreText.text = highscore.HighScore.ToString();
            }

        }else{
            deadMenu.SetActive(false);
        }

    }

    public void RestartGame() {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Carga la escena actual

        ScoreController score = GameObject.FindWithTag("score").GetComponent<ScoreController>();

        if (score != null){

            if (highscore != null){
                score.ResetScore();
            } else {
                score.ResetScore();
            }
            
        }
    }

    public void  BackToMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // Carga la escena anterior
    }

    public void setDeath(bool _isDead){
        this.isDead = _isDead; // Cambiar el estado de muerte segun el parametro entrante
    }
}
