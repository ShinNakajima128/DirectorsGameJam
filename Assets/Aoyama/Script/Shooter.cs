using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
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
        Debug.Log(Timer);
        if(Input.GetAxis("L_R_Trigger") > 0  && bulletTimer <= Timer)
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
