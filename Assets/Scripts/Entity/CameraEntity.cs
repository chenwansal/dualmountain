using System;
using UnityEngine;
using Cinemachine;

namespace DualMountain.WorldBusiness {

    public class CameraEntity : MonoBehaviour {

        CinemachineVirtualCamera cm;
        Transform stand;

        void Awake() {
            
            stand = transform;
            cm = GetComponentInChildren<CinemachineVirtualCamera>();

            Debug.Assert(cm != null);

        }

        public void Follow(Transform target) {
            cm.Follow = target;
        }

    }

}