using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public GameObject[] waypoint;
    private int index = 0;
    private float speed = 2f;
    void Update()
    {
        if(Vector2.Distance(this.waypoint[index].transform.position,transform.position)<.1f){
            this.index++;
        }
        if(index>=waypoint.Length){
            index = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position,waypoint[index].transform.position,Time.deltaTime * speed);
    }
}
