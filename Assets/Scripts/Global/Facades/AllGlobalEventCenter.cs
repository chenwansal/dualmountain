using System;

namespace DualMountain.Facades {

    public static class AllGlobalEventCenter {

        // 打开标题页
        static bool isOpenTitlePage;
        public static bool IsOpenTitlePage => isOpenTitlePage;
        public static void SetOpenTitlePage(bool value) => isOpenTitlePage = value;

        // 生成世界事件
        static bool isTriggerSpawnWorld;
        public static bool IsTriggerSpawnWorld => isTriggerSpawnWorld;
        public static void SetTriggerSpawnWorld(bool value) => isTriggerSpawnWorld = value;

        public static void Ctor() {
            isOpenTitlePage = false;
            isTriggerSpawnWorld = false;
        }
        
    }
}