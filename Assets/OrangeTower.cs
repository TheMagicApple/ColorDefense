using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class OrangeTower : Tower {

	public override float getShootingCooldown() {
		return Tower.FIRERATE_LOW;
	}


	public override float getDamage() {
		return Tower.DAMAGE_HIGH;
	}


	public override float getRange() {
		return Tower.RANGE_LONG;
	}


	public override IEnumerator shoot() {
	    return base.shootDefault();
	}
	
}
