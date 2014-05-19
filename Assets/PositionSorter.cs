using UnityEngine;
using System.Collections;

public class PositionSorter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (Random.Range (-20, 20), 0, Random.Range (-20, 20));

		if (this.tag == "ammo") {
						this.renderer.material.color = Color.red;
				} else if (this.tag == "health") {
						this.renderer.material.color = Color.green;
				} else {
					this.renderer.material.color = Color.blue;
		}
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
