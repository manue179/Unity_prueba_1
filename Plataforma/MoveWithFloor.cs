using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloor : MonoBehaviour
{
    CharacterController characterController;

    Vector3 groundPos;
    Vector3 lastGroundPos;
    Vector3 currentPos;

    string groundName;
    string lastGroundName;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MovingPlatform"))
        {
            RaycastHit hit;
            float rayLength = 1.0f; // Longitud del rayo
            if (Physics.Raycast(transform.position, -transform.up, out hit, rayLength))
            {
                GameObject hitObject = hit.collider.gameObject;
                groundName = hitObject.name;
                groundPos = hitObject.transform.position;

                if (groundPos != lastGroundPos && groundName == lastGroundName)
                {
                    currentPos = groundPos - lastGroundPos;
                    characterController.Move(currentPos);
                }

                lastGroundName = groundName;
                lastGroundPos = groundPos;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (!characterController.isGrounded)
                {
                    ResetGroundVariables();
                }
            }
        }
    }

    private void ResetGroundVariables()
    {
        currentPos = Vector3.zero;
        lastGroundPos = Vector3.zero;
        lastGroundName = null;
    }
}
