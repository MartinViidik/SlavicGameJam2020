using System.Collections.Generic;
using Enemy;
using UnityEngine;
using Utility;

public class SakeProjectile : MonoBehaviour {

    [SerializeField] private GameObject SakeVisual;
    private float rotationModifier;
    
    public List<AudioClip> sakeThrowSound;
    public List<AudioClip> sakeBreakSound;

    private void Awake() {
        Destroy(gameObject, 2f);
        rotationModifier = Random.Range(1, 3);
        SoundManager.PlaySoundFromList(sakeThrowSound);
    }

    private void Update() {
        transform.Rotate(0, 0, (120 * rotationModifier) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemyController = collision.gameObject.GetComponent<EnemyController>();
        if (enemyController)
        {
            enemyController.OnHit();
        }
        Destroy(gameObject);
        SoundManager.PlaySoundFromList(sakeBreakSound);
    }

}