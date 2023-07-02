using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float health = 100;
    public float maxSpeed = 3;
    public float jumpPower;
    public static bool leftBlock;
    Rigidbody2D rigid;
    SpriteRenderer spriterender;
    CapsuleCollider2D capsule;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriterender = GetComponent<SpriteRenderer>();
        capsule = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        if (rigid.velocity.x < 0)
            spriterender.flipX = true;
        if (rigid.velocity.x > 0)
            spriterender.flipX = false;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        
        if (!GameManager.instance.leftBlock && !GameManager.instance.rightBlock)
        {
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        }
        

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity=new Vector2(maxSpeed,rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity=new Vector2(maxSpeed*(-1),rigid.velocity.y);
        }
    }
}
