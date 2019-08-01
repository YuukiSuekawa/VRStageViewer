using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

namespace VRStageViewer
{
    public class StageCharaController : MonoBehaviour
    {
        
        // TODO とりあえずUnityちゃんのアニメに沿ったものにする
        // TODO 今後拡張性は考える
        private NavMeshAgent navAgent = null;
        private bool moveTrg = false;
        private Animator anim = null;
        

        public void MoveStart(Vector3 pointVec)
        {
            if (!moveTrg)
            {
                MotionStart();
                navAgent.destination = pointVec;                
            }
        }

        private void MotionStart()
        {
            anim.SetFloat("Speed", 0.2f);
            moveTrg = true;
            navAgent.isStopped = false;
        }

        private void MotionIdle()
        {
            anim.SetFloat("Speed",0.0f);
            moveTrg = false;
        }

        // Start is called before the first frame update
        void Start()
        {
            navAgent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (moveTrg && navAgent.remainingDistance < 2f)
            {
                MotionIdle();
            }
        }
    }
}