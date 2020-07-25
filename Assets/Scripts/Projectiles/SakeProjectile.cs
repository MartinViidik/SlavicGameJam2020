using UnityEngine;

public class SakeProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject SakeVisual;
    private float rotationModifier;

    private void Awake()
    {
        Destroy(gameObject, 2f);
        rotationModifier = Random.Range(1, 3);
    }
    private void Update()
    {
        SakeVisual.transform.Rotate(0, 0, (120 * rotationModifier) * Time.deltaTime);
    }
}
