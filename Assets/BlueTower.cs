using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BlueTower : Tower {

	public override float getShootingCooldown() {
		return Tower.FIRERATE_MEDIUM;
	}


	public override float getDamage() {
		return Tower.DAMAGE_MEDIUM;
	}


	public override float getRange() {
		return Tower.RANGE_MEDIUM;
	}


	public override IEnumerator shoot() {
	    return base.shootDefault();
	}
	
}
