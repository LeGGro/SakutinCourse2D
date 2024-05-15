using Assets.HW_2DPlatformer.Scripts.Entities.Common.Helpers;
using UnityEngine;

namespace Assets.HW_2DPlatformer.Scripts.Entities.PlayerRep.Bases
{
    public abstract class PlayerMoverBase: MonoBehaviour
    {
        public abstract void Move(float HorizontalAxis);
        public abstract void Jump();
        public abstract void Initialize(Rigidbody2D rigidbody, DirectionFlipper flipper);
    }
}
