using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject efect;

    public void Explosion()
    {
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
        Instantiate(efect, transform.position, efect.transform.rotation);
        //SoundManager.Instance.PlaySeByName("爆破・爆発12");
        SoundManager.Instance.PlaySeByName("インパクト系_HIT音（SE1）");
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Explosion();
        }
        else if (other.CompareTag("Player"))
        {
            Instantiate(efect);
            gameObject.SetActive(false);
        }
    }
}
