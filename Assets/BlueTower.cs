using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BlueTower : MonoBehaviour {	
	
	private float rotationAngle;

	
	// Start is called before the first frame update
    void Start() {
        this.rotationAngle = this.transform.localRotation.eulerAngles.z;
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
	

    // Update is called once per frame
    void Update() {
        GameObject closestEnemy = this.getClosestEnemy();
		if (closestEnemy == null)
			return;
		
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
}
