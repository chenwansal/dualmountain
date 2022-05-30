using System;

namespace DualMountain.WorldBusiness.Facades {

    public static class AllWorldAssets {

        // 世界资源缓存
        public static WorldAssets WorldAssets { get; private set; }

        public static void Ctor() {
            WorldAssets = new WorldAssets();
        }

    }

}