using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    bool clicking=false;
    public GameObject blueTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            clicking=true;
            Vector3 v3 = Input.mousePosition;
 		    v3.z = 10.0f;
 		    v3 = Camera.main.ScreenToWorldPoint(v3);
            Instantiate(blueTower,v3,Quaternion.identity);
        }else{
            clicking=false;
        }
    }
   
}
