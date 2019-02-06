using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameBoxBehavior : MonoBehaviour {

    public Transform gameManager;
    GameBehavior script;

	// Use this for initialization
	void Start () {
        script = gameManager.GetComponent<GameBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!script.isStarted)
            {
                script.startGame();
            }
        }
    }
}
