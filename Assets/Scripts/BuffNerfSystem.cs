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
    [SerializeField] private bool buff = false, nerf = false;
    private Vector2 movement;
    private float outOfScreen = -13f;
    private bool impacted = false;


    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(0, -(speed * Time.deltaTime));

        this.transform.Translate(movement);

        if (this.transform.position.y < outOfScreen && !impacted){
            Destroy(this.gameObject);
        }
    }

    // Agregar timer para que se acabe el efecto y vuelva al estado normal. Duracion del buff: 5 segundos.
    IEnumerator BuffAttackSpeed(ShootingController[] _guns, Transform effect, Player _player){

        _player.AffectedByItem = true;

        float buffValue = 2f, time = 5f;

        Color originalColor = effect.GetComponent<Renderer>().material.color;
        Color colorEffect = new Color(1, 0.92f, 0.016f, 1);

        effect.GetComponent<Renderer>().material.color = colorEffect;

        for(int i = 0; i<_guns.Length; i++){
            _guns[i].FireRate = _guns[i].FireRate / buffValue;
        }
 
        yield return new WaitForSeconds(time);
  
        for(int i = 0; i<_guns.Length; i++){
            _guns[i].FireRate = _guns[i].FireRate * buffValue;
        } 

        _player.AffectedByItem = false;
        Destroy(this.gameObject);
    }


    IEnumerator NerfSpeed(PlayerController _playerSpeed, Player _player){
        
        _player.AffectedByItem = true;

        float nerfValue = 1.5f, time = 3f;

        _playerSpeed.Speed = _playerSpeed.Speed / nerfValue;

        yield return new WaitForSeconds(time);

        Debug.Log("Holiwis");
        _playerSpeed.Speed = _playerSpeed.Speed * nerfValue;
        _player.AffectedByItem = false;
        Destroy(this.gameObject);
    }

    private void DestroyAllEnemies(){

        Enemy[] enemies = FindObjectsOfType<Enemy>();

        for (int i = 0; i<enemies.Length; i++){
            enemies[i].Die();
        }

    }

    // Pendiente agregar mas buffs y nerfs y agregar efecto visual al player cuando es afectado por algun modificador de stats
    private void OnCollisionEnter2D(Collision2D other) {
           
        if (other.gameObject.name == "player"){
            this.impacted = true;   
            Player player = other.gameObject.GetComponent<Player>();
            this.name = this.name.Replace("(Clone)", "");

            if (!player.AffectedByItem || this.name == "Bomb"){

                switch (this.name){
                   
                    case ("AttackSpeed"):   ShootingController[] guns = {other.gameObject.transform.Find("firePoint").GetComponent<ShootingController>(), 
                                                                            other.gameObject.transform.Find("firePoint2").GetComponent<ShootingController>()};

                                            Transform lineShip = other.gameObject.transform.Find("ship2-lines");
                                          
                                            StartCoroutine(BuffAttackSpeed(guns, lineShip, player));
                                        break;

                    case ("Bomb"):  
                                    DestroyAllEnemies();
                                    Destroy(this.gameObject);

                                break;

                    case ("SpeedDown"): PlayerController playerSpeed = other.gameObject.GetComponent<PlayerController>();
                                        
                                        StartCoroutine(NerfSpeed(playerSpeed, player));
                                    break;

                }
                    
                //Hago invisible el objecto para que se siga ejecutando el script, una vez finalizado el efecto del buff o nerf se destruye el objecto      
                Instantiate(impactEffect, this.transform.position, Quaternion.identity);
                this.gameObject.GetComponent<Renderer>().enabled = false;

            } else if (player.AffectedByItem){

                Debug.Log("No puedes ser afectado por dos items al mismo tiempo");
                Instantiate(impactEffect, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);

            }   

        }
    }

}
