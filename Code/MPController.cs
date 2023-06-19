using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPController : MonoBehaviour
{

    public int mp =0;
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        this.ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.ani.SetInteger("MP",this.mp);
    }
}
