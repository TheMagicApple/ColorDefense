using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BlueTower : Tower {

	public override float getShootingCooldown() {
		return 0.25f;
	}


	public override int getDamage() {
		return 25;
	}


	public override float getRange() {
		return 2.0f;
	}
	
}
