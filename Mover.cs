using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    private bool hardMode;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        GameObject hardmode = GameObject.Find("GameController");
        GameController playerScript = hardmode.GetComponent<GameController>();
        hardMode = playerScript.hardMode;
        if (hardMode == true)
            {
            rb.velocity = rb.velocity * 1.05f;            
        }       
    }
}
