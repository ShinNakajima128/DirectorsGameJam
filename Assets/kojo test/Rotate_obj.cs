using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_obj : MonoBehaviour
{
    [SerializeField] float m_rotate_X = 0;
    [SerializeField] float m_rotate_Y = 0;
    [SerializeField] float m_rotate_Z = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(m_rotate_X, m_rotate_Y, m_rotate_Z);
    }
}
