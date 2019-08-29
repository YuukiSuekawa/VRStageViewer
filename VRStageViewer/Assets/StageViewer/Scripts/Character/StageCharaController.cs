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
            if (moveTrg)
            {
                SetMovePoint(pointVec);
            }
            else
            {
                MotionStart(pointVec,walkSpeed);
            }
        }

        public bool IsMoving()
        {
            return moveTrg;
        }

        private void MotionStart(Vector3 pointVec,float speed)
        {
            SetMovePoint(pointVec);
            SetAnimFloat("Speed", speed);
            moveTrg = true;
        }

        private void MotionIdle()
        {
            SetAnimFloat("Speed",0.0f);
            moveTrg = false;
        }

        protected override void SetMovePoint(Vector3 pointVec)
        {
            if(navAgent != null)
                navAgent.destination = pointVec;
        }

    }
}