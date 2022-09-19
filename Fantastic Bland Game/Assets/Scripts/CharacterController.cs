using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private float speed = 2f;

    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Translate(transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
            }

            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        //characterBody.velocity = Vector3.up * 10f;
        characterBody.AddForce(Vector3.up * 400f);
    }

    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        // Parameters:
        // - The center from where we shoot
        // - Radius of the sphere
        // - Direction of the sphere
        // - hit parameter
        // - Distance the sphere
        bool result = Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
        return result;
    }
}
