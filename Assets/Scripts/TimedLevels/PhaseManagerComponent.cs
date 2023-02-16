using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Phase
{
    //length in seconds of the phase. if phase duration is set to 0, the phase will be indefinite and the manager will be disabled
    public float duration;
    //the weapon switched to for this phase
    public BulletSpawnData weapon;

    public List<GameObject> bulletPool;
    Phase(float _duration, BulletSpawnData _weapon)
    {
        duration = _duration;
        weapon = _weapon;
        bulletPool = new List<GameObject>();
    }
}

public class PhaseManagerComponent : MonoBehaviour
{
    //maybe phases should be stored on the enemy? idk just feels like enemy data that this would be operating on
    public List<Phase> phases;

    //index initialised as 0 (first phase in list)
    int currentPhaseIndex = 0;

    //stores the time counted down throughout a phase
    float timeRemaining;

    //BulletSpawner bulletSpawner;

    public Phase getPhase()
    {
        return phases[currentPhaseIndex];
    }

    public void setPhase(int phaseIndex)
    {
        //if phase exceeds list, disable the manager
        //this means when it reaches the end of the list it will just stay in the last phase
        if (phaseIndex >= phases.Count) { enabled = false; return; }

        //if the index is valid, set current phase
        currentPhaseIndex = phaseIndex;

        //set the timer to the new phase duration
        timeRemaining = getPhase().duration;
    }

    // Start is called before the first frame update
    void Start()
    {
        //else, set phase to initial index
        setPhase(currentPhaseIndex);
    }

    // Update is called once per frame
    void Update()
    {
        //count down phase timer
        timeRemaining -= Time.deltaTime;

        //if phase isn't over, continue to next update
        if (timeRemaining >= 0) return;

        //else,begin new phase (set timer to duration and equip weapon)
        setPhase(currentPhaseIndex+1);
        
    }
}
