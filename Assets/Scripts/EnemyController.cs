using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _acTank;
    [SerializeField] private Gun _gun;
    private Rigidbody rb;
    private Vector3 _lookDirection;

    [SerializeField] private PlayerController _player;
    private Vector3 _playerPos;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        _acTank = GetComponent<Animator>();
        _gun = GetComponentInChildren<Gun>();
        _player = FindObjectOfType<PlayerController>();
        StartCoroutine(RandomShoot());
    }

    // DEBUG try and get aim right
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, _playerPos);
    }


    private void Update()
    {
        _playerPos = _player.transform.position;
        PerfectAim();
    }
    
    private IEnumerator RandomShoot()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        _gun.Shoot();
        StartCoroutine(RandomShoot());
    }

    private void PerfectAim()
    {
        // if enemy is to the left of player
        if(transform.position.x - _playerPos.x > 0)
        {
            _gun.transform.rotation = Quaternion.Euler(new Vector3(0, -Vector3.Angle(Vector3.forward, _playerPos - transform.position), 0));
        }
        // if enemy is to the right of player
        else
        {
            _gun.transform.rotation = Quaternion.Euler(new Vector3(0, Vector3.Angle(Vector3.forward, _playerPos - transform.position), 0));
        }
    }
}
