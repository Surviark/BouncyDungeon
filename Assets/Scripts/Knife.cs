using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float damage;
    public float per;

    public void Init(float damgae, float per)
    {
        this.damage = damgae;
        this.per = per;
    }
}
