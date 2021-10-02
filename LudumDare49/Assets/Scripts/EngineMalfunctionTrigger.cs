using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineMalfunctionTrigger : MonoBehaviour
{
    public float randomTime;
    public float time = 0;
    public bool engineMalfunction = false;
    // Update is called once per frame

    void Update()
    {
        //update time every second
        //check if the engine event is already triggered
        if (!engineMalfunction)
        {
            time += Time.deltaTime;
            //if engine event is not already triggered, check if current time is greater than set malfunction time
            if (time >= randomTime)
            {
                //if true then engine malfunction is true and event starts
                EventManager.current.engineMalfunctionEvent();
                Debug.Log("Engine Malfunction!!!");

            }
        }
    }

    public float SetRandomTime(float minTime, float maxTime)
    {
        randomTime = UnityEngine.Random.Range(minTime, maxTime);
        return randomTime;
    }
}
