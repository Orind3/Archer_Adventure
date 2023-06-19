using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPoint : MonoBehaviour
{
    private Vector2 shootingPoint;
    public int direction = 1;
    public int check = 1;
    // Start is called before the first frame update
    void Start()
    {   
        shootingPoint = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(direction!=check){
            transform.Rotate(0,180,0);
            check = direction;
        }
        this.transform.localPosition = new Vector2(this.shootingPoint.x*direction,this.shootingPoint.y);
    }
}
