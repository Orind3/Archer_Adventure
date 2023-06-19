using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public PlayerAttack playerAttack;
    void Start()
    {
        this.health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.health<=0){
            Destroy(gameObject);
        }        
    }

    public void beHit(){
        playerAttack.SendMessage("takeDame",this.gameObject);
    }
}
