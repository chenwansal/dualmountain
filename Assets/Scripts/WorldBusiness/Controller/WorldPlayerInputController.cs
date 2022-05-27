using System;
using UnityEngine;
using UnityEngine.InputSystem;
using DualMountain.Facades;

namespace DualMountain.WorldBusiness.Controllers {

    public class WorldPlayerInputController {

        public WorldPlayerInputController() { }

        public void Init() {
            var input =  AllGlobalRepo.InputEntity;
            input.OnMoveHandle += OnMove;
        }

        public void Tick() {

        }

        // INPUT EVENT
        void OnMove(Vector2 moveAxis) {
            var player = AllGlobalRepo.PlayerEntity;
            player.moveAxis = moveAxis;

            Debug.Log("Move: " + moveAxis);
        }

    }
}