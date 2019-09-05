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
        [SerializeField] private float navSpeed = 1.0f;
        [SerializeField] private float walkSpeed = 0.2f;
        #endregion Variable

        private const string ANIM_REST = "Rest";
        private const string ANIM_JUMP = "Jump";
        private const string ANIM_SPEED = "Speed";

        protected override void Awake()
        {
            base.Awake();
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
        
        
        public override void Move(Vector3 pointVec)
        {
            // todo ここの制御を変えていきたい
            // todo ストックした動作を処理していく形にしていきたい
            if (moveTrg)
            {
                SetMovePoint(pointVec);
            }
            else
            {
                
                MotionWalkRun(pointVec,walkSpeed);
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

        private void MotionAppeal()
        {
            // todo アピール用のモーション実行
            // todo フリーモーションよりもランク上にする
            // todo 一度だけ動かしてそのあとは切る
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