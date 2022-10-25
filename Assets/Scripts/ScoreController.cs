using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public int enemyPoints = 100;
    private int score = 0, highscore;
    private bool isNewHighscore = false;
    [SerializeField] private TMPro.TextMeshProUGUI textScore;

    public int HighScore{get{ return this.highscore; }}
    public bool IsNewHighScore{get{ return this.isNewHighscore; }}

    private void Start() {

        this.highscore = PlayerPrefs.GetInt("HighScore");
        
        this.ResetScore();
    }

    private void Update() {
    
    }

    public void AddScore(){

        this.score += enemyPoints;

        if (this.score > this.highscore){
            SetNewHighscore(this.score);
        }

        
        this.textScore.text = this.score.ToString();
        
    }

    private void SetNewHighscore(int _score){

        this.isNewHighscore = true;
        this.highscore = _score;
        SaveHighScore();

    }

    public void ResetScore(){

        this.score = 0;
        this.isNewHighscore = false;

    }


    void SaveHighScore(){
         
        PlayerPrefs.SetInt("HighScore", highscore);
        PlayerPrefs.Save();
    }
}
