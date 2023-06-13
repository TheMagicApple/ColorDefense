using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	private int round;
    public GameObject enemy;

    public static bool lost=false;
    public GameObject endPanel;
	
    // Start is called before the first frame update
    void Start() {
		this.round = 1;
        StartCoroutine(this.spawn());
		StartCoroutine(this.incrementRound());
    }
	

    // Update is called once per frame
    void Update() {
        if(lost){
            endPanel.SetActive(true);
        }
    }
	

    private IEnumerator spawn() {
        yield return new WaitForSeconds(Enemy.getSpawnDelay());
        Instantiate(this.enemy, this.transform.position, Quaternion.identity);
        if(!lost) StartCoroutine(this.spawn());
    }

	
	public IEnumerator incrementRound() {
		yield return new WaitForSeconds(10);
		if (this.round % 3 == 0)
			Enemy.increaseSpawnSpeed();
		if (this.round % 3 == 1)
			Enemy.decreaseSpawnDelay();
		if (this.round % 3 == 2)
			Enemy.increaseSpawnHealth();
		this.round++;
		StartCoroutine(incrementRound());
	}
	
}
