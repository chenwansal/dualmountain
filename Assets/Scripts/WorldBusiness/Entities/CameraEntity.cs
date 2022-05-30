using System;
using UnityEngine;
using Cinemachine;

namespace DualMountain.WorldBusiness {

    public class CameraEntity : MonoBehaviour {

        // Model
        public float sensitivity = 1f;
        public bool isRevertY;

        CinemachineVirtualCamera cm;
        CinemachineFramingTransposer transposer;
        Transform stand;

        void Awake() {
            
            stand = transform;
            cm = GetComponentInChildren<CinemachineVirtualCamera>();
            transposer = cm.GetCinemachineComponent<CinemachineFramingTransposer>();

            Debug.Assert(cm != null);
            Debug.Assert(transposer != null);

        }

        public void Follow(Transform target) {
            cm.Follow = target;
        }

        public void RotateHorizontal(float horizontalAxis) {
            Vector3 eular = new Vector3(0, horizontalAxis * sensitivity, 0);
            stand.transform.Rotate(eular);
        }

        public void RotateVertical(float verticalAxis) {
            verticalAxis = isRevertY ? -verticalAxis : verticalAxis;
            Vector3 eular = new Vector3(verticalAxis * sensitivity, 0, 0);
            cm.transform.Rotate(eular);
        }

        public void PullDistance(float distanceOffset) {
            transposer.m_CameraDistance += distanceOffset;
        }

    }

}