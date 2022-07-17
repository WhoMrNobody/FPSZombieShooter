using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 100f;
    public float damage = 25f;
    public Animator playerAnimator;
    RaycastHit hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerAnimator.GetBool("isShooting")){

            playerAnimator.SetBool("isShooting", false);
        }
        if(Input.GetButtonDown("Fire1")){

            Shoot();
        }
    }

    void Shoot(){

        playerAnimator.SetBool("isShooting", true);
        
        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range)){

            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();

            if(enemyManager != null)
            {
                enemyManager.Hit(damage);
            }
        }

    }
}
