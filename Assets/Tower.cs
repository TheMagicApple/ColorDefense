using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class Tower : MonoBehaviour {

	// As a fraction of the screen width
	public static float RANGE_LONG = 1.0f;
	public static float RANGE_MEDIUM = 0.25f;
	public static float RANGE_SHORT = 0.125f;

	// In seconds per bullet
	public static float FIRERATE_HIGH = 1.0f;
	public static float FIRERATE_MEDIUM = 0.5f;
	public static float FIRERATE_LOW = 0.25f;

	// As a fraction of enemy health
	public static float DAMAGE_HIGH = 0.5f;
	public static float DAMAGE_MEDIUM = 0.25f;
	public static float DAMAGE_LOW = 0.1f;
	

	// Instance variables
	private float rotationAngle;
	public bool enemyToShoot;
	public GameObject bullet;

	
	// Start is called before the first frame update
    void Start() {
        this.rotationAngle = this.transform.localRotation.eulerAngles.z;
		this.enemyToShoot = false;
	    StartCoroutine(this.shoot());
		
    }


	private GameObject getClosestEnemy() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closestEnemy = null;
		int closestDistance = 2147483647;
		
		foreach (GameObject enemy in enemies) {
			int x = (int) enemy.transform.position.x;
			int y = (int) enemy.transform.position.y;
			int myX = (int) this.transform.position.x;
			int myY = (int) this.transform.position.y;

			int distance = (int) Math.Sqrt(Math.Pow(x - myX, 2) + Math.Pow(y - myY, 2));
			if (distance < closestDistance) {
				closestEnemy = enemy;
				closestDistance = distance;
			}
		}

		return closestEnemy;
	}


	public bool inRange() {
		GameObject closestEnemy = this.getClosestEnemy();
		if (closestEnemy == null)
			return false;
		
		float enemyX = closestEnemy.transform.position.x;
		float enemyY = closestEnemy.transform.position.y;
		float myX = this.transform.position.x;
		float myY = this.transform.position.y;

		float aspect = (float) Screen.width / Screen.height;
		float worldHeight = Camera.main.orthographicSize * 2;
		float worldWidth = worldHeight * aspect;

		float distance = (float) Math.Sqrt(Math.Pow(enemyX - myX, 2) + Math.Pow(enemyY - myY, 2));
		return distance <= worldWidth * getRange();
	}
	

    /**
	 * Updates this {@code GameObject} every frame.
	 */
    void Update() {
        GameObject closestEnemy = this.getClosestEnemy();
		this.enemyToShoot = closestEnemy != null;
		if (closestEnemy == null)
			return;

		// Rotate to face the enemy
		float enemyX = closestEnemy.transform.position.x;
		float enemyY = closestEnemy.transform.position.y;
		float myX = this.transform.position.x;
		float myY = this.transform.position.y;
		float dx = enemyX - myX;
		float dy = enemyY - myY;
			
		float theta = 0;
		if (dy != 0)
			theta = (dx) < 0 ?
				Mathf.Atan(dy / dx) + Mathf.PI :
				Mathf.Atan(dy / dx);
		float thetaDeg = theta * (180f / Mathf.PI) - 90;

		this.transform.Rotate(0f, 0f, (thetaDeg - this.rotationAngle));
		this.rotationAngle = thetaDeg;
    }

	
	public IEnumerator shootDefault() {
		yield return new WaitForSeconds(getShootingCooldown());
		if(this.enemyToShoot && this.inRange()) {
		    GameObject bulletObj = Instantiate(this.bullet,
											   this.transform.position,
											   this.transform.rotation);
			bulletObj.GetComponent<Bullet>().setDamage(getDamage());
		}
		StartCoroutine(this.shoot());
	}


	public abstract float getShootingCooldown();
	public abstract float getDamage();
	public abstract float getRange();
	public abstract IEnumerator shoot();
	
}
