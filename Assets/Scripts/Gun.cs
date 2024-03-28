using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _muzzle;
    [SerializeField] private float _firingDelay = .2f;
    private bool _canFire = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canFire)
        {
            Shoot();
        }

        // DEBUG refill ammo
        if (Input.GetKeyDown(KeyCode.R))
        {
            ObjectPooling.instance.ReturnAllObjects();
        }
    }

    private void Shoot()
    {
        GameObject bullet = ObjectPooling.instance.GetPooledObject();
        if(bullet != null)
        {
            Debug.Log(bullet);
            bullet.transform.position = _muzzle.position;
            bullet.transform.rotation = _muzzle.rotation;
            bullet.SetActive(true);
        }

        StartCoroutine(ShootDelay());
    }

    private IEnumerator ShootDelay()
    {
        _canFire= false;
        yield return new WaitForSeconds(_firingDelay);
        _canFire = true;
    }
}
