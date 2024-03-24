using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAim : MonoBehaviour
{
    private AimCursor _aimCursor;

    private void Start()
    {
        _aimCursor = FindObjectOfType<AimCursor>();
    }

    private void Update()
    {
        transform.forward = _aimCursor.transform.position - transform.position;
    }
}
