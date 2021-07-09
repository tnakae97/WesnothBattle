using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float hp = 10;
    public float str = 10;
    public float ac = 10;
    public float dex = 10;
    public float wd = 1;
    
    // Start is called before the first frame update

    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
