using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourComponent : MonoBehaviour
{
    //this stores weapon phases, movement behaviours and states

    BulletSpawner bulletSpawner;

    //now enemies have to have phase managers.. 
    PhaseManagerComponent phaseManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawner = GetComponent<BulletSpawner>();
        phaseManager = GetComponent<PhaseManagerComponent>();

        phaseManager.setPhase(0);
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpawner.SpawnBullets(phaseManager.getPhase().weapon, phaseManager.getPhase().bulletPool);
    }
}
