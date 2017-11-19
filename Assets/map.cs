using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour {

    public GameObject box;

    private List<GameObject> boxes;

	// Use this for initialization
	void Start () {
        boxes = new List<GameObject>();
        for (int i = 0; i <= 25; i++)
        {
            GameObject box1 = Instantiate(box, new Vector3(1, 0, -i), Quaternion.identity);
            GameObject box2 = Instantiate(box, new Vector3(-25, 0, -i), Quaternion.identity);
            GameObject box3 = Instantiate(box, new Vector3(-i, 0, 0), Quaternion.identity);
            GameObject box4 = Instantiate(box, new Vector3(-i, 0, -25), Quaternion.identity);
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
