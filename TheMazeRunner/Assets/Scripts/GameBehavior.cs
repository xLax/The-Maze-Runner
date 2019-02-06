using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour {

    public int startGameTime = 0;
    public int gameTimeSeconds = 0;
    public int gameTimeMinutes = 0;
    public bool isStarted = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        int numOfSeconds = (int)Time.time - startGameTime;

        if(isStarted)
        {
            if(numOfSeconds < 60)
            {
                gameTimeSeconds = numOfSeconds;
            }
            else if(numOfSeconds / 60 == 1)
            {
                gameTimeSeconds = numOfSeconds - 60;
                gameTimeMinutes = 1;
            }
            else if(numOfSeconds / 60 == 2)
            {
                gameTimeSeconds = numOfSeconds - 120;
                gameTimeMinutes = 2;
            }
            else
            {
                Application.LoadLevel("LosingScreen");
            }
        }
		
	}

    private void OnGUI()
    {
        string gameSeconds;
        if(gameTimeSeconds < 10)
        {
            gameSeconds = "0" + gameTimeSeconds;
        }
        else
        {
            gameSeconds = "" + gameTimeSeconds;
        }
        GUI.Label(new Rect(10, 10, 200, 20), "Time Left: " + gameTimeMinutes + ":" + gameSeconds + " / 3:00");
    }

    public void startGame()
    {
        if(isStarted == false)
        {
            isStarted = true;
            startGameTime = (int)Time.time;
        }
    }
}
