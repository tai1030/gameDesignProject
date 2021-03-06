﻿/*
 * Copyright (c) 2015 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {
	//Manager
	public GlobalStateManager GlobalManager;

    //Player parameters
    [Range(1, 2)] //Enables a nifty slider in the editor
    int playerNumber = 1; //Indicates what player this is: P1 or P2
    bool canDropBombs = true; //Can the player drop bombs?
    bool canMove = true; //Can the player move?
	bool dead = false; //Is this player dead?

    private int bombs = 2; //Amount of bombs the player has left to drop, gets decreased as the player drops a bomb, increases as an owned bomb explodes

    //Prefabs
    public GameObject bombPrefab;

	private Transform myTransform;

	[SerializeField] float speed = 6f;									//The speed that the player moves
	[SerializeField] Animator animator;									//Reference to the animator component
	[SerializeField] Rigidbody rigidBody;								//Reference to the rigidbody component

	[SerializeField] public KeyCode KeyUp, KeyDown, KeyLeft, KeyRight, KepDrop;

	void Reset ()
	{
		//Grab the needed component references
		animator = GetComponent <Animator> ();
		rigidBody = GetComponent <Rigidbody> ();
	}

    // Use this for initialization
    void Start() {
        //Cache the attached components for better performance and less typing
        myTransform = transform;
    }

    // Update is called once per frame
    void Update() {
        UpdateMovement();
    }

    private void UpdateMovement() {
		animator.SetBool("IsWalking", false);

        if (!canMove) { //Return if player can't move
            return;
        }

        //Depending on the player number, use different input for moving
        UpdatePlayerMovement();
    }

    /// <summary>
    /// Updates Player 1's movement and facing rotation using the WASD keys and drops bombs using Space
    /// </summary>
    private void UpdatePlayerMovement() {
		if (Input.GetKey (KeyUp)) { //Up movement
			Move (Vector3.forward);
			myTransform.rotation = Quaternion.Euler (0, 0, 0);
			animator.SetBool ("IsWalking", true);
		} else if (Input.GetKey (KeyLeft)) { //Left movement
			Move (Vector3.left);
			myTransform.rotation = Quaternion.Euler (0, 270, 0);
			animator.SetBool ("IsWalking", true);
		} else if (Input.GetKey (KeyDown)) { //Down movement
			Move (Vector3.back);
			myTransform.rotation = Quaternion.Euler (0, 180, 0);
			animator.SetBool ("IsWalking", true);
		} else if (Input.GetKey (KeyRight)) { //Right movement
			Move (Vector3.right);
			myTransform.rotation = Quaternion.Euler (0, 90, 0);
			animator.SetBool ("IsWalking", true);
		}

		if (canDropBombs && Input.GetKeyDown(KepDrop)) { //Drop bomb
            DropBomb();
        }
    }

	public void Move(Vector3 move){
		myTransform.position += move * speed * Time.deltaTime;
	}

    /// <summary>
    /// Drops a bomb beneath the player
    /// </summary>
    private void DropBomb() {
        if (bombPrefab) { //Check if bomb prefab is assigned first
			// Create new bomb and snap it to a tile
			Instantiate(bombPrefab,
				new Vector3(Mathf.RoundToInt(myTransform.position.x), bombPrefab.transform.position.y, Mathf.RoundToInt(myTransform.position.z)),
				bombPrefab.transform.rotation);
        }
    }

    public void OnTriggerEnter(Collider other) {
		if(other.tag == "Enemy"){
			Debug.Log(this.gameObject.name);
		}
        if (other.CompareTag("Explosion")) {
            Debug.Log("P" + playerNumber + " hit by explosion!");

			//dead = true;
			//GlobalManager.PlayerDied(playerNumber); //Notify global state manager that this player died
			//Destroy(gameObject);
        }
    }
}
