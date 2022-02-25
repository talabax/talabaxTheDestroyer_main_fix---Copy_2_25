using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int hP = 10;
    [SerializeField] int defense = 0;
    int i = 0;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //i++;
        //Debug.Log(i);
        //Debug.Log(collision.gameObject.tag +" was hit " + i);
        if (collision.gameObject.tag == "PlayerDamage")
        {
            
            ReduceHealth(10);
            Debug.Log(GetHealth());
        }
    }









    public int GetHealth()
    {
        return hP;
    }

    public int SetHealth(int newHealth)
    {
        hP = newHealth;
        return hP;
    }

    public int AddHealth(int newHealth)
    {
        hP = hP + newHealth;
        return hP;
    }
    public int ReduceHealth(int newHealth)
    {
        hP = hP - newHealth;
        if(hP <= 0)
        {
            Destroy(gameObject);
        }
        return hP;
    }


}
