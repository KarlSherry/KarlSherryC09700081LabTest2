using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

	public GameObject bot;
	public float deSpawnTimer = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (this.renderer.enabled == false) {
			deSpawnTimer += Time.deltaTime;
		}

		if (Vector3.Distance (this.transform.position, bot.transform.position) < 1.0f) {
			this.renderer.enabled = false;
		}

		if (deSpawnTimer >= 10.0f) {
			this.renderer.enabled = true;
			deSpawnTimer = 0.0f;
		}
	}
}
