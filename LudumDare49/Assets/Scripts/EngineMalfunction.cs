using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineMalfunction : MonoBehaviour
{
    public GameObject truck;
    public EngineMalfunctionTrigger triggerScript;
    public float engineMaxTime = 10;
    public float engineMinTime = 20;
    public float timePassed = 0;
    public int id;

    private void Start()
    {
        triggerScript = truck.GetComponent<EngineMalfunctionTrigger>();
        EventManager.current.onEngineMalfunction += EngineEvent;
        triggerScript.randomTime = triggerScript.SetRandomTime(engineMinTime, engineMaxTime);
    }

    private void Update()
    {

    }
    private void EngineEvent()
    {
        //do event for x seconds. when event is finished engine malf is set to false and a new random time is created
        Debug.Log("Event occuring.");
        StartCoroutine(EngineMalfunctionOn());
        triggerScript.time = 0;
        triggerScript.randomTime = triggerScript.SetRandomTime(engineMinTime, engineMaxTime);
    }

    

    IEnumerator EngineMalfunctionOn()
    {
        while (timePassed < 10)
        {
            triggerScript.engineMalfunction = true;
            //do code
            timePassed += Time.deltaTime;
            yield return null;
        }
        timePassed = 0;
        Debug.Log("Finished");
        triggerScript.engineMalfunction = false;
        yield return null;
    }
}
