using UnityEngine;

public class SakeSupplies : MonoBehaviour
{
    public ObjectSpawner parent;

    private void OnDestroy()
    {
        if (parent)
        {
            parent.GetComponent<ObjectSpawner>().StartSpawnDelay();
        }
    }
}
