using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapStandBehavior : MonoBehaviour {

    public Text txtInstructions;
    public Text txtMapModeTimer;
    public SphereCollider PlayerMarker;
    public GameObject Player;
    public Camera mapCamera;

    bool isTrigger;
    bool isMapCameraMode = false;
    int StartTimeCount;
    int numOfSecond;
    int timer;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F) && isMapCameraMode == false)
            {
                PlayerMarker.gameObject.SetActive(true);
                Player.GetComponent("Camera").gameObject.SetActive(false);
                mapCamera.gameObject.SetActive(true);
                //Player.SetActive(false);
                txtInstructions.text = "";
                isMapCameraMode = true;
                StartTimeCount = (int)Time.time;
            }

            if(isMapCameraMode)
            {
                numOfSecond = (int)Time.time;
                timer = (5 - (numOfSecond - StartTimeCount));
                txtMapModeTimer.text = "" + timer;

                if(timer == 0)
                {
                    isMapCameraMode = false;
                    PlayerMarker.gameObject.SetActive(false);
                    Player.GetComponent("Camera").gameObject.SetActive(true);
                    mapCamera.gameObject.SetActive(false);
                    //Player.SetActive(true);
                    txtInstructions.text = "Press F To Show The Map";
                    txtMapModeTimer.text = "";
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            txtInstructions.text = "Press F To Show The Map";
            isTrigger = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            txtInstructions.text = "";
            PlayerMarker.gameObject.SetActive(false);
            isTrigger = false;
        }
    }
}
