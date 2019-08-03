using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace VRStageViewer
{
    public class UserControllManager : MonoBehaviour
    {
        public class Vector3Callback : UnityEvent<Vector3>{}
        public Vector3Callback approachCallbackEvent = new Vector3Callback();

        [SerializeField] private Vector3[] positions;
        private int posId;
        
        private OVRPlayerController ovrPlayerController = null;
        private Transform myTrans;
#if DEBUG
        private OVRDebugConsole console;
#endif
        void Start()
        {
            posId = 0;
            ovrPlayerController = GetComponent<OVRPlayerController>();
#if DEBUG
            console = OVRDebugConsole.instance;
#endif
            myTrans = GetComponent<Transform>();
            myTrans.LookAt(Vector3.zero);
        }

        void Update()
        {
            // TODO ここのボタンの反応良すぎるから時間制限設けたい
            
            if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKey(KeyCode.A))
            {
                SetApproach();
            }

            if (OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKey(KeyCode.Z))
            {
                ChangeViewPosition();
            }

            if (OVRInput.GetDown(OVRInput.Button.Three))
            {
#if DEBUG
                console.AddMessage("Button Three", Color.white);
#endif                
            }
        }

        void SetApproach()
        {
#if DEBUG
            console.AddMessage("SetApproach", Color.white);
#endif
            Vector3 pos = myTrans.position;
            approachCallbackEvent.Invoke(pos);            
        }

        void ChangeViewPosition()
        {
#if DEBUG
            console.AddMessage("ChangeViewPosition", Color.white);
#endif
            // 中心へ向くようにする
            if (posId < positions.Length - 1)
            {
                posId++;
            }
            else
            {
                posId = 0;
            }
            myTrans.position = positions[posId];
#if DEBUG
            console.AddMessage("" + myTrans.position, Color.white);
#endif
            // TODO VRでやったときになんかすごい方向になってしまうから別の方法を考える
//            myTrans.LookAt(Vector3.zero);
        }
    }
}