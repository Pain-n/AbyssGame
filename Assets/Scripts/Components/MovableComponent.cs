using System;
using UnityEngine;

namespace Assets.Scripts.Components
{
    [Serializable]
    public struct MovableComponent
    {
        public Rigidbody Rb;
        public float Speed;
        public float SmoothRotationTime;
    }
}
