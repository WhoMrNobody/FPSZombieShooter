using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;

    public void Hit(float damage){
        health -= damage;

        if(health <= 0){

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        }
    }

}
