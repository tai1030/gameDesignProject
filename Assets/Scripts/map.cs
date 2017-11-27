using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour {

	public GameObject brick;
    public GameObject box;

	private List<GameObject> bricks;
	private List<GameObject> boxes;

	// Use this for initialization
	void Start () {
		bricks = new List<GameObject>();
		for (int i = 0; i <= 14; i++)
        {
			GameObject brick1 = Instantiate(brick, new Vector3(1, 0.5f, -i), Quaternion.identity);
			GameObject brick2 = Instantiate(brick, new Vector3(-14, 0.5f, -i), Quaternion.identity);
			GameObject brick3 = Instantiate(brick, new Vector3(-i, 0.5f, 0), Quaternion.identity);
			GameObject brick4 = Instantiate(brick, new Vector3(-i, 0.5f, -15), Quaternion.identity);
			bricks.Add(brick1);
			bricks.Add(brick2);
			bricks.Add(brick3);
			bricks.Add(brick4);
        }

		GameObject brick5 = Instantiate(brick, new Vector3(1, 0.5f, -15), Quaternion.identity);
		GameObject brick6 = Instantiate(brick, new Vector3(-14, 0.5f, -15), Quaternion.identity);
		bricks.Add(brick5);
		bricks.Add(brick6);

		for (int i = 1; i <= 4; i++) {
			GameObject brick7 = Instantiate(brick, new Vector3(-2, 0.5f, -i * 3), Quaternion.identity);
			GameObject brick8 = Instantiate(brick, new Vector3(-5, 0.5f, -i * 3), Quaternion.identity);
			GameObject brick9 = Instantiate(brick, new Vector3(-8, 0.5f, -i * 3), Quaternion.identity);
			GameObject brick10 = Instantiate(brick, new Vector3(-11, 0.5f, -i * 3), Quaternion.identity);

			bricks.Add(brick7);
			bricks.Add(brick8);
			bricks.Add(brick9);
			bricks.Add(brick10);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
