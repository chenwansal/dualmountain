using System;
using UnityEngine;
using DualMountain.Facades;
using DualMountain.WorldBusiness.Controllers;
using DualMountain.WorldBusiness.Facades;

namespace DualMountain.WorldBusiness {

    public class WorldEntry {

        WorldPlayerInputController playerInputController;

        public WorldEntry() {}

        public void Ctor() {
            playerInputController = new WorldPlayerInputController();
        }

        public void Init() {
            playerInputController.Init();
        }

        public void Tick() {
            playerInputController.Tick();
        }

        public void FixedTick(float fixedDeltaTime) {

            // TEST
            var player =  AllGlobalRepo.PlayerEntity;

            var role = AllWorldRepo.RoleEntity;
            if (role == null) {
                role = GameObject.Find("go_role").GetComponent<RoleEntity>();
                AllWorldRepo.SetRoleEntity(role);
            }
            role.Move(Camera.main.transform, player.moveAxis);

            role.Jump(player.jumpAxis);

            role.Falling(fixedDeltaTime);

            player.jumpAxis = 0;

        }

    }

}