using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpchk : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
    }
}
