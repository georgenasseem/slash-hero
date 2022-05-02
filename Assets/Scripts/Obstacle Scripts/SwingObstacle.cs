using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 200f;

    private float zAngle;

    [SerializeField]
    private float minZRotation = -0.7f, maxZRotation = 0.7f;

    private Rigidbody2D myBody;

    private bool rotateLeft;

    private void Awake()
    {

        //if (Random.Range(0, 2) > 0)
        //    rotateSpeed *= -1;

        myBody = GetComponent<Rigidbody2D>();

        if (Random.Range(0, 2) > 0)
            rotateLeft = true;

    }

    private void Update()
    {

        HandleRotationWithRigidBody();

    }

    void HandleRotationWithRigidBody()
    {

        if (transform.rotation.z > maxZRotation)
            rotateLeft = true;

        if (transform.rotation.z < minZRotation)
            rotateLeft = false;

        if (rotateLeft)
            myBody.angularVelocity = -rotateSpeed;
        else
            myBody.angularVelocity = rotateSpeed;

    }

    void HandleRotationWithTransform()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);

        if (transform.rotation.z < minZRotation)
            rotateSpeed = Mathf.Abs(rotateSpeed);

        if (transform.rotation.z > maxZRotation)
            rotateSpeed = -Mathf.Abs(rotateSpeed);
    }


} // class








































