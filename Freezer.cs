using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public bool freeze = false;
    GameManager gm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("_GameManager").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
        freeze = gm.freeze;

        if (freeze == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

        }
        else { 
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }
}
