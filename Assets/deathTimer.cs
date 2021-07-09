using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTimer : MonoBehaviour
{
    int timer = 0;
    public int duration;

    private void Update()
    {
        if (timer < duration)
        {
            timer++;
        }
        if (timer == duration)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
