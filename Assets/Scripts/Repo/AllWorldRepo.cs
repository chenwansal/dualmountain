using System;
using UnityEngine;

namespace DualMountain.WorldBusiness.Facades {

    public static class AllWorldRepo {

        // 相机类
        static Camera camera;
        public static Camera Camera => camera;
        public static void SetCamera(Camera cam) => camera = cam;

        // 玩家类
        public static PlayerEntity PlayerEntity { get; private set; }

        // 输入类
        public static InputEntity InputEntity { get; private set; }

        // 角色
        static RoleEntity roleEntity;
        public static RoleEntity RoleEntity => roleEntity;
        public static void SetRoleEntity(RoleEntity role) => roleEntity = role;

        public static void Ctor() {

            PlayerEntity = new PlayerEntity();
            Debug.Log("PlayerEntity 生成");

            InputEntity = new InputEntity();
            Debug.Log("InputEntity 生成");
            
        }

    }
}