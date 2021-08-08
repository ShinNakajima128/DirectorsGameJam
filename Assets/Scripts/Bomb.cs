using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject bullet;


    private void Start()
    {

    }
    public void Explosion()
    {
        if (anim)
        {
            anim.Play("Explosion");
        }

        for (int x = -2; x < 3; x++)
        {
            for (int z = -2; z < 3; z++)
            {
                if (x == 0 && z == 0)
                {
                    continue;
                }
                Vector3 vec = new Vector3(x, 0, z);
                Vector3 bulletP = transform.position + new Vector3(x, 0, z);
                Instantiate(bullet, bulletP, Quaternion.FromToRotation(Vector3.forward, vec));
            }
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Explosion();
        }
        else if (other.CompareTag("Player"))
        {

        }
    }
}
