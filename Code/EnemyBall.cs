using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    GameObject playerObject;
    PlayerAttack player;
    public float X;
    public float Y;

    private int time = 0;
    void Start()
    {
        this.playerObject = GameObject.FindGameObjectWithTag("Player");


        this.X = playerObject.transform.position.x-this.transform.position.x;
        this.Y = playerObject.transform.position.y-this.transform.position.y - 1.5f;

        float k = 10/Mathf.Sqrt(X*X + Y * Y);


        this.rb = GetComponent<Rigidbody2D>();
        this.rb.velocity = new Vector2(this.X*k,this.Y*k);
    }
    private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player")){
                PlayerMovement beHit = other.gameObject.GetComponent<PlayerMovement>();
                beHit.gameObject.SendMessage("beHit",20);
                Destroy(gameObject);
        }
    }

    void Update(){
        time++;
        if(time>2000){
            Destroy(this.gameObject);
        }
    }
}
