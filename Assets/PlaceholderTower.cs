using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderTower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = Input.mousePosition;
 		v3.z = 10.0f;
 		v3 = Camera.main.ScreenToWorldPoint(v3);
        transform.position=v3;
        
    }
}
