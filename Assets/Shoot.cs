using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float fireDelay = 0.25f;
    public float fireDelay2 = 0.25f;
    float cooldownTimer = 0;
    float cooldownTimer2 = 0;

    



    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        cooldownTimer2 -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Debug.Log("Pew!");
            cooldownTimer = fireDelay;

            Vector3 offset = new Vector3(5f, 0, 0);
           
            Instantiate(arrowPrefab, transform.position + offset, transform.rotation);
          
            
        }

        if (Input.GetButton("Fire2") && cooldownTimer2 <= 0)
        {
            Debug.Log("PEWPEWPEW!");
            cooldownTimer2 = fireDelay2;

            Vector3 offset1 = new Vector3(3.5f, 0f, 0);
            Vector3 offset2 = new Vector3(3f, 0f, 0);

            Instantiate(arrowPrefab, transform.position + offset1, transform.rotation);
            Instantiate(arrowPrefab, transform.position + offset2, transform.rotation);

            
        }

   

    }
}