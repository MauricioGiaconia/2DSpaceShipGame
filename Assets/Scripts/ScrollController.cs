using System.Collections;
 using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    private ScrollRect _scrollrect;

    // 35.772923076923076923076923076923f Multiplicador para la posicion que se mueve el scroll

    [SerializeField] private ScrollButton rightButton;
    [SerializeField] private ScrollButton leftButton;
    [SerializeField] private float scrollSpeed = 0.01f;
   

    private void Start() {

        _scrollrect = GetComponent<ScrollRect>();
        

    }


    //Pendiente: Sacar del Update el codigo que detecte si el boton fue apretado ¿Quizas hacer un callback desde el scrollbutton?
    
    private void Update() {

        
        if (leftButton != null){
             
            if (leftButton.isDown){
                
                ScrollLeft();
             
            } 
        }

        if (rightButton != null){
            if (rightButton.isDown){
               
                ScrollRight();
            
            } 
        }
        
  
    }

    public void ScrollLeft(){

        if (_scrollrect != null){
    
            if (_scrollrect.horizontalNormalizedPosition >= -0.37f){
                
                _scrollrect.horizontalNormalizedPosition += -scrollSpeed;
                
            }

        }
    }

    public void ScrollRight(){
        
        if (_scrollrect != null){
         
            if (_scrollrect.horizontalNormalizedPosition <= 1.3f){
                
                _scrollrect.horizontalNormalizedPosition += scrollSpeed;
               
            } 
                    
        }
    }

    public void SetToStart(){
        _scrollrect.horizontalNormalizedPosition = 0.45f;
    }

    
}
