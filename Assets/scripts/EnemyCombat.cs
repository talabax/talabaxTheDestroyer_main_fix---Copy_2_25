using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    GameObject player;
    PlayerStats playerHP; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHP = player.GetComponent<PlayerStats>();
        
    }



    void DealDamage()
    {
        playerHP.RemovePlayerHP(20);
        
        //Debug.Log("ddddddddddddddddddddddddddddd");
        
    }
        
        
    
}
