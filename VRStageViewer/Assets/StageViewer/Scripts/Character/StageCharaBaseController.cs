using UnityEngine;

namespace VRStageViewer
{
    public abstract class StageCharaBaseController : MonoBehaviour
    {
        #region Variable

        private Animator m_anim = null;
        protected Animator Anim
        {
            get { return m_anim; }
        }

        protected AnimatorStateInfo AnimState
        {
            get { return m_anim.GetCurrentAnimatorStateInfo(0); }
        }
        #endregion Variable

        protected virtual void Awake()
        {
            m_anim = GetComponent<Animator>();
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
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
            if(m_anim != null)
                m_anim.SetFloat(paramName,value);
        }

        protected float GetAnimFloat(string paramName)
        {
            if (m_anim != null)
                return m_anim.GetFloat(paramName);

            return -1f;
        }

        protected void SetAnimInt(string paramName, int value)
        {
            if(m_anim != null)
                m_anim.SetInteger(paramName,value);
        }

        protected void SetAnimBool(string paramName, bool value)
        {
            if(m_anim != null)
                m_anim.SetBool(paramName,value);
        }

        protected void SetAnimTrigger(string paramName, bool value)
        {
            if (value)
            {
                m_anim.SetTrigger(paramName);
            }
            else
            {
                m_anim.ResetTrigger(paramName);
            }
        }
    }
}