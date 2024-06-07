using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wraped_city_game
{
    public class PlayerCtrl : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField] private bool isOnGround;
        private Collider2D colli;
        [SerializeField] PlayerState _state;
        [SerializeField] ShootState _shootState;
        [SerializeField] float speed;
        [SerializeField] float jumpForce;


        [SerializeField] PlayerAnimationBase _animCtrl;
        [SerializeField] GunCtrl _gunCtrl;
        [SerializeField] LayerMask _layerMask;

        public enum PlayerState
        {
            Idle,
            Run,
            Jump
        }

        public enum ShootState
        {
            NotShoot,
            Shoot
        }

        // Start is called before the first frame update
        void Start()
        {
            // Lưu đệm component
            _rb = this.GetComponent<Rigidbody2D>();
            colli = this.GetComponent<Collider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Moving();
            UpdateState();
            CheckGround();
            _animCtrl.UpdateAnimation(_state);
            _animCtrl.UpdateShootAnim(_shootState);
            Shoot();
        }

        void UpdateState()
        {
            if (!isOnGround)
            {
                _state = PlayerState.Jump;
            }
            else if(isOnGround)
            {
                if (_rb.velocity.x != 0)
                {
                    _state = PlayerState.Run;
                }
                else
                {
                    _state = PlayerState.Idle;
                }
            }
            
        }

        void Shoot()
        {
            if (Input.GetKey(KeyCode.C))
            {
                _shootState = ShootState.Shoot;
                _gunCtrl.Fire();
                return;
            }
            _shootState = ShootState.NotShoot;
        }

        void Moving()
        {
            _rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), _rb.velocity.y);

            if(_rb.velocity.x > 0)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
            }
            else if(_rb.velocity.x < 0)
            {
                this.transform.localScale = new Vector3(-1, 1, 1);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                isOnGround = false;
                _rb.AddForce(new Vector2(0, jumpForce));
            }
        }

        void CheckGround()
        {
            RaycastHit2D[] hits = new RaycastHit2D[10];
            colli.Cast(Vector2.down, hits, 0.2f, true);

            foreach(RaycastHit2D hit in hits)
            {
                if(hit.collider != null)
                {
                    isOnGround = true;
                    return;
                }
            }
            isOnGround = false;
        }
    }
}
