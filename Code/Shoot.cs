using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject Arrow;
    [SerializeField] GameObject ShootingPoint;
    // Update is called once per frame

    public void Shooting(){
        Instantiate(Arrow,ShootingPoint.transform.position,this.ShootingPoint.transform.rotation);
    }

}
