using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float maxSpeed = 5;
    public Animator animator;
    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(maxSpeed * Time.deltaTime, 0, 0);

        pos -= transform.rotation * velocity;

        transform.position = pos;

        animator.SetFloat("speed", Mathf.Abs(maxSpeed * Time.deltaTime));
    }
}
