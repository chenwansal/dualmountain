using System;

namespace DualMountain.WorldBusiness.Facades {

    public static class AllWorldEventCenter {

        static bool isTriggerSpawnWorld;
        public static bool IsTriggerSpawnWorld => isTriggerSpawnWorld;
        public static void SetTriggerSpawnWorld(bool value) => isTriggerSpawnWorld = value;
        
    }
}