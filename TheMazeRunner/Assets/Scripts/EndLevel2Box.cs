using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel2Box : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel("Level3");
        }
    }
}
