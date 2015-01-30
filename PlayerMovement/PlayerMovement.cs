using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;
	private float maxSpeed = 5f;
		
	private Vector3 horizontalInput, verticalInput;

	private float jumpStart = 0f;	// position for jump limiting
	public float jumpHeight;	// jump height
	public float jumpSpeed;	// jump speed
	private bool jumping = false;
	
	void Start()
	{
		
	}
	
	
	void Update()
	{
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		horizontalInput = new Vector3(x, 0, 0); // get x & z input


		// Limit the speed in the x direction
		if (rigidbody.velocity.magnitude < maxSpeed) 
		{
			if(!jumping)
				rigidbody.AddForce (horizontalInput * moveSpeed);
			else
				rigidbody.AddForce (horizontalInput * moveSpeed / (moveSpeed-2));
		}

		// make the player jump if the vertical button was pressed
		// only when the player isn't currently in the air due to a jump
		if (y > 0 && jumping == false) 
		{
			verticalInput = new Vector3 (0, y, 0);	// get y inpu
			jumpStart = rigidbody.position.y;	// mark where the jump began
			jumping = true;
		}

		if (jumping) // currently in the air/jumping
		{
			if(rigidbody.position.y < jumpStart + jumpHeight)
			{
				rigidbody.AddForce(verticalInput * jumpSpeed * 6);
			}
			else 
				jumping = false;		// fall back
		}


		rigidbody.AddForce(Physics.gravity*rigidbody.mass);



	}
}