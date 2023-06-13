using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {




	public static Vector2[] PATH = new Vector2[] {new Vector2(1.22f, 1.50f),
												  new Vector2(1.22f, -4.55f)};
	

	private int maxHealth;
	private int health;
	private int targetIndex;
	private float rotationAngle;
	
	
    // Start is called before the first frame update
    void Start() {
		this.maxHealth = 100;
        this.health = this.maxHealth;
		this.targetIndex = 0;
		this.rotationAngle = this.transform.localRotation.eulerAngles.z;
    }

	
    // Update is called once per frame
    void Update() {
		// Check if the enemy reached the goal
		if (this.targetIndex >= Enemy.PATH.Length) {
			Destroy(this.gameObject);
			Debug.Log("enemy reached the goal");
			return;
		}

		// Current target for the enemy to move to
        Vector2 target = Enemy.PATH[this.targetIndex];

		// Rotate to face the target point on the path
		float targetX = target.x;
		float targetY = target.y;
		float myX = this.transform.position.x;
		float myY = this.transform.position.y;
		float dx = targetX - myX;
		float dy = targetY - myY;
			
		float theta = 0;
		if (dy != 0)
			theta = (dx) < 0 ?
				Mathf.Atan(dy / dx) + Mathf.PI :
				Mathf.Atan(dy / dx);
		float thetaDeg = theta * (180f / Mathf.PI) - 90;

		this.transform.Rotate(0f, 0f, (thetaDeg - this.rotationAngle));
		this.rotationAngle = thetaDeg;

		// Move the enemy
		this.transform.position += this.transform.up * 0.01f;
		myX = this.transform.position.x;
		myY = this.transform.position.y;

		// Check if in range of the target
		float margin = 0.1f;
	    if (myX > targetX - margin && myX < targetX + margin &&
			myY > targetY - margin && myY < targetY + margin)
		{
			this.targetIndex++;
		}
    }


	public void damage(float damage) {
		this.health -= (int) (this.maxHealth * damage);

		if (this.health <= 0)
			MoneyManager.money+=5;
			Debug.Log(MoneyManager.money);
			Destroy(this.gameObject);
	}
}
