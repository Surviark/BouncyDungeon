using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpchk : MonoBehaviour
{
    public GameObject Player;
    private bool hasCollided = false;
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
        if (!hasCollided && collision.collider.gameObject.CompareTag("Platform"))
        {
            Player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
            hasCollided = true;
            StartCoroutine(DelayedExecution());
        }
    }

    private IEnumerator DelayedExecution()
    {
        yield return new WaitForSeconds(0.1f);
        hasCollided = false;
    }
}
