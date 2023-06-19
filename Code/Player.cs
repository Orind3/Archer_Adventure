using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public static Player Instance;
    public float playerMaxHP;
    public float playerMaxMP;
    public float playerHP;
    public float playerMP;

    public HPController HP;
    public MPController MP;
    private Animator ani;

    // Start is called before the first frame update

    void Awake(){
                Instance = this;
    }
    void Start()
    {
        this.playerHP = 100f;
        this.playerMP = 100f;    
        this.playerMaxHP = 100f;
        this.playerMaxMP = 100f;
        this.ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        this.HP.hp =(int) (this.playerHP/this.playerMaxHP*4);
        this.MP.mp =(int) (this.playerMP/this.playerMaxMP*4);
    }

    public void increaseHealth(int value){
        this.playerHP+=value;
    }
    public void increaseMana(int value){
        this.playerMP+=value;
    }

    public void playerTakeDame(int value){
        this.playerHP-=20;
    }
}
