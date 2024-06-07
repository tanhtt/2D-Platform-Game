using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayerState = wraped_city_game.PlayerCtrl.PlayerState;
using ShootState = wraped_city_game.PlayerCtrl.ShootState;

namespace wraped_city_game
{
    public abstract class PlayerAnimationBase : MonoBehaviour
    {
        public abstract void UpdateAnimation(PlayerState state);
        public abstract void UpdateShootAnim(ShootState shootstate);
    }
}

