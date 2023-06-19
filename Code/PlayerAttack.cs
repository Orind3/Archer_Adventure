using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Player playerComponent;
    private Rigidbody2D player;
    private SpriteRenderer playerRender;
    private Animator ani;
    private BoxCollider2D boxCollider2D;
    private enum Player_Attack { Idle, Running, Jumping_UP, Jumping_DOWN, Sliding, Atk1, Atk2, Sp_Atk, Fly_Atk };
    private Player_Attack state = Player_Attack.Idle;
    public HitBoxAttack hba;

    private int dame = 5;
    void Start()
    {
        this.ani = GetComponent<Animator>();
        this.player = GetComponent<Rigidbody2D>();
        this.playerRender = GetComponent<SpriteRenderer>();
        this.boxCollider2D = GetComponent<BoxCollider2D>();
        this.playerComponent = GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        this.state = Player_Attack.Idle;
        if (Input.GetMouseButtonDown(0))
        {
            this.state = Player_Attack.Atk1;

        }
        if (Input.GetMouseButtonDown(1))
        {
            this.state = Player_Attack.Atk2;
            this.playerComponent.playerMP-=20;
        }
        if (this.player.velocity.y > 0f && this.player.velocity.y <= 13f)
        {
            if (Input.GetKeyDown("space"))
            {
                this.state = Player_Attack.Fly_Atk;
            }
        }

        if (this.state != Player_Attack.Idle)
        {   
            this.ani.SetInteger("State", (int)this.state);
        }
        
    }
    public void takeDame(GameObject Object){
        Enemy target = Object.gameObject.GetComponent<Enemy>();
        target.health-=this.dame;
    }
}
