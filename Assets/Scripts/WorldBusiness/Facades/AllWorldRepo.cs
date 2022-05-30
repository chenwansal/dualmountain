using System;
using UnityEngine;
using Cinemachine;

namespace DualMountain.WorldBusiness.Facades {

    public static class AllWorldRepo {

        // 世界类
        static WorldEntity worldEntity;
        public static WorldEntity WorldEntity => worldEntity;
        public static void SetWorldEntity(WorldEntity world) => worldEntity = world;

        // 角色
        static RoleEntity roleEntity;
        public static RoleEntity RoleEntity => roleEntity;
        public static void SetRoleEntity(RoleEntity role) => roleEntity = role;

        public static void Ctor() {

        }

    }
}