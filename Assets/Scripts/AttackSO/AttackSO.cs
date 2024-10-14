using System;
using UnityEngine;

[CreateAssetMenu(menuName = "AttackSystem/Attack")]
public class AttackSO : ScriptableObject
{
    public AnimatorOverrideController AnimOV;
    public AttackBodyPart AttackColliders;
    public float Damage;
}

[Flags]
public enum AttackBodyPart
{ 
    RightArm = 1,
    LeftArm = 2,
    RightLeg = 4,
    LeftLeg = 8
}

