using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;
    public GameObject prefab;
    bool skillonchk = false;
    public bool hasweapon = false;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }
        if (Input.GetKeyDown(KeyCode.Space) && skillonchk == false)
        {
            Skillon();
        }
    }
    void Skillon()
    {
        skillonchk = true;
        speed = 700;
        Invoke("Skilloff", 3);
    }
    void Skilloff()
    {
        speed = 150;
        skillonchk = false;
    }

    public void cntup(int count)
    {
        this.count += count;
        if (id == 0)
        {
            Batch();
        }
    }

    public void dmgup(float damage)
    {
        this.damage += damage;
        if (id == 0)
        {
            Batch();
        }
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            default:
                break;
        }
    }

    void Batch()
    {
        for (int index = 0; index < count; index++)
        {
            Transform knife;

            if (index < transform.childCount)
            {
                knife = transform.GetChild(index);
            }
            else
            {
                knife = GameManager.instance.poolManager.Get(prefabId).transform;
                knife.parent = transform;
            }
            knife.localPosition = Vector3.zero;
            knife.localRotation = Quaternion.identity;

            Vector3 rotvec = Vector3.forward * 360 * index / count;
            knife.Rotate(rotvec);
            knife.Translate(knife.up * 1.5f, Space.World);
            knife.GetComponent<Knife>().Init(damage, -1);
        }
    }
}