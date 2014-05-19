using UnityEngine;
using System.Collections;

public class PatrolState : State {

	GameObject enemyGameObject;

	public override string Description()
	{
		return "Patrol State";
	}

	public PatrolState(GameObject myGameObject, GameObject enemyGameObject)
		: base(myGameObject)
	{
		this.enemyGameObject = enemyGameObject;
	}
	
	public override void Enter()
	{
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20)));
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20)));
		myGameObject.GetComponent<SteeringBehaviours>().path.Looped = true;            
		myGameObject.GetComponent<SteeringBehaviours>().path.draw = true;
		myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
		myGameObject.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;
	}
	public override void Exit()
	{
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Clear();
	}
	
	public override void Update()
	{
		if(Vector3.Dot(myGameObject.transform.forward, enemyGameObject.transform.position) < (Mathf.PI / 4.0f))
		{
			myGameObject.GetComponent<StateMachine>().SwitchState(new AttackingState(myGameObject, enemyGameObject));
		}
	}
}
