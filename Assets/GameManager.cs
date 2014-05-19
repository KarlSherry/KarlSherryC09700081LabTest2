using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	// Game Mananger creates a bot list and an ammo list
	// Sets bots to start off in the Patrolling State with a randomised target

	public GameObject bot;
	int botNumber = 5;
	List<GameObject> botList = new List<GameObject>();

	public GameObject ammo;
	int ammoNumber = 10;
	List<GameObject> ammoList = new List<GameObject> ();

	void Start () { 

		for (int i = 0; i < botNumber; i++) 
		{
			GameObject botClone = Instantiate(bot, transform.position, transform.rotation) as GameObject;
			botList.Add (botClone);
		}

		GameObject[] enemyBots = GameObject.FindGameObjectsWithTag ("bot");

		foreach (GameObject bot in botList) {
			GameObject enemyBot = enemyBots[Random.Range(0, 4)];

			if(enemyBot == bot)
				enemyBot = enemyBots[Random.Range(0, 4)]; // Trying to ensure a bot is not it's own enemy...

			bot.GetComponent<StateMachine>().SwitchState(new PatrolState(bot, enemyBot));
	
		}

		for (int i = 0; i < ammoNumber; i++) 
		{
			GameObject ammoClone = Instantiate(ammo, transform.position, transform.rotation) as GameObject;
			ammoList.Add (ammoClone);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
