using Assets.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> directionFilter = null;

        private float moveX;
        private float moveY;
        public void Run()
        {
            SetDirection();

            foreach (var i in directionFilter)
            {
                ref var directionComponent = ref directionFilter.Get2(i);

                directionComponent.Direction.x = moveX;
                directionComponent.Direction.z = moveY;
            }
        }

        private void SetDirection()
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
        }
    }
}
