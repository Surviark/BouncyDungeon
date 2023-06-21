using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leftchk : MonoBehaviour
{
    //공 왼쪽이 벽에 닿았을 경우 True
    public bool isleft = false;
    public GameObject Player;
    public Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isleft = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isleft = true;
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, rigid.velocity.y);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddForce(Vector2.right * 3, ForceMode2D.Impulse);
            rigid.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        }
    }
}
