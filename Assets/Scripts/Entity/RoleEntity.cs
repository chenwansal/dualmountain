using System;
using UnityEngine;

namespace DualMountain.WorldBusiness {

    public class RoleEntity : MonoBehaviour {

        // Model
        public float moveSpeed;
        public float jumpForce;

        // MVVM
        Rigidbody rb;

        // Renderer
        Transform mesh;

        void Awake() {

            rb = GetComponent<Rigidbody>();
            mesh = transform.GetChild(0);

            Debug.Assert(rb != null);
            Debug.Assert(mesh != null);

        }

        public void Move(Transform cameraTransform, Vector2 moveAxis) {

            float y = rb.velocity.y;

            Vector3 moveDir = cameraTransform.forward * moveAxis.y + cameraTransform.right * moveAxis.x;
            moveDir.Normalize();

            rb.velocity = moveDir * 10f + new Vector3(0f, y, 0f);
            Vector3 velo = rb.velocity;
            velo.y = y;
            rb.velocity = velo;

        }

    }

}