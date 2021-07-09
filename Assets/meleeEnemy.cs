using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemy : MonoBehaviour
{
    public GameObject opponent;
    public GameObject self;
    public GameObject BoomPrefab;
    public Animator animator;
    bool isAttacking;

    float timer = 0;
    float turn = 1;


    private Stats stats;
    private Stats selfStat;


    void Awake()
    {
        
    }


    void Start()
    {
        FindClosestEnemy();
    }

    void Update()
    {
        FindClosestEnemy();
        if (opponent != null)
        {
            stats = opponent.GetComponent<Stats>();
            selfStat = self.GetComponent<Stats>();
        }
        if (isAttacking == true)
        {
            animator.SetBool("isAttacking", true);
        }
        if (isAttacking == false)
        {
            animator.SetBool("isAttacking", false);
        }

    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        player closestEnemy = null;
        player[] allEnemies = GameObject.FindObjectsOfType<player>();
      
        foreach (player currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                opponent = closestEnemy.gameObject;
            }
            
        }

        if (closestEnemy != null)
        {
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
            if ((closestEnemy.transform.position - this.transform.position).sqrMagnitude > 2)
            {
                isAttacking = false;
            }
        }
        

        if (closestEnemy == null) 
        {
            isAttacking = false;
        }

    }
     void OnTriggerStay2D()
    {
         float atkspd = 200 - (((selfStat.dex-10)/2)*10);
        
        if (timer < atkspd)
        {
            timer++;
        }
        if (timer == atkspd)
        {
            
            if(selfStat.str >= selfStat.dex)
            {
                float bab = 1 + ((selfStat.str - 10)/2);
                float atkrole = Mathf.Round(Random.Range(0.0f, 20.0f) + bab);
                float pd = Mathf.Round((selfStat.str-10)/2) + selfStat.wd;
                float ac = Mathf.Round(stats.ac);
                if(atkrole >= ac)
                {
                    stats.hp -= Mathf.Abs(pd);
                    Vector3 offset = new Vector3(-2.0f, 0, 0);
                    Instantiate(BoomPrefab, transform.position + offset, transform.rotation);           
                    Debug.Log("enemy Hit (" + atkrole + ") vs" + ac + " for " + pd);
                }
                if(atkrole < ac)
                {
                    Debug.Log("enemy Miss " + atkrole + "vs" + ac);
                }
                timer -= atkspd;
            }    
            else
            {
                float bab = 1 + ((selfStat.dex - 10)/2);
                float atkrole = Mathf.Round(Random.Range(0.0f, 20.0f) + bab);
                float pd = Mathf.Round((selfStat.str-10)/2) + selfStat.wd;
                float ac = Mathf.Round(stats.ac);
                if(atkrole >= ac)
                {
                    stats.hp -= Mathf.Abs(pd);
                    Vector3 offset = new Vector3(-2.0f, 0, 0);
                    Instantiate(BoomPrefab, transform.position + offset, transform.rotation);           
                    Debug.Log("enemy Hit (" + atkrole + ") vs" + ac + " for " + pd);
                }
                if(atkrole < ac)
                {
                    Debug.Log("enemy Miss " + atkrole + "vs" + ac);
                }
                timer -= atkspd;
            }
            

        }
        isAttacking = true;

        

    }



}
