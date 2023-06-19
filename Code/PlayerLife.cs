using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Player player;
    private Animator ani;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        this.ani = GetComponent<Animator>();
        this.body = GetComponent<Rigidbody2D>();
        this.player = GetComponent<Player>();
    }

    void Update(){
        if(this.player.playerHP <= 0){
            this.ani.SetTrigger("Death");
            this.body.bodyType = RigidbodyType2D.Static;
            this.player.playerHP = 100;
            this.player.playerMP = 100;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Death")){
            this.ani.SetTrigger("Death");
            this.body.bodyType = RigidbodyType2D.Static;
        }
    }


    private void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
