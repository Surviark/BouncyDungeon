using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemchk : MonoBehaviour
{
    public GameObject weapon0;
    public GameObject weapon1;
    public GameObject player;
    Weapon weapontype0;
    Weapon1 weapontype1;
    PlayerMove playermove;
    // Start is called before the first frame update
    void Start()
    {
        weapontype0 = weapon0.GetComponent<Weapon>();
        weapontype1 = weapon1.GetComponent<Weapon1>();
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
            weapontype0.cntup(1);
            weapontype0.hasweapon = true;
            weapontype1.hasweapon = false;
            weapon0.SetActive(true);
            weapon1.SetActive(false);
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("SpearCnt+1"))
        {
            weapontype1.cntup(1);
            weapontype1.hasweapon = true;
            weapontype0.hasweapon = false;
            weapon0.SetActive(false);
            weapon1.SetActive(true);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("damage"))
        {
            OnDamaged();
        }
    }
    void OnDamaged()
    {
        player.layer = 11;
        playermove.health -= 10;
        player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamaged", 2);
    }

    void OffDamaged()
    {
        player.layer = 10;
        player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}