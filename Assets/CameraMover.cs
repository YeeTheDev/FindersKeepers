using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] Transform lookTarget;
    [SerializeField] bool invertControls;
    [SerializeField] float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 rotation = Vector3.zero;
            rotation.y = Input.GetAxis("Mouse X");
            rotation.x = Input.GetAxis("Mouse Y");

            if (invertControls) { rotation *= -1; }

            lookTarget.Rotate(rotation.normalized * rotationSpeed * Time.deltaTime);
        }
    }
}
