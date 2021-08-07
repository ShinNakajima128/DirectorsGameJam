﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    // Start is called before the first frame update

    // Update is called once per frame
    public void shot()
    {


        
            if (bulletPrefab )
            {
                GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
                bullet.transform.rotation = transform.rotation;
                Debug.Log("shot!");
            }
        
    }
}
