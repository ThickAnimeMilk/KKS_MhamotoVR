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
            if (true)
            {
                var myLogSource = BepInEx.Logging.Logger.CreateLogSource("MyLogSource");

                myLogSource.LogInfo("CameraEye pos: ");
                myLogSource.LogInfo(cameraEye.transform.position);
                myLogSource.LogInfo("Left Controller pos: ");
                myLogSource.LogInfo(controllers[Side.Left].transform.position);
                myLogSource.LogInfo("Right Controller pos: ");
                myLogSource.LogInfo(controllers[Side.Right].transform.position);

                BepInEx.Logging.Logger.Sources.Remove(myLogSource);
            }

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
