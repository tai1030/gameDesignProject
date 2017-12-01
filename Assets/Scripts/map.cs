using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour {


    public GameObject player;
	public GameObject brick;
    public GameObject zomble;
	private List<GameObject> bricks;

	[HideInInspector] public int maxLevel = 3;

	// Use this for initialization
	void Start () {
        if (GameManager.level == 1)
        {
            GameObject zomble1 = Instantiate(zomble, new Vector3(0, 0, -14), Quaternion.identity);
            zomble1.GetComponent<EnemyMovement>().player = player;
        }
        else if (GameManager.level == 2)
        {
            GameObject zomble1 = Instantiate(zomble, new Vector3(0, 0, -14), Quaternion.identity);
            zomble1.GetComponent<EnemyMovement>().player = player;
            GameObject zomble2 = Instantiate(zomble, new Vector3(-14, 0, -14), Quaternion.identity);
            zomble2.GetComponent<EnemyMovement>().player = player;
        }
        else if (GameManager.level == 3)
        {
            GameObject zomble1 = Instantiate(zomble, new Vector3(0, 0, -14), Quaternion.identity);
            zomble1.GetComponent<EnemyMovement>().player = player;
            GameObject zomble2 = Instantiate(zomble, new Vector3(-14, 0, -14), Quaternion.identity);
            zomble2.GetComponent<EnemyMovement>().player = player;
            GameObject zomble3 = Instantiate(zomble, new Vector3(-14, 0, -1), Quaternion.identity);
            zomble3.GetComponent<EnemyMovement>().player = player;
        }

		bricks = new List<GameObject>();
		for (int i = 0; i <= 14; i++)
        {
			GameObject brick1 = Instantiate(brick, new Vector3(1, 0.5f, -i), Quaternion.identity);
			GameObject brick2 = Instantiate(brick, new Vector3(-14, 0.5f, -i), Quaternion.identity);
			GameObject brick3 = Instantiate(brick, new Vector3(-i, 0.5f, 0), Quaternion.identity);
			GameObject brick4 = Instantiate(brick, new Vector3(-i, 0.5f, -15), Quaternion.identity);
			//bricks.Add(brick1);
			//bricks.Add(brick2);
			//bricks.Add(brick3);
			//bricks.Add(brick4);
        }

		GameObject brick5 = Instantiate(brick, new Vector3(1, 0.5f, -15), Quaternion.identity);
		GameObject brick6 = Instantiate(brick, new Vector3(-14, 0.5f, -15), Quaternion.identity);
		//bricks.Add(brick5);
		//bricks.Add(brick6);

		for (int i = 1; i <= 4; i++) {
			GameObject brick7 = Instantiate(brick, new Vector3(-2, 0.5f, -i * 3), Quaternion.identity);
			GameObject brick8 = Instantiate(brick, new Vector3(-5, 0.5f, -i * 3), Quaternion.identity);
			GameObject brick9 = Instantiate(brick, new Vector3(-8, 0.5f, -i * 3), Quaternion.identity);
			GameObject brick10 = Instantiate(brick, new Vector3(-11, 0.5f, -i * 3), Quaternion.identity);
            GameObject brick11 = Instantiate(brick, new Vector3(-1, 0.5f, -i * 3 -1), Quaternion.identity);
            GameObject brick12 = Instantiate(brick, new Vector3(-4, 0.5f, -i * 3 -1), Quaternion.identity);
            GameObject brick13 = Instantiate(brick, new Vector3(-7, 0.5f, -i * 3 -1), Quaternion.identity);
            GameObject brick14 = Instantiate(brick, new Vector3(-10, 0.5f, -i * 3 -1), Quaternion.identity);

			bricks.Add(brick7);
			bricks.Add(brick8);
			bricks.Add(brick9);
			bricks.Add(brick10);
            bricks.Add(brick11);
            bricks.Add(brick12);
            bricks.Add(brick13);
            bricks.Add(brick14);
		}

        createItemList(bricks);
	}


    private void createItemList(List<GameObject> brickList)
    {
        List<BrickController.ITEM> itemList = new List<BrickController.ITEM>();
        itemList.Add(BrickController.ITEM.KEY);
        for (int i = 1; i < brickList.Count; i++){
            switch (i % (GameManager.level * 2 + 3))
            {
                case 0:
                    itemList.Add(BrickController.ITEM.SPEED);
                    break;
                case 1:
                    itemList.Add(BrickController.ITEM.FIRE);
                    break;
                case 2:
                    itemList.Add(BrickController.ITEM.HP);
                    break;
                case 3:
                    itemList.Add(BrickController.ITEM.ZOMBIE);
                    break;
                case 4:
                    if (GameManager.level >= 2)
                    {
                        itemList.Add(BrickController.ITEM.ZOMBIE);
                    }else{
                        itemList.Add(BrickController.ITEM.EMTPY);
                    }
                    break;
                case 5:
                    if (GameManager.level >= 3)
                    {
                        itemList.Add(BrickController.ITEM.ZOMBIE);
                    }
                    else
                    {
                        itemList.Add(BrickController.ITEM.EMTPY);
                    }
                    break;
                default:
                    itemList.Add(BrickController.ITEM.EMTPY);
                    break;
            }
        }
        foreach (GameObject brickA in brickList)
        {
            int index = Random.Range(0, itemList.Count);
            brickA.GetComponent<BrickController>().item = itemList[index];
            itemList.RemoveAt(index);
        }
        //foreach (GameObject brickA in brickList)
        //{
        //    Debug.Log(brickA.transform + ":" +  brickA.GetComponent<BrickController>().item);
        //}

    }

	// Update is called once per frame
	void Update () {
		
	}
}
