using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRStageViewer
{
    public class StageMainManager : MonoBehaviour
    {
        // TODO これでこのシーンにおける全体統括命令を出す
        // TODO 細かい管理は各管理クラスに任せる
        // TODO ここでやるのは「開始」「終了」の管理くらい
        [SerializeField] private StageCharactersManager charaManager;
        [SerializeField] private StageFieldManager fieldManager;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(MoveLoop());
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
        
        private IEnumerator MoveLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(6f);
                charaManager.Init(null,fieldManager.GetMovePoint());
            }
        }
    }
}