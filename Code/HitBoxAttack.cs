using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBoxAttack : MonoBehaviour
{
    public enum at_direction { Left, Right };
    public at_direction attack_direction;
    public BoxCollider2D hitbox;

    public Vector2 hit_box_offset;
    void Start()
    {
        this.hitbox = GetComponent<BoxCollider2D>();
        this.hit_box_offset = transform.localPosition;
        this.hitbox.enabled = false;
    }

    public void Attack()
    {
        if (attack_direction == at_direction.Right)
        {
            transform.localPosition = hit_box_offset;
        }
        if (attack_direction == at_direction.Left)
        {
            transform.localPosition = new Vector2(this.hit_box_offset.x * -1, this.hit_box_offset.y);
        }
        hitbox.enabled = true;
    }

    public void stopAttack()
    {
        hitbox.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy beAttacked = other.gameObject.GetComponent<Enemy>();
            if(beAttacked!=null){
                beAttacked.health-=3;
            }
        }
    }
}
    


