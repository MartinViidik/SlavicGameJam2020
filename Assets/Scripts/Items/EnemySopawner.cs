using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySopawner : MonoBehaviour {

    [SerializeField] public List<GameObject> monstersToSpawn;

    public float waitTime = 1f;
    private bool cooldown;

    
    void FixedUpdate() {
        if (cooldown) return;
        var RNG = Random.Range(0, monstersToSpawn.Count);
        Instantiate(monstersToSpawn[RNG], transform);
        StartCoroutine("Cooldown");

    }

    private IEnumerator Cooldown() {
        cooldown = true;
        yield return new WaitForSeconds(waitTime);
        cooldown = false;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawIcon(transform.position, "BuildSettings.Lumin.small");
    }

}