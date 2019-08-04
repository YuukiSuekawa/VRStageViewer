using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using VolumetricLines;

namespace VRStageViewer
{
    public class UserControllManager : MonoBehaviour
    {
        #region Variables
        public class Vector3Callback : UnityEvent<Vector3>{}
        public Vector3Callback approachCallbackEvent = new Vector3Callback();

        [SerializeField] private VolumetricLineBehavior leftLaser;
        [SerializeField] private VolumetricLineBehavior rightLaser;
        private int leftLaserColorId = 0;
        private int rightLaserColorId = 0;
        
        [SerializeField] private Vector3[] positions;
        private int posId;

        private bool isPushed = false;
        
        private OVRPlayerController ovrPlayerController = null;
        private Transform myTrans;

        private Vector3 centerPos;

        private static readonly Color[] laserColors =
        {
            Color.red,
            Color.magenta,
            Color.yellow,
            Color.green,
            Color.cyan,
            Color.blue,
        };
        
#if DEBUG
        private OVRDebugConsole console;
#endif
        #endregion Variables
        
        void Start()
        {
            posId = 0;
            ovrPlayerController = GetComponent<OVRPlayerController>();
#if DEBUG
            console = OVRDebugConsole.instance;
#endif
            myTrans = GetComponent<Transform>();
            centerPos = new Vector3(0,myTrans.position.y,0);
            // 中心に向かせる
            myTrans.LookAt(centerPos);
        }

        void Update()
        {
            ControllerInputUpdate();
        }

        private void ControllerInputUpdate()
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
                ChangeLaserColor(false);
            }
            
            if(isPushed && (OVRInput.GetUp(OVRInput.Button.Two) || Input.GetKeyUp(KeyCode.Z)))
            {
                isPushed = false;
            }

            if (!isPushed && (OVRInput.GetDown(OVRInput.Button.Three) || Input.GetKey(KeyCode.X)))
            {
                isPushed = true;
                ChangeViewPosition();
            }
            
            if(isPushed && (OVRInput.GetUp(OVRInput.Button.Three) || Input.GetKeyUp(KeyCode.X)))
            {
                isPushed = false;
            }
            
            if (!isPushed && (OVRInput.GetDown(OVRInput.Button.Four) || Input.GetKey(KeyCode.C)))
            {
                isPushed = true;
                ChangeLaserColor(true);
            }
            
            if(isPushed && (OVRInput.GetUp(OVRInput.Button.Four) || Input.GetKeyUp(KeyCode.C)))
            {
                isPushed = false;
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

            // 位置移動
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
            // 中心へ向くようにする
            myTrans.LookAt(centerPos);

            // リニア移動復活
            ovrPlayerController.enabled = true;
        }

        private void ChangeLaserColor(bool leftFlg)
        {
            VolumetricLineBehavior changeLaser = rightLaser;
            int id = rightLaserColorId;
            if (leftFlg)
            {
                changeLaser = leftLaser;
                id = leftLaserColorId;
            }

            if (id < laserColors.Length - 1)
            {
                id += 1;
            }
            else
            {
                id = 0;
            }
            changeLaser.LineColor = laserColors[id];

            if (leftFlg)
            {
                leftLaserColorId = id;
            }
            else
            {
                rightLaserColorId = id;
            }
        }
    }
}