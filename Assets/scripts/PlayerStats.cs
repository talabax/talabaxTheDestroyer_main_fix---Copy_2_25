using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] int hP = 100;
    [SerializeField] int defense = 0;
    void Start()
    {
        
    }

    public int PlayerHP()
    {
        return hP;
    }




    public void RemovePlayerHP(int life)
    {
        hP = hP - life;
    }
    public void AddPlayerHP(int life)
    {
        hP = hP+life;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("the hp is " + hP);
    }
}
