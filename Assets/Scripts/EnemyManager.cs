using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
   
    public Animator enemyAnimator;
    public float damageValue;
    public float health = 100f;
    private NavMeshAgent _navMeshAgent;
    private GameObject _player;
    public GameManager gameManager;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.destination = _player.transform.position;

        if(_navMeshAgent.velocity.magnitude > 1){
            enemyAnimator.SetBool("isRunning", true);
        }else{
            enemyAnimator.SetBool("isRunning", false);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject == _player){

            _player.GetComponent<PlayerHealth>().Hit(damageValue);
        }
    }

    public void Hit(float damage){

        health -= damage;

        if(health <= 0){

            gameManager.enemiesAlive--;
            Destroy(gameObject);    
        }
    }
}
