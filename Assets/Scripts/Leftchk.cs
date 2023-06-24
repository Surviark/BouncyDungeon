using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leftchk : MonoBehaviour
{
    //공 왼쪽이 벽에 닿았을 경우 True
    public bool isleft = false;
    private bool hasCollided = false;
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
        if (collision.gameObject.CompareTag("Platform")) {
            isleft = true;
            GameManager.instance.leftBlock = true;
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, rigid.velocity.y);
            if (Input.GetKey(KeyCode.RightArrow) && !hasCollided)
            {
                rigid.AddForce(Vector2.right * 3, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
                hasCollided = true;
                StartCoroutine(DelayedExecution());
            }
            else
            {
                rigid.AddForce(Vector2.right * 2, ForceMode2D.Impulse);
                hasCollided = true;
                StartCoroutine(DelayedExecution());
            }
        }
        
    }

    private IEnumerator DelayedExecution()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.instance.leftBlock = false;
        hasCollided = false;
    }
}
