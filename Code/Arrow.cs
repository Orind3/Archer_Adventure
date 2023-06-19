using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private int speed = 20;
    GameObject playerObject;
    PlayerAttack player;
    void Start()
    {
        this.playerObject = GameObject.FindGameObjectWithTag("Player");
        this.player = this.playerObject.gameObject.GetComponent<PlayerAttack>();
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.velocity = transform.right*speed;
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            Enemy beHit = other.gameObject.GetComponent<Enemy>();
            beHit.SendMessage("beHit");
        }
            Destroy(gameObject);
    }
}
