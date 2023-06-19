using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject EnemyBall;
    [SerializeField] GameObject ShootingPoint;
    [SerializeField] GameObject Player;

    private int count = 0;
    private GameObject init;
    // Update is called once per frame
    void Update()
    {
        count++;
        if(count>800){
            if(Vector3.Distance(ShootingPoint.transform.position,Player.transform.position)<20)
                Shooting();
            this.count = 0;
        }
    }
        public void Shooting(){
            init = Instantiate(EnemyBall,ShootingPoint.transform.position,this.ShootingPoint.transform.rotation);
    }


}
