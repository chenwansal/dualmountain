using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DualMountain {

    public class PlayerInputEntity {

        PlayerInputActionsBase inputActions;

        public event Action<Vector2> OnMoveHandle;
        public event Action<float> OnJumpHandle;

        public PlayerInputEntity() {
            inputActions = new PlayerInputActionsBase();

            inputActions.Player.Move.started += OnMove;
            inputActions.Player.Move.performed += OnMove;
            inputActions.Player.Move.canceled += OnMove;

            inputActions.Player.Jump.started += OnJump;

            inputActions.Enable();

        }

        void OnMove(InputAction.CallbackContext ctx) {
            Vector2 moveAxis = ctx.ReadValue<Vector2>();;
            OnMoveHandle.Invoke(moveAxis);
        }

        void OnJump(InputAction.CallbackContext ctx) {
            float jumpAxis = ctx.ReadValue<float>();
            OnJumpHandle.Invoke(jumpAxis);
        }

    }

}