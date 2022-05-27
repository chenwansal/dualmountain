using System;
using UnityEngine;

namespace DualMountain.WorldBusiness {

    public class RoleEntity : MonoBehaviour {

        public float moveSpeed;
        public float fallingSpeed;
        public float jumpSpeed;

        Rigidbody rb;

        Transform mesh;

        void Awake() {
            
            rb = GetComponent<Rigidbody>();
            mesh = transform.GetChild(0);

            Debug.Assert(rb != null);
            Debug.Assert(mesh != null);

        }

        public void Move(Transform cameraTransform, Vector2 moveAxis) {

            float y = rb.velocity.y;

            Vector3 fwd = cameraTransform.forward * moveAxis.y;
            Vector3 right = cameraTransform.right * moveAxis.x;

            Vector3 moveDir = fwd + right;
            moveDir.Normalize();

            rb.velocity = moveDir * moveSpeed;
            Vector3 velo = rb.velocity;
            velo.y = y;
            rb.velocity = velo;

        }

        public void Jump(float jumpAxis) {
            if (jumpAxis <= 0) {
                return;
            }
            Vector3 velo = rb.velocity;
            velo.y = jumpSpeed;
            rb.velocity = velo;
        }

        public void Falling(float fixedDeltaTime) {
            Vector3 velo = rb.velocity;
            float y = velo.y;
            y -= fallingSpeed * fixedDeltaTime;
            velo.y = y;
            rb.velocity = velo;
        }

    }

}