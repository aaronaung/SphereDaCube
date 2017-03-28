using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;            // Player's speed

	Vector3 movVector;                   // The vector to store the direction of the player's movement.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	float camRayLength = 100f;          // The length of the ray from the camera into the scene.

	void Awake ()
	{
		// Create a layer mask for the floor layer.
		floorMask = LayerMask.GetMask ("Floor");
		playerRigidbody = GetComponent <Rigidbody> ();
	}


	void FixedUpdate ()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		// Move the player around the scene.
		Move (h, v);
		// Turn the player to face the mouse cursor.
		Turning ();
	}

	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		movVector.Set (h, 0f, v);
		//If you move 1 unit in x and y axises, moving diagonally would be 1.4 unit. 
		//To make the diagonal movement the same as the other axis, you need to normalize the movement vector
		// Normalise the movement vector and make it proportional to the speed per second.
		movVector = movVector.normalized * speed * Time.deltaTime;
		//Debug.Log (movVector.normalized);

		// Move the player to the next position (currentposition + movement Vector) .
		playerRigidbody.MovePosition (transform.position + movVector);
	}

	void Turning ()
	{
		// creates a ray from camera position to the mouse cursor on the screen. 
		// to be used to figure out which director the player turns.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		// stores what's hit by the ray. 
		RaycastHit floorHit;
		// Perform the raycast and if it hits something on the floor layer...
		if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
		{
			// Debug.DrawLine (Camera.main.transform.position, floorHit.point);
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;
			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;
			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

			// Set the player's rotation to this new rotation.
			playerRigidbody.MoveRotation (newRotation);
		}
	}
}