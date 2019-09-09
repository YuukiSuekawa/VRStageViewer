using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

namespace VRStageViewer
{
    public class StageCharaController : StageCharaBaseController
    {
        // TODO NavMeshAgentでのハマりバグ有 調査中
        
        #region Varialble
        private NavMeshAgent navAgent = null;
        private bool moveTrg = false;
        private bool forceTrg = false;
        [SerializeField] private float navSpeed = 1.0f;
        [SerializeField] private float walkSpeed = 0.2f;
        #endregion Variable

        private const string ANIM_IDLE = "Idle";
        private const string ANIM_REST = "Rest";
        private const string ANIM_JUMP = "Jump";
        private const string ANIM_SPEED = "Speed";

        private int m_animHashRest;
        private int m_animHashIdle;
        

        protected override void Awake()
        {
            base.Awake();
            m_animHashIdle = Animator.StringToHash("Base Layer." + ANIM_IDLE); 
            m_animHashRest = Animator.StringToHash("Base Layer." + ANIM_REST); 
            navAgent = GetComponent<NavMeshAgent>();
            navAgent.speed = navSpeed;
        }

        protected override void Start()
        {
            base.Start();
            
        }

        protected override void Update()
        {
            if (moveTrg && navAgent.remainingDistance < 1f)
            {
                MotionIdle();
            }
        }
        
        
        public void Move(Vector3 pointVec,bool callFlg = false)
        {
            // todo ここの制御を変えていきたい
            // todo ストックした動作を処理していく形にしていきたい
            if (!forceTrg)
            {
                if (callFlg)
                {
                    // todo forceTrgON → その方向へ向かう → ついたらアクション → moveTrg,forceTrgオフ
                    SetMotionAppeal(pointVec,walkSpeed);
                }
                else if (moveTrg)
                {
                    SetMovePoint(pointVec);
                }
                else
                {

                    MotionWalkRun(pointVec, walkSpeed);
                }
            }
        }

        public bool IsMoving()
        {
            return moveTrg;
        }

        private void MotionWalkRun(Vector3 pointVec,float speed)
        {
            SetMovePoint(pointVec);
            SetAnimFloat(ANIM_SPEED, speed);
            moveTrg = true;
        }

        private void SetMotionAppeal(Vector3 pointVec,float speed)
        {
            MotionWalkRun(pointVec,speed);
            Debug.Log("SetMotionAppeal");
            forceTrg = true;
            StartCoroutine(CheckMoveedAppealPoint());


            // todo アピール用のモーション実行
            // todo フリーモーションよりもランク上にする
            // todo 一度だけ動かしてそのあとは切る
        }

        IEnumerator CheckMoveedAppealPoint()
        {
            while (true)
            {
                if (AnimState.nameHash == m_animHashIdle)
                {
                    MotionApeel();
                    break;
                }
                else
                {
                    yield return null;
                }                
            }
        }

        private void MotionApeel()
        {
            SetAnimBool(ANIM_REST,true);
            StartCoroutine(CheckAppealEnd());

        }

        IEnumerator CheckAppealEnd()
        {
            while (true)
            {
                if (AnimState.nameHash == m_animHashRest)
                {
                    SetAnimBool(ANIM_REST,false);
                    yield return new WaitForSeconds(AnimState.length);
                    forceTrg = false;
                    break;
                }
                else
                {
                    yield return null;
                }
            }
        }

        private void MotionIdle()
        {
            SetAnimFloat(ANIM_SPEED,0.0f);
            moveTrg = false;
        }

        protected override void SetMovePoint(Vector3 pointVec)
        {
            if(navAgent != null)
                navAgent.destination = pointVec;
        }        

    }
}