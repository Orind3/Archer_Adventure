using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{

    public int hp = 0;
    // Start is called before the first frame update
    public Animator ani;
    void Start()
    {
        this.ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.ani.SetInteger("HP",this.hp);
    }
}
