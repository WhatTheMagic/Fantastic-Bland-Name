using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Rigidbody characterBody;
    [SerializeField] private float speed = 2f;
    [SerializeField] private TurnManager manager;

    void Update()
    {
        if (manager.PlayerCanPlay())
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
    }

    private void Jump()
    {
        characterBody.AddForce(Vector3.up * 400f);
    }

    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        bool result = Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
        return result;
    }
}
