using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	
    public GameObject enemy;

	
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(this.spawn());
    }

    // Update is called once per frame
    void Update() {
        
    }

    private IEnumerator spawn() {
        yield return new WaitForSeconds(1);
        Instantiate(this.enemy, this.transform.position, Quaternion.identity);
        StartCoroutine(this.spawn());
    }
}