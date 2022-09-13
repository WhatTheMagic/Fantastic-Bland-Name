using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Rigidbody characterBody;

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
		{
            transform.Translate(transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
		}

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));
        }

        if (Input.GetKeyDown(KeyCode.Space) && characterBody.velocity.y <= 0.05f)
		{
            Jump();
		}
    }

    private void ToggleVisibility()
	{
        gameObject.SetActive(!gameObject.activeInHierarchy);
	}

    private void Jump()
	{
        //characterBody.velocity = Vector3.up * 10f;
        characterBody.AddForce(Vector3.up * 500f);
	}
}
