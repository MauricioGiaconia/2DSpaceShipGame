using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffNerfSystem : MonoBehaviour
{

    /*

        *Modificar stats en los siguientes scripts:
            - Player
            - PlayerController
            - BulletController
            - ShootingController

            Suerte :D
    */

    [SerializeField] private float speed = 7f;
    [SerializeField] private GameObject impactEffect;
    private Vector2 movement;
    private float outOfScreen = -13f;

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(0, -(speed * Time.deltaTime));

        this.transform.Translate(movement);

        if (this.transform.position.y < outOfScreen){
            Destroy(this.gameObject);
        }
    }


    // Agregar timer para que se acabe el efecto y vuelva al estado normal. Duracion del buff: 5 segundos.
    IEnumerator BuffAttackSpeed(ShootingController[] _guns){

        float buff = 2f, time = 5f;
       

        for(int i = 0; i<_guns.Length; i++){
            _guns[i].FireRate = _guns[i].FireRate / buff;
        }


        yield return new WaitForSeconds(time);

        for(int i = 0; i<_guns.Length; i++){
            _guns[i].FireRate = _guns[i].FireRate * buff;
        } 

        Destroy(this.gameObject);
    }

    IEnumerator NerfSpeed(PlayerController _playerSpeed){

        float nerf = 1.5f, time = 3f;

        _playerSpeed.Speed = _playerSpeed.Speed / nerf;

        yield return new WaitForSeconds(time);

        _playerSpeed.Speed = _playerSpeed.Speed * nerf;
        Destroy(this.gameObject);
    }

    private void DestroyAllEnemies(){

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Debug.Log(enemies);
        for (int i = 0; i<enemies.Length; i++){
            enemies[i].Die();
        }

    }

    // Pendiente agregar mas buffs y nerfs y agregar efecto visual al player cuando es afectado por algun modificador de stats
    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.name == "player"){

            switch(this.name){

                case ("AttackSpeed"):   ShootingController[] guns = {other.gameObject.transform.Find("firePoint").GetComponent<ShootingController>(), 
                                                                        other.gameObject.transform.Find("firePoint2").GetComponent<ShootingController>()};
                                        
                                        StartCoroutine(BuffAttackSpeed(guns));
                                    break;

                case ("Bomb"):  DestroyAllEnemies();
                                Destroy(this.gameObject);

                            break;

                case ("SpeedDown"): PlayerController playerSpeed = other.gameObject.GetComponent<PlayerController>();

                                    StartCoroutine(NerfSpeed(playerSpeed));
                                break;
            }
                  
            //Hago invisible el objecto para que se siga ejecutando el script, una vez finalizado el efecto del buff o nerf se destruye el objecto      
            Instantiate(impactEffect, this.transform.position, Quaternion.identity);
            this.gameObject.GetComponent<Renderer>().enabled = false; 
        }
    }

}
