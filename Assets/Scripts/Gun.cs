using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _muzzle;
    [SerializeField] private float _firingDelay = .2f;
    public bool canFire = true;

    public void Shoot()
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
        canFire= false;
        yield return new WaitForSeconds(_firingDelay);
        canFire = true;
    }
}
