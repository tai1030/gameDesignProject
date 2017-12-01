using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 offset;
    public float speed;
    private GameObject target;

	// Use this for initialization
	void Start () {
        target = GameManager.Instance.Player.gameObject;
        offset = transform.position - target.transform.position;
        transform.LookAt(target.transform);
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKey(KeyCode.UpArrow)){
            transform.position += Vector3.up * speed * Time.deltaTime;
            offset = transform.position - GameManager.Instance.Player.transform.position;
        }else if (Input.GetKey(KeyCode.DownArrow)){
            transform.position += Vector3.down * speed * Time.deltaTime;
            offset = transform.position - GameManager.Instance.Player.transform.position;
        }else if (Input.GetKeyUp(KeyCode.LeftArrow)){
            if(target != null){
                if(target == GameManager.Instance.Player.gameObject){
                    GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
                    if(objects != null && objects.Length > 0){
                        target = objects[0];
                    }else{
                        target = GameManager.Instance.Player.gameObject;
                    }
                }else{
                    GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
                    int i = 0;
                    for (; i < objects.Length; i++)
                    {
                        if (target == objects[i])
                        {
                            break;
                        }
                    }
                    if(i == (objects.Length-1)){
                        target = GameManager.Instance.Player.gameObject;
                    }else{
                        target = objects[i + 1];
                    }
                }
            }else{
                target = GameManager.Instance.Player.gameObject;
            }
            transform.LookAt(target.transform);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow)){
            if (target != null)
            {
                if (target == GameManager.Instance.Player.gameObject)
                {
                    GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
                    if (objects != null && objects.Length > 0)
                    {
                        target = objects[0];
                    }
                    else
                    {
                        target = GameManager.Instance.Player.gameObject;
                    }
                }
                else
                {
                    GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
                    int i = objects.Length-1;
                    for (; i >= 0; i--)
                    {
                        if (target == objects[i])
                        {
                            break;
                        }
                    }
                    if (i == 0)
                    {
                        target = GameManager.Instance.Player.gameObject;
                    }
                    else
                    {
                        target = objects[i - 1];
                    }
                }
            }
            else
            {
                target = GameManager.Instance.Player.gameObject;
            }
            transform.LookAt(target.transform);
        }

	}

    void LateUpdate()
	{
		if (GameManager.Instance.Player == null) {
			transform.position = Vector3.zero + offset;
		} else {
            transform.position = target.transform.position + offset;
		}

    }
}
