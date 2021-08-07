using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletTimer = 0.5f;
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if(Input.GetAxis("L_R_Trigger2") > 0  && bulletTimer <= Timer)
        { 
            if (bulletPrefab)
            {
                GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
                bullet.transform.rotation = transform.rotation;
                Timer = 0;
                Debug.Log("shot!");
            }
        }
    }
}
