using System;
using UnityEngine;
using DualMountain.Facades;
using DualMountain.WorldBusiness.Facades;

namespace DualMountain.WorldBusiness.Controller {

    public class RoleController {

        public RoleController() {}

        public void Tick(float deltaTime) {

            var world = AllWorldRepo.WorldEntity;
            if (world == null) {
                return;
            } 

            // 鼠标控制相机
            var player = AllGlobalRepo.PlayerEntity;
            var cam = world.CameraEntity;
            cam.RotateHorizontal(player.camRotateHorizontal);
            cam.RotateVertical(player.camRotateVertical);
            cam.PullDistance(player.pullDistance);

        }

        public void FixedTick(float fixedDeltaTime) {

            var role = AllWorldRepo.RoleEntity;
            if (role == null) {
                return;
            }

            var player = AllGlobalRepo.PlayerEntity;

            // 移动它
            Camera camera = AllGlobalRepo.MainCamera;
            Vector2 moveAxis = player.moveAxis;
            role.Move(camera.transform, moveAxis);

            // 跳
            float jumpAxis = player.jumpAxis;
            if (jumpAxis > 0) {
                role.Jump(jumpAxis);
                player.jumpAxis = 0;
            }

            // 下落
            role.Falling(fixedDeltaTime);

            // 落地检测
            role.CheckGround(fixedDeltaTime);

        }

    }

}