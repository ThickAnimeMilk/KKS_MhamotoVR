﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Valve.VR;

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
             TrackersManager = FindObjectOfType<SteamVR_ControllerManager>();

            // Getting camera and controllers
            cameraEye = hscene.flags.managerVR.objCamera;
            controllers[Side.Left] = hscene.flags.managerVR.objMove.transform.Find("Controller (left)").gameObject;
            controllers[Side.Right] = hscene.flags.managerVR.objMove.transform.Find("Controller (right)").gameObject;

            TrackerSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            // Setting up the tracker
            MyTracker.transform.parent = cameraEye.transform.parent;
            SteamVR_TrackedObject MyTrackedObject = MyTracker.AddComponent<SteamVR_TrackedObject>() as SteamVR_TrackedObject;
            int TrackerIndex = (int)FindTrackerIndex();
            MyTrackedObject.SetDeviceIndex(TrackerIndex);
            TrackersManager.objects.SetValue(MyTracker, TrackerIndex);


            //VRViveController MyTrackerViveDummy = MyTracker.AddComponent<VRViveController>() as VRViveController;
            //MyTrackerViveDummy.

            //Attach Sphere to tracker
            TrackerSphere.transform.position = MyTracker.transform.position;
            //TrackerSphere.transform.parent = MyTracker.transform;
            TrackerSphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);


        }

        public void LateUpdate()
        {
            TrackerSphere.transform.position = MyTracker.transform.position;

            if (cameraEye)
            {
                var myLogSource = BepInEx.Logging.Logger.CreateLogSource("MyLogSource");

                myLogSource.LogInfo("Right Controller pos: ");
                myLogSource.LogInfo(controllers[Side.Right].transform.position);
                myLogSource.LogInfo("Tracker pos: ");
                myLogSource.LogInfo(MyTracker.transform.position);
                myLogSource.LogInfo("TrackerSphere pos: ");
                myLogSource.LogInfo(TrackerSphere.transform.position);

                BepInEx.Logging.Logger.Sources.Remove(myLogSource);
            }
            if (false)
            {
                var myLogSource = BepInEx.Logging.Logger.CreateLogSource("MyLogSource");

                if (TrackersManager)
                {
                    myLogSource.LogInfo("SteamVRControllerManager found! Printing tracked objects: ");
                    foreach (GameObject obj in TrackersManager.objects)
                        myLogSource.LogInfo(obj.name);
                }
                else
                {
                    myLogSource.LogInfo("No SteamVRControllerManager found");
                }

                BepInEx.Logging.Logger.Sources.Remove(myLogSource);
            }

        }

        uint FindTrackerIndex()
        {
            uint index = 0;
            var error = ETrackedPropertyError.TrackedProp_Success;
            for (uint i = 0; i < 16; i++)
            {
                var result = new System.Text.StringBuilder((int)64);
                OpenVR.System.GetStringTrackedDeviceProperty(i, ETrackedDeviceProperty.Prop_RenderModelName_String, result, 64, ref error);
                if (result.ToString().Contains("tracker"))
                {
                    index = i;
                    return index;
                }
            }
            return 0;
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
        internal GameObject MyTracker = new GameObject("MyTracker");
        internal GameObject TrackerSphere;
        internal SteamVR_ControllerManager TrackersManager;

    }
}
