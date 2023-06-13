using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GreenTower : Tower {

	public override float getShootingCooldown() {
		return Tower.FIRERATE_HIGH;
	}


	public override float getDamage() {
		return Tower.DAMAGE_LOW;
	}


	public override float getRange() {
		return Tower.RANGE_SHORT;
	}


	public override IEnumerator shoot() {
	    return base.shootDefault();
	}
	
}
