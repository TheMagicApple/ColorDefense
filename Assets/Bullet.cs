using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float damage;
	
	
    // Start is called before the first frame update
    void Start() {
		
    }

    // Update is called once per frame
    void FixedUpdate() {
        this.transform.position += this.transform.up * 0.25f;

		float aspect = (float) Screen.width / Screen.height;
		float worldHeight = Camera.main.orthographicSize * 2;
		float worldWidth = worldHeight * aspect;

		if (this.transform.position.x < -worldWidth/2 || this.transform.position.x > worldWidth/2 ||
			this.transform.position.y < -worldHeight || this.transform.position.y > worldHeight)
			Destroy(this.gameObject);
    }

	
	public void OnTriggerEnter2D(Collider2D c) {
		if (c.tag == "Enemy") {
			c.gameObject.GetComponent<Enemy>().damage(this.damage);
			Destroy(this.gameObject);
		}
	}


	public void setDamage(float damage) {
		this.damage = damage;
	}
	
}
