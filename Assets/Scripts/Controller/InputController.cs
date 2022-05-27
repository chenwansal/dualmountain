using System;
using UnityEngine;
using DualMountain.WorldBusiness.Facades;

namespace DualMountain.WorldBusiness.Controller {

    public class InputController {

        public InputController() {}

        public void Init() {

            // 绑定输入
            var input = AllWorldRepo.InputEntity;
            input.OnMoveHandle += OnMove;
            input.OnJumpHandle += OnJump;

        }

        void OnMove(Vector2 moveAxis) {
            // 获取玩家
            var player = AllWorldRepo.PlayerEntity;
            player.moveAxis = moveAxis;
        }

        void OnJump(float jumpAxis) {
            var player = AllWorldRepo.PlayerEntity;
            player.jumpAxis = jumpAxis;
        }

    }

}