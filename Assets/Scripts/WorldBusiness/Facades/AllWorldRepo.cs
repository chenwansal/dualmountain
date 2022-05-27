using System;

namespace DualMountain.WorldBusiness.Facades {

    public static class AllWorldRepo {

        static RoleEntity roleEntity;
        public static RoleEntity RoleEntity => roleEntity;
        public static void SetRoleEntity(RoleEntity roleEntity) => AllWorldRepo.roleEntity = roleEntity;

    }
}