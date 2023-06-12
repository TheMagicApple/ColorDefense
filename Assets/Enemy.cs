using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private int health;
	
	
    // Start is called before the first frame update
    void Start() {
        this.health = 100;
    }

	
    // Update is called once per frame
    void Update() {
        this.transform.position += new Vector3(Random.Range(-0.1f, 0.1f),
											   Random.Range(-0.1f, 0.1f), 0);
    }


	public void damage() {
		this.health -= 25;

		if (this.health <= 0)
			Destroy(this.gameObject);
	}
}
