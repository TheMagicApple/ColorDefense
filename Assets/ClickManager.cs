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

    List<GameObject> towersPlaced=new List<GameObject>();
    // Start is called before the first frame update
    void Start() {
        towers=new GameObject[]{blueTower,greenTower,orangeTower,purpleTower};
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0) && ButtonManager.towerPlacing>0) {
            Vector3 v3 = Input.mousePosition;
 		    v3.z = 10.0f;
 		    v3 = Camera.main.ScreenToWorldPoint(v3);
            bool bad=false;
            foreach(GameObject tower in towersPlaced){
                double distance = Math.Sqrt(Math.Pow(v3.x - tower.transform.position.x, 2) + Math.Pow(v3.y - tower.transform.position.y, 2));
                if(distance<1f){
                    bad=true;
                    break;
                }
            }
            if(!bad){
                towersPlaced.Add(Instantiate(towers[ButtonManager.towerPlacing-1],v3,Quaternion.identity));
                ButtonManager.towerPlacing=0;
            }
            
            
        }
    }
   
}
