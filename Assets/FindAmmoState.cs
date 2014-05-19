using UnityEngine;
using System.Collections;

public class FindAmmoState : State {

	GameObject enemyGameObject;

	public override string Description()
	{
		return "Find Ammo State";
	}

	public FindAmmoState(GameObject myGameObject, GameObject enemyGameObject)
		: base(myGameObject)
	{
		this.enemyGameObject = enemyGameObject;
	}
	
	public override void Enter ()
	{
		
		GameObject[] ammoList = GameObject.FindGameObjectsWithTag("ammo");
		myGameObject.GetComponent<SteeringBehaviours> ().TurnOffAll ();
		myGameObject.GetComponent<SteeringBehaviours> ().SeekEnabled = true;
		myGameObject.GetComponent<SteeringBehaviours> ().seekPos = ammoList[Random.Range(0,9)].transform.position;
	}

	public override void Exit()
	{
		myGameObject.GetComponent<SteeringBehaviours> ().TurnOffAll ();
	}

	// Update is called once per frame
	public override void Update () {
		if (Vector3.Distance (myGameObject.transform.position, myGameObject.GetComponent<SteeringBehaviours>().seekPos ) < 2.0f) {
			currentAmmo = 10;
			myGameObject.GetComponent<StateMachine>().SwitchState(new PatrolState(myGameObject, enemyGameObject));
		}
	}
}
