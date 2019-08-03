using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace VRStageViewer
{
    public class StageCharactersManager : MonoBehaviour
    {
        #region Variables
        
        // TODO 最終的にはアセットバンドルからもらう予定なのでこの配列のシリアライズ化は仮
        [SerializeField] private StageCharaController[] characters;
        #endregion Varialbles

        public void Init(string[] charaAssetNames,Vector3 pointVec)
        {
            if (charaAssetNames != null)
            {
                this.CharactersLoad(charaAssetNames);
            }
            else
            {
                Console.WriteLine("ロード未完成のためPlayへ");
                
                this.CharactersMoveStart(pointVec);
            }
        }

        private void CharactersLoad(string[] charaAssetNames)
        {
            // TODO 現段階ではインスペクタから直でもらう
            if (charaAssetNames != null)
            {
                // TODO 未実装
            }
            else
            {
                Console.WriteLine("ロードは未実装");
            }
        }

        private void CharactersMoveStart(Vector3 pointVec)
        {
            foreach (StageCharaController charaCtrl in characters)
            {
                charaCtrl.Move(pointVec);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}