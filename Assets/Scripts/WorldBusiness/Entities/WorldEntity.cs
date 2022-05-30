using System;
using UnityEngine;

namespace DualMountain.WorldBusiness {

    public class WorldEntity : MonoBehaviour {

        // ==== CAMERA ====
        CameraEntity cameraEntity; // 场景内相机
        public CameraEntity CameraEntity => cameraEntity;

        // ==== ROOT GROUP ====
        Transform spawnerGroup;
        public Transform SpawnerGroup => spawnerGroup;

        Transform cameraGroup;
        public Transform CameraGroup => cameraGroup;

        void Awake() {
            
            // ==== GROUP ====
            spawnerGroup = transform.Find("SPAWNER_GROUP");
            cameraGroup = transform.Find("CAMERA_GROUP");

            Debug.Assert(spawnerGroup != null);
            Debug.Assert(cameraGroup != null);

            // ==== CAMERA ====
            cameraEntity = cameraGroup.GetChild(0).GetComponent<CameraEntity>();
            Debug.Assert(cameraEntity != null);

        }

    }

}