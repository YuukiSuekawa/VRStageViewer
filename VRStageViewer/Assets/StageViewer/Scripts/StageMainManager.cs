using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace VRStageViewer
{
    public class StageMainManager : MonoBehaviour
    {
        private OVRDebugConsole console;

        [SerializeField] private StageCharactersManager charaManager;
        [SerializeField] private StageFieldManager fieldManager;
        [SerializeField] private UserControllManager userCtrlManager;

        
        void Start()
        {
#if DEBUG
            console = OVRDebugConsole.instance;
            console.AddMessage("ここでSetPressOneCallBackは実行している",Color.white);
#endif
            charaManager.Init(null,fieldManager.GetMovePoint());
            SetEvent();
            StartCoroutine(MoveLoop());
        }

        void Update()
        {
            
        }
        
        
        private IEnumerator MoveLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(6f);
                charaManager.SetCharactersMove(fieldManager.GetMovePoint());
            }
        }
        
        
        #region CharaEvent

        private void SetEvent()
        {
            userCtrlManager.approachCallbackEvent.AddListener(UserApproachToChara);
        }


        public void UserApproachToChara(Vector3 pointVec)
        {
            console.AddMessage("キャラへのApproach",Color.white);
            charaManager.SetCharactersMove(pointVec);
        }
        #endregion CharaEvent
        
        #region StageEvent
        #endregion StageEvent
    }
}