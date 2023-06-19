using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public HitBoxAttack hba;
    public ShootingPoint stp;
    private Rigidbody2D player;
    private SpriteRenderer playerRender;
    private Animator ani;
    private BoxCollider2D boxCollider2D;
    private float speed;
    private enum Movement_State { Idle, Running, Jumping_UP, Jumping_DOWN, Sliding, Atk1, Atk2, Sp_Atk, Fly_Atk };
    private Movement_State state = Movement_State.Idle;
    private float jump_velocity;
    private bool canMove = true;

    // Start is called before the first frame update
    [SerializeField] private LayerMask jumpable_ground;
    void Start()
    {
        this.ani = GetComponent<Animator>();
        this.player = GetComponent<Rigidbody2D>();
        this.playerRender = GetComponent<SpriteRenderer>();
        this.speed = 10;
        this.jump_velocity = 25f;
        this.boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        this.state = Movement_State.Idle;
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && IsGround())
        {
            this.player.velocity = new Vector2(this.player.velocity.x, this.jump_velocity);
        }
        if (dirX > 0)
        {
            this.hba.attack_direction = HitBoxAttack.at_direction.Right;
            this.player.velocity = new Vector2(speed * dirX, this.player.velocity.y);
            this.stp.direction = 1;
            this.playerRender.flipX = false;
            this.state = Movement_State.Running;
        }
        if (dirX < 0)
        {   
            this.hba.attack_direction = HitBoxAttack.at_direction.Left;
            this.player.velocity = new Vector2(speed * dirX, this.player.velocity.y);
            this.playerRender.flipX = true;
            this.stp.direction = -1;
            this.state = Movement_State.Running;
        }
        if (this.player.velocity.y > 4)
        {
            this.state = Movement_State.Jumping_UP;
        }
        if (this.player.velocity.y < -4)
        {
            this.state = Movement_State.Jumping_DOWN;
        }
        if (dirY < 0)
        {
            this.state = Movement_State.Sliding;
        }
        if(!canMove){
            this.player.velocity = new Vector2(0,this.player.velocity.y);
        }
        if (canMove&&this.ani.GetInteger("State")<=4)
        {   
            this.ani.SetInteger("State",(int) this.state);
        }
    }

    private bool IsGround()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, this.jumpable_ground);
    }

    private void lockMoving()
    {   
        this.canMove = false;
    }
    private void unlockMoving()
    {
        this.hba.stopAttack();
        this.canMove = true;
        this.ani.SetInteger("State",(int) Movement_State.Idle);
    }
    private void Attacked(){
        this.hba.Attack();
    }
    private void stopTakeDame(){
        this.ani.SetBool("TakeDame",false);
        this.player.bodyType = RigidbodyType2D.Dynamic;
    }
    private void Fly_Atk(){
        this.player.bodyType = RigidbodyType2D.Static;
        if(this.playerRender.flipX==true){
            this.stp.direction = 3;
        }
        else{
            this.stp.direction = 4;
        }
    }
    private void Stop_Fly_Atk(){
        this.player.bodyType = RigidbodyType2D.Dynamic;
        this.ani.SetInteger("State",(int) Movement_State.Jumping_DOWN);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")&&!this.ani.GetBool("TakeDame")){
            this.ani.SetBool("TakeDame",true);
            
        }
    }

    private void beHit(int value){
        this.ani.SetBool("TakeDame",true);
        this.player.bodyType = RigidbodyType2D.Static;
        gameObject.GetComponent<Player>().SendMessage("playerTakeDame",value);
    }
}
