using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCursor : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    // this only works for an isometric camera, somehow
    private void Update()
    {
        Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // position adjusted to fit the dimensions of the camera
        transform.position = new Vector3(mousePos.x, .5f, 1.7f *  mousePos.z + 10);

    }
}
