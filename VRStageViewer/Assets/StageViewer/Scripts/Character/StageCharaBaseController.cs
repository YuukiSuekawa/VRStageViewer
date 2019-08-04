using UnityEngine;

namespace VRStageViewer
{
    public abstract class StageCharaBaseController : MonoBehaviour
    {
        #region Variable

        private Animator anim = null;
        protected Animator Anim
        {
            get { return anim; }
        }
        #endregion Variable
        
        protected virtual void Start()
        {
            anim = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            
        }

        public virtual void Move(Vector3 pointVec)
        {
            
        }
        
        protected virtual void MoveStart(Vector3 pointVec)
        {
            // 動かし方は様々なので継承クラスで作る前提
        }

        protected virtual void SetMovePoint(Vector3 pointVec)
        {
            
        }
        

        public virtual void MoveStop()
        {
            
        }

        public virtual void SetMotion()
        {
            
        }

        protected void SetAnimFloat(string paramName, float value)
        {
            anim.SetFloat(paramName,value);
        }

        protected void SetAnimInt(string paramName, int value)
        {
            anim.SetInteger(paramName,value);
        }

        protected void SetAnimBool(string paramName, bool value)
        {
            anim.SetBool(paramName,value);
        }

        protected void SetAnimTrigger(string paramName, bool value)
        {
            if (value)
            {
                anim.SetTrigger(paramName);
            }
            else
            {
                anim.ResetTrigger(paramName);
            }
        }
    }
}