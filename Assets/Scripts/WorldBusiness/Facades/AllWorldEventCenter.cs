using System;

namespace DualMountain.WorldBusiness.Facades {

    public static class AllWorldEventCenter {

        // 生成世界事件
        static bool isTriggerSpawnWorld;
        public static bool IsTriggerSpawnWorld => isTriggerSpawnWorld;
        public static void SetTriggerSpawnWorld(bool value) => isTriggerSpawnWorld = value;
        
    }
}