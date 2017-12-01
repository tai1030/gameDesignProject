using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    public enum ITEM { KEY, SPEED, FIRE, HP, NULL, EMTPY };
    public ITEM item = ITEM.NULL;
    private bool isItemActive = false;
    private ParticleSystem ps;
    public bool psEnabled;

	// Use this for initialization
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        var emission = ps.emission;
        emission.enabled = psEnabled;

	}

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.CompareTag("Player"))
        {
            if(isItemActive){
                switch (item)
                {
                    case ITEM.KEY:
                        GameManager.Instance.isGameWin = true;
                        GameManager.Instance.AddScore(100);
                        break;
                    case ITEM.SPEED:
                        collision.gameObject.GetComponent<PlayerMovement>().speed += 1;
                        GameManager.Instance.AddScore(10);
                        break;
                    case ITEM.FIRE:
                        collision.gameObject.GetComponent<PlayerMovement>().bombPrefab.gameObject.GetComponent<Bomb>().range += 1;
                        GameManager.Instance.AddScore(10);
                        break;
                    case ITEM.HP:
                        collision.gameObject.GetComponent<PlayerHealth>().currentHealth += 10;
                        GameManager.Instance.AddScore(10);
                        break;
                }
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(item);
        if(item != ITEM.NULL){
			if (other.CompareTag("Explosion")) {
                if(isItemActive)
                {
                    if (item != ITEM.KEY)
                    {
                        Destroy(this.gameObject);
                    }
                }else{
                    StartCoroutine(setItemActive());
                }
            }
        }
    }

    IEnumerator setItemActive()
    {
        psEnabled = true;
        switch (item)
        {
            case ITEM.KEY:
                ps.startColor = new Color(0, 128, 0);
                GetComponent<Renderer>().material.color = new Color(0, 128, 0);//green
                break;
            case ITEM.SPEED:
                ps.startColor = new Color(0, 0, 255);
                GetComponent<Renderer>().material.color = new Color(0, 0, 255);//blue
                break;
            case ITEM.FIRE:
                ps.startColor = new Color(255, 165, 0);
                GetComponent<Renderer>().material.color = new Color(255, 165, 0);//orange
                break;
            case ITEM.HP:
                ps.startColor = new Color(255, 0, 0);
                GetComponent<Renderer>().material.color = new Color(255, 0, 0);//red
                break;
            case ITEM.EMTPY:
                Destroy(this.gameObject);
                break;
        }
        yield return new WaitForSeconds(1);
        isItemActive = true;
    }
}
