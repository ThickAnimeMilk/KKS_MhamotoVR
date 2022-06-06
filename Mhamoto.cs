using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace KKS_MhamotoVR
{
    public partial class Mhamoto : MonoBehaviour
    {
        public void Init(VRHScene _hscene, List<MotionIK> _lstMotionIK)
        {
            hscene = _hscene;
            lstMotionIK = _lstMotionIK;
        }

        public void Start()
        {
            cameraEye = hscene.flags.managerVR.objCamera;
            controllers[Side.Left] = hscene.flags.managerVR.objMove.transform.Find("Controller (left)").gameObject;
            controllers[Side.Right] = hscene.flags.managerVR.objMove.transform.Find("Controller (right)").gameObject;

        }

        public void LateUpdate()
        {

        }

        //Init
        internal VRHScene hscene;
        private List<MotionIK> lstMotionIK;

        //Start
        private GameObject cameraEye;
        internal enum Side
        {
            Left,
            Right
        }

    }
}
