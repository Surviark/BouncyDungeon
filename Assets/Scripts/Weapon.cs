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
            
            if(index < transform.childCount)
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
