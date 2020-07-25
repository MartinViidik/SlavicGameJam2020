using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject objectRef;

    [SerializeField]
    private float minDelay;
    [SerializeField]
    private float maxDelay;

    private GameObject spawnedSake;

    private void Awake()
    {
        StartSpawnDelay();
    }

    private IEnumerator SpawnDelay()
    {
        float delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);
        SpawnItem();

    }

    void SpawnItem()
    {
        spawnedSake = Instantiate(objectRef, transform.position, Quaternion.identity);
        spawnedSake.GetComponent<SakeSupplies>().parent = GetComponent<ObjectSpawner>();
    }

    public void StartSpawnDelay()
    {
        StartCoroutine("SpawnDelay");
    }
}
