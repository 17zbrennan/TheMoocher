using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestLog : MonoBehaviour {

    private bool appleCollectionActive;
    private bool appleCollectionComplete;
    public int applesCollected;

    private bool helloToKnightActive;
    private bool helloToKnightComplete;

    private bool leaveMeActive;
    private bool leaveMeComplete;

    private bool comeBackActive;
    private bool comeBackComplete;

    List<bool> activeQuests;
    List<bool> completedQuests;

	// Use this for initialization
	void Start () {
        completedQuests = new List<bool>() {appleCollectionComplete,comeBackComplete,helloToKnightComplete, leaveMeComplete};
        activeQuests = new List<bool>() {appleCollectionActive,comeBackActive,helloToKnightActive, leaveMeActive};
    }
	
	// Update is called once per frame
	void Update () {
        //completedQuests = new List<bool>() { appleCollectionComplete, comeBackComplete, helloToKnightComplete, leaveMeComplete };
        //activeQuests = new List<bool>() { appleCollectionActive, comeBackActive, helloToKnightActive, leaveMeActive };
        for (int i = 0; i < activeQuests.Count; i++)
        {
            //Debug.Log("Checking for active quest...");
            //Debug.Log(activeQuests[i]);
            if(activeQuests[i])
            {
                Debug.Log("Found active quest...");
                switch(i)
                {
                    case 0:
                        Debug.Log("Checking apple quest");
                        checkAppleCollection();
                        break;
                    case 1:
                        Debug.Log("Checking dollar quest");
                        checkTwoDollars();
                        break;
                    case 2:
                        //No quest here
                        break;
                    case 3:
                        //No quest here
                        break;

                }
            }
        }
		
	}

    private void checkTwoDollars()
    {
        if(GetComponent<PlayerController>().getPlayerCoins() > 2)
        {
            comeBackComplete = true;
            comeBackActive = false;
            activeQuests.RemoveAt(1);
            activeQuests.Insert(1, comeBackActive);
            completedQuests.RemoveAt(1);
            completedQuests.Insert(1, comeBackComplete);
        }
    }

    public void setLeaveMe()
    {
        leaveMeComplete = true;
        leaveMeActive = false;
        activeQuests.RemoveAt(3);
        activeQuests.Insert(3, leaveMeActive);
        completedQuests.RemoveAt(3);
        completedQuests.Insert(3, leaveMeComplete);
    }

    public void setHelloToKnight()
    {
        helloToKnightComplete = true;
        helloToKnightActive= false;
        activeQuests.RemoveAt(2);
        activeQuests.Insert(2, helloToKnightActive);
        completedQuests.RemoveAt(2);
        completedQuests.Insert(2, helloToKnightComplete);
    }

    public void setQuestActive(int questID)
    {
        activeQuests[questID] = true;
    }

    public bool checkQuestCompleted(int questID)
    {
        return completedQuests[questID];
    }

    public bool checkQuestActive(int questID)
    {
        return activeQuests[questID];
    }

    public void checkAppleCollection()
    {
        if(applesCollected > 4)
        {
            appleCollectionComplete = true;
            appleCollectionActive = false;
            activeQuests.RemoveAt(0);
            activeQuests.Insert(0, appleCollectionActive);
            completedQuests.RemoveAt(0);
            completedQuests.Insert(0, appleCollectionComplete);
        }
    }

    
}
