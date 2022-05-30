using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DualMountain {

    // 输入类
    public class InputEntity {

        InputActionsBase inputActions;

        public event Action<Vector2> OnMoveHandle;
        public event Action<float> OnJumpHandle;

        public InputEntity() {

            inputActions = new InputActionsBase();

            inputActions.Player.Move.started += OnMove;
            inputActions.Player.Move.performed += OnMove;
            inputActions.Player.Move.canceled += OnMove;

            inputActions.Player.Jump.started += OnJump;

            inputActions.Enable();

        }

        void OnMove(InputAction.CallbackContext ctx) {
            OnMoveHandle.Invoke(ctx.ReadValue<Vector2>());
        }

        void OnJump(InputAction.CallbackContext ctx) {
            OnJumpHandle.Invoke(ctx.ReadValue<float>());
        }

    }

}