using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {


	/**
	 * Path finding algorithm
	 *
	 * 1) Array of points, in order, to visit
	 * 2) Each enemy has a current point index
	 * 3) In Update() rotate and move towards that point
	 * 4) If in range of that point, go to next point
	 * 5) If reached the end (currentPoint + 1 is out of bounds of the array), then
	 *    that enemy reached the goal ==> the player loses or their base takes damage
	 */

	public static Vector2[] PATH = new Vector2[] {new Vector2(1.22f, 1.50f),
												  new Vector2(1.22f, -4.55f)};
	

	private int health;
	private int targetIndex;
	private float rotationAngle;
	
	
    // Start is called before the first frame update
    void Start() {
        this.health = 100;
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


	public void damage() {
		//this.health -= 25;

		if (this.health <= 0)
			Destroy(this.gameObject);
	}
}
