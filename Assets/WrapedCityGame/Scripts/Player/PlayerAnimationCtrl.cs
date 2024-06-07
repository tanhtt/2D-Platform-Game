using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState = wraped_city_game.PlayerCtrl.PlayerState;
using ShootState = wraped_city_game.PlayerCtrl.ShootState;

namespace wraped_city_game
{
    public class PlayerAnimationCtrl : PlayerAnimationBase
    {
        private Animator _animCtrl;
        // Start is called before the first frame update
        void Start()
        {
            _animCtrl = GetComponent<Animator>();
        }

        public override void UpdateAnimation(PlayerState state)
        {
            int maxLoop = Enum.GetValues(typeof(PlayerState)).Length;
            for (int i = 0; i < maxLoop; i++)
            {
                if(state == (PlayerState)i)
                    _animCtrl.SetBool(((PlayerState)i).ToString(), true);
                else
                    _animCtrl.SetBool(((PlayerState)i).ToString(), false);
            }
        }

        public override void UpdateShootAnim(ShootState shootstate)
        {
            _animCtrl.SetFloat("Shoot", (int)shootstate);
        }
    }
}

