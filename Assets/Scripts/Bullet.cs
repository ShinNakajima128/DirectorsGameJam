using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] int deathTime = 2;
    float timer;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * moveSpeed;
    }
    private void FixedUpdate()
    {
        if (timer >= deathTime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WallH")
        {
            Vector3 vel = rb.velocity;
            rb.velocity = new Vector3(vel.x * -1, vel.y, vel.z);
        }
        else if (other.gameObject.tag == "WallV")
        {
            Vector3 vel = rb.velocity;
            rb.velocity = new Vector3(vel.x, vel.y, vel.z * -1);
        }
    }
}
