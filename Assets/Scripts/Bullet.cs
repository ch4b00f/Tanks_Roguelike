using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * _bulletSpeed;
    }
}
