using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour {

    public GameObject box;

    private List<GameObject> boxes;

	// Use this for initialization
	void Start () {
        boxes = new List<GameObject>();
		float bx = 0.5f;
		float bz = 0.5f;
		for (float i = 0; i <= 25; i++)
        {
			GameObject box1 = Instantiate(box, new Vector3(1+bx, 0, -i+bz), Quaternion.identity);
			GameObject box2 = Instantiate(box, new Vector3(-25+bx, 0, -i+bz), Quaternion.identity);
			GameObject box3 = Instantiate(box, new Vector3(-i+bx, 0, bz), Quaternion.identity);
			GameObject box4 = Instantiate(box, new Vector3(-i+bx, 0, -25+bz), Quaternion.identity);
            boxes.Add(box1);
            boxes.Add(box2);
            boxes.Add(box3);
            boxes.Add(box4);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
