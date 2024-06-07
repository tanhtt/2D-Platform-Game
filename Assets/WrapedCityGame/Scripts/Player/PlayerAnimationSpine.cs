using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

using PlayerState = wraped_city_game.PlayerCtrl.PlayerState;

namespace wraped_city_game
{
    public class PlayerAnimationSpine : PlayerAnimationBase
    {
        [SerializeField] SkeletonAnimation _anim;
        [SpineAnimation]
        [SerializeField] string Idle, Run, Jump;
        PlayerState _currentState;

        private void Start()
        {
            _anim = GetComponent<SkeletonAnimation>();
        }

        public override void UpdateAnimation(PlayerState state)
        {
            if(state != _currentState)
            {
                _currentState = state;
                this.ChangeAnimation();
            }
        }

        void ChangeAnimation()
        {
            switch(_currentState)
            {
                case PlayerState.Idle:
                    _anim.state.SetAnimation(0, Idle, true);
                    break;
                case PlayerState.Run:
                    _anim.state.SetAnimation(0, Run, true);
                    break;
                case PlayerState.Jump:
                    _anim.state.SetAnimation(0, Jump, true);
                    break;
            }
        }

        public override void UpdateShootAnim(PlayerCtrl.ShootState shootstate)
        {
            throw new System.NotImplementedException();
        }
    }
}
