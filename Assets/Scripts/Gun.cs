using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _muzzle;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _firingDelay = .2f;
    private bool _canFire = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canFire)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject.Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
        StartCoroutine(ShootDelay());
    }

    private IEnumerator ShootDelay()
    {
        _canFire= false;
        yield return new WaitForSeconds(_firingDelay);
        _canFire = true;
    }
}
