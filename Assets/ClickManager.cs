using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ClickManager : MonoBehaviour {
	
    public GameObject blueTower;
    public GameObject greenTower;
    public GameObject orangeTower;
    public GameObject purpleTower;
	
    GameObject[] towers;

    private static List<GameObject> towersPlaced=new List<GameObject>();
    // Start is called before the first frame update
    void Start() {
        towers=new GameObject[]{blueTower,greenTower,orangeTower,purpleTower};
    }


	public static bool canPlace(float x, float y) {
		foreach(GameObject tower in ClickManager.towersPlaced){
			float distance = Mathf.Sqrt(Mathf.Pow(x - tower.transform.position.x, 2) +
										Mathf.Pow(y - tower.transform.position.y, 2));
			if (distance < 0.5f)
				return false;
		}
		return true;
	}
	

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0) && ButtonManager.towerPlacing>0) {
            Vector3 v3 = Input.mousePosition;
 		    v3.z = 10.0f;
 		    v3 = Camera.main.ScreenToWorldPoint(v3);
            bool canPlace = ClickManager.canPlace(v3.x, v3.y);
			
            if (canPlace) {
                ClickManager.towersPlaced.Add(Instantiate(towers[ButtonManager.towerPlacing - 1],
														  v3, Quaternion.identity));
                ButtonManager.towerPlacing=0;
            }
        }
    }
   
}
