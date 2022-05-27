using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DualMountain {

    public class PlayerInputEntity {

        PlayerInputActionsBase inputActions;

        public event Action<Vector2> OnMoveHandle;

        public PlayerInputEntity() {
            inputActions = new PlayerInputActionsBase();

            inputActions.Player.Move.started += OnMove;
            inputActions.Player.Move.performed += OnMove;
            inputActions.Player.Move.canceled += OnMove;

            inputActions.Enable();

        }

        void OnMove(InputAction.CallbackContext ctx) {
            Vector2 moveAxis = ctx.ReadValue<Vector2>();;
            OnMoveHandle.Invoke(moveAxis);
        }

    }

}