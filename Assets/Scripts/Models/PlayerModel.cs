using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerModel
{
    public Rigidbody RB;
    public Animator Animator;
    public float SmoothRotationTime;
    public float MoveSpeed;
    public float RunSpeed;
    public float CrouchSpeed;
    public float JumpForce;

    [HideInInspector]
    public Vector2 Direction;
    [HideInInspector]
    public bool IsInAir;
    [HideInInspector]
    public bool IsAttacking;

    public ColliderListModel AttackCollidersList;
}

