﻿using Pathfinding;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public AIPath aiPath;
    public Animator animator;
    private static readonly int MovementX = Animator.StringToHash("movementX");
    private static readonly int MovementY = Animator.StringToHash("movementY");
    private static readonly int Speed = Animator.StringToHash("speed");

    void FixedUpdate() {
        var desiredVelocity = aiPath.desiredVelocity;
        animator.SetFloat(MovementX, desiredVelocity.x);
        animator.SetFloat(MovementY, desiredVelocity.y);
        animator.SetFloat(Speed, desiredVelocity.magnitude);
        Debug.Log($"{desiredVelocity.x}/{desiredVelocity.y}/{desiredVelocity.magnitude}");
    }

}