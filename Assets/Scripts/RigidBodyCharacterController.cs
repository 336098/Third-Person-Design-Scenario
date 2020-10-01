using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float accelerationForce = 10;

    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private PhysicMaterial stoppingPhysicsMaterial, movingPhysicsMaterial;

    private new Rigidbody rigidBody;
    private Vector2 input;
    private new Collider collider;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);

        collider.material = inputDirection.magnitude > 0 ? movingPhysicsMaterial : stoppingPhysicsMaterial;

        //if (inputDirection.magnitude > 0)
        //{
        //    collider.material = movingPhysicsMaterial;
        //}
        //else
        //{
        //    collider.material = stoppingPhysicsMaterial;
        //}

        if (rigidBody.velocity.magnitude < maxSpeed)
        {
            rigidBody.AddForce(inputDirection * accelerationForce, ForceMode.Acceleration);
        }
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}
