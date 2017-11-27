using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - GameManager.Instance.Player.transform.position;
		transform.LookAt(GameManager.Instance.Player.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
	{
		if (GameManager.Instance.Player == null) {
			transform.position = Vector3.zero + offset;
		} else {
			transform.position = GameManager.Instance.Player.transform.position + offset;
		}
    }
}
