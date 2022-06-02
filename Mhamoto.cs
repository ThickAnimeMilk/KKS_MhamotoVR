using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace KKS_MhamotoVR
{
    public partial class Mhamoto : MonoBehaviour
    {
        public void Init(HSprite _hsprite, List<MotionIK> _lstMotionIK)
        {
            hSprite = _hsprite;
            lstMotionIK = _lstMotionIK;
        }

        public void Start()
        {

        }

        public void LateUpdate()
        {

        }

        internal HSprite hSprite;
        private List<MotionIK> lstMotionIK;
    }
}
