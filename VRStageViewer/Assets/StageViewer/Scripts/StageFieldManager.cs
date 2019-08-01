using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRStageViewer
{
    public class StageFieldManager : MonoBehaviour
    {
        [SerializeField] private Transform[] movePoints;


        public Vector3 GetMovePoint()
        {
            int randNum = Random.Range(0,movePoints.Length);
            return movePoints[randNum].position;
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