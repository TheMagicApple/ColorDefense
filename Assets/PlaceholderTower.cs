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

		if (!ClickManager.canPlace(v3.x, v3.y))
			this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.66f, 0.66f);
		else
		    this.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f);
    }
}
