using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bounceMax = 1;
    private int _bounces;
    private Rigidbody rb;

    private void OnEnable()
    {
        _bounces = 0;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _bulletSpeed;
    }

    // return to object pool on collision
    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        string tag = obj.tag;

        // deal damage to player
        if (tag == "Player")
        {
            DealDamage(collision.gameObject);
            gameObject.SetActive(false);
        }
        // self destruct on other bullets
        else if(tag == "Bullet")
        {
            gameObject.SetActive(false);
        }

        // bounce off walls
        _bounces += 1;
        if(_bounces > _bounceMax)
        {
            gameObject.SetActive(false);
        }
    }

    private void DealDamage(GameObject player)
    {
        Health hp = player.GetComponent<Health>();
        hp.currentHealth -= 1;
    }
}
