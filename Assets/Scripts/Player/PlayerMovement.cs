//This script handles moving the player. As the player doesn't move using a navmesh agent, some calculations have to be done to
//get the appropriate level of control.

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[HideInInspector] public Vector3 MoveDirection = Vector3.zero;		//The direction the player should move
	[HideInInspector] public Vector3 LookDirection = Vector3.forward;	//The direction the player should face

	public float speed = 6f;									//The speed that the player moves
	[SerializeField] Animator animator;									//Reference to the animator component
	[SerializeField] Rigidbody rigidBody;								//Reference to the rigidbody component

	bool canMove = true;												//Can the player move?

	[HideInInspector] PlayerHealth playerHealth;						//Reference to the player's health script

	[SerializeField] public KeyCode KeyUp, KeyDown, KeyLeft, KeyRight, KepDrop;

	//Prefabs
	public GameObject bombPrefab;

	//Reset() defines the default values for properties in the inspector
	void Reset ()
	{
		//Grab the needed component references
		animator = GetComponent <Animator> ();
		rigidBody = GetComponent <Rigidbody> ();
	}

	// Update is called once per frame
	void Update() {
		FixedUpdate();
	}

	//Move with physics so the movement code goes in FixedUpdate()
	void FixedUpdate ()
	{
		//If the player cannot move, leave
		if (!canMove)
			return;

		//Depending on the player number, use different input for moving
		UpdatePlayerMovement();
	}

	/// <summary>
	/// Updates Player 1's movement and facing rotation using the WASD keys and drops bombs using Space
	/// </summary>
	private void UpdatePlayerMovement() {
		if (Input.GetKey (KeyUp)) { //Up movement
			Move (Vector3.forward);
			rigidBody.rotation = Quaternion.Euler (0, 0, 0);
			animator.SetBool ("IsWalking", true);
		} else if (Input.GetKey (KeyLeft)) { //Left movement
			Move (Vector3.left);
			rigidBody.rotation = Quaternion.Euler (0, 270, 0);
			animator.SetBool ("IsWalking", true);
		} else if (Input.GetKey (KeyDown)) { //Down movement
			Move (Vector3.back);
			rigidBody.rotation = Quaternion.Euler (0, 180, 0);
			animator.SetBool ("IsWalking", true);
		} else if (Input.GetKey (KeyRight)) { //Right movement
			Move (Vector3.right);
			rigidBody.rotation = Quaternion.Euler (0, 90, 0);
			animator.SetBool ("IsWalking", true);
		}

		if (Input.GetKeyDown(KepDrop)) { //Drop bomb
			DropBomb();
		}
	}

	public void Move(Vector3 move){
		rigidBody.position += move * speed * Time.deltaTime;
	}

	/// <summary>
	/// Drops a bomb beneath the player
	/// </summary>
	private void DropBomb() {
		if (bombPrefab) { //Check if bomb prefab is assigned first
			// Create new bomb and snap it to a tile
			Instantiate(bombPrefab,
				new Vector3(Mathf.RoundToInt(rigidBody.position.x), bombPrefab.transform.position.y, Mathf.RoundToInt(rigidBody.position.z)),
				bombPrefab.transform.rotation);
		}
	}

	public void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Explosion")) {
			playerHealth = this.GetComponent<PlayerHealth>();
			//...if the script exists...
			if (playerHealth != null)
			{
				//...tell the enemy to take damage
				playerHealth.TakeDamage(100);
			}
		}
	}

	//Called when the player is defeated
	public void Defeated()
	{
		//Player can no longer move
		canMove = false;
	}
}

