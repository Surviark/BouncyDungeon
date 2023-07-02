using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemchk : MonoBehaviour
{
    public GameObject weapon;
    public GameObject player;
    Weapon weapontype;
    PlayerMove playermove;
    // Start is called before the first frame update
    void Start()
    {
        weapontype = weapon.GetComponent<Weapon>();
        playermove = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KnifeCnt+1"))
        {
            weapontype.cntup(1);
            collision.gameObject.SetActive(false);
        }
        if(collision.gameObject.CompareTag("damage"))
        {
            playermove.health -= 10;
            StartCoroutine(DelayedExecution());
        }
    }
    private IEnumerator DelayedExecution()
    {
        yield return new WaitForSeconds(1f);
    }
}
