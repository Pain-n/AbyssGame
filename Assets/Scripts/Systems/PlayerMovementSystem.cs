using Assets.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<MovableComponent, DirectionComponent, CameraComponent> movableIFilter = null;

        private float turnSmoothVelocity;
        public void Run()
        {           
            foreach (var i in movableIFilter)
            {
                ref var movableComponent = ref movableIFilter.Get1(i);
                ref var directionComponent = ref movableIFilter.Get2(i);
                ref var cameraComponent = ref movableIFilter.Get3(i);

                if(directionComponent.Direction != Vector3.zero)
                {
                    float targetAngle = Mathf.Atan2(directionComponent.Direction.x, directionComponent.Direction.z) * Mathf.Rad2Deg + cameraComponent.Camera.transform.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(movableComponent.Rb.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, movableComponent.SmoothRotationTime);
                    movableComponent.Rb.rotation = Quaternion.Euler(0, angle, 0);

                    Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                    movableComponent.Rb.MovePosition(movableComponent.Rb.transform.position + moveDirection.normalized * movableComponent.Speed * Time.fixedDeltaTime);
                }
            }
        }
    }
}
