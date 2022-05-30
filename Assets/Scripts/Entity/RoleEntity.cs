using System;
using UnityEngine;

namespace DualMountain.WorldBusiness {

    public class RoleEntity : MonoBehaviour {

        // Model
        public float moveSpeed;
        public float jumpForce;
        public float fallingSpeed;

        bool isJump;

        // MVVM
        Rigidbody rb;
        BoxCollider footCollider;

        // Renderer
        Transform mesh;
        public Transform Mesh => mesh;

        void Awake() {

            rb = GetComponent<Rigidbody>();
            mesh = transform.GetChild(0);
            footCollider = transform.GetChild(1).GetComponent<BoxCollider>();

            Debug.Assert(rb != null);
            Debug.Assert(mesh != null);
            Debug.Assert(footCollider != null);

        }

        public void Move(Transform cameraTransform, Vector2 moveAxis) {

            float y = rb.velocity.y;

            Vector3 moveDir = cameraTransform.forward * moveAxis.y + cameraTransform.right * moveAxis.x;
            moveDir.Normalize();

            rb.velocity = moveDir * moveSpeed;
            Vector3 velo = rb.velocity;
            velo.y = y;
            rb.velocity = velo;

        }

        public void Jump(float jumpAxis) {

            if (isJump) {
                return;
            }

            Vector3 velo = rb.velocity;
            velo.y = jumpForce;
            rb.velocity = velo;

            isJump = true;

        }

        static RaycastHit[] tempHits = new RaycastHit[8];
        public void CheckGround(float fixedDeltaTime) {
            float fallingSpeed = rb.velocity.y * fixedDeltaTime;
            fallingSpeed = Math.Abs(fallingSpeed);
            LayerMask groundLayer = 1 << 6;
            int count = Physics.BoxCastNonAlloc(footCollider.transform.position, footCollider.size, Vector3.down, tempHits, footCollider.transform.rotation, fallingSpeed, groundLayer);
            for (int i = 0; i < count; i += 1) {
                var hit = tempHits[i];
                if (hit.collider.gameObject.CompareTag("Ground")) {
                    if (rb.velocity.y <= 0) {
                        isJump = false;
                    }
                    break;
                }
                Debug.Log("Hit: " + hit.collider.gameObject.name);
            }
        }

        public void Falling(float fixedDeltaTime) {
            Vector3 velo = rb.velocity;
            velo.y -= fixedDeltaTime * fallingSpeed;
            rb.velocity = velo;
        }

        void OnDrawGizmos() {
            if (footCollider == null) {
                footCollider = transform.GetChild(1).GetComponent<BoxCollider>();
            }
            Gizmos.color = Color.red;
            Gizmos.DrawCube(footCollider.transform.position, footCollider.size);
        }

    }

}