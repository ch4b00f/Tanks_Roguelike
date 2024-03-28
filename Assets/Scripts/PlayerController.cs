using System.Net;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1;
    [SerializeField] private float _rotateSpeed = 1;
    [SerializeField] private Animator _acTank;
    private Rigidbody rb;
    private Vector3 _lookDirection;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        _acTank = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }

    // 8 ordinal directions
    // rotation only while inputting
    private void Movement()
    {
        Vector3 direction = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            direction += new Vector3(0, 0, 1);
            if (direction != transform.forward)
            {
                Rotation();
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector3(0, 0, -1);
            if (direction != transform.forward)
            {
                Rotation();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector3(-1, 0, 0);
            if (direction != transform.forward)
            {
                Rotation();
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector3(1, 0, 0);
            if(direction != transform.forward)
            {
                Rotation();
            }
        }

        // make it consistent for framerates. _movespeed needs to be huge tho
        rb.velocity = direction.normalized * _moveSpeed * Time.deltaTime;

        if (direction == Vector3.zero)
        {
            return;
        }
        _lookDirection = direction;
    }

    // gradual rotation lerp
    private void Rotation()
    {
        Debug.Log("rotating");
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_lookDirection), _rotateSpeed);
    }

}
