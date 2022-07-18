using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public GameManager gameManager;
    public void Hit(float damage){

        health -= damage;
        gameManager.healthText.text = "HEALTH " + health;

        if(health <= 0){

            gameManager.GameFailed();

        }
    }

    

}
