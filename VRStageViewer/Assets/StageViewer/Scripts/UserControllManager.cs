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

        private bool isPushed = false;
        
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
            // 中心に向かせる
            myTrans.LookAt(Vector3.zero);
        }

        void Update()
        {
            
            if (!isPushed && (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKey(KeyCode.A)))
            {
                isPushed = true;
                SetApproach();
            }
            
            if(isPushed && (OVRInput.GetUp(OVRInput.Button.One) || Input.GetKeyUp(KeyCode.A)))
            {
                isPushed = false;
            }

            if (!isPushed && (OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKey(KeyCode.Z)))
            {
                isPushed = true;
                ChangeViewPosition();
            }
            
            if(isPushed && (OVRInput.GetUp(OVRInput.Button.Two) || Input.GetKeyUp(KeyCode.Z)))
            {
                isPushed = false;
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

            // MEMO PlayerControllerをONにしたまま移動させようとすると、意図しない動きになってしまう
            // MEMO そのため、一度dissable状態にして処理後に戻す
            // リニア移動を一旦停止
            ovrPlayerController.enabled = false;

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
            // VRでやったときにLockAtでどんどん傾くので正面向くよう修正
            myTrans.LookAt(new Vector3(0,myTrans.position.y,0));

            // リニア移動復活
            ovrPlayerController.enabled = true;
        }
    }
}