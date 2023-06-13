using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PurpleTower : Tower {

	public override float getShootingCooldown() {
		return Tower.FIRERATE_LOW;
	}


	public override float getDamage() {
		return Tower.DAMAGE_MEDIUM;
	}


	public override float getRange() {
		return Tower.RANGE_MEDIUM;
	}


    public override IEnumerator shoot() {
		yield return new WaitForSeconds(this.getShootingCooldown());
		if(base.enemyToShoot && this.inRange()) {
			for (int i = 0; i < 3; i++) {
				GameObject bulletObj = Instantiate(base.bullet,
												   this.transform.position,
												   this.transform.rotation);
				new WaitForSeconds(0.5f);
				bulletObj.GetComponent<Bullet>().setDamage(this.getDamage());
			}
		}
		StartCoroutine(this.shoot());
	}
	
}
