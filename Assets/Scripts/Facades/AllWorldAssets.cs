using System;

namespace DualMountain.WorldBusiness.Facades {

    public static class AllWorldAssets {

        public static WorldAssets WorldAssets { get; private set; }

        public static void Ctor() {
            WorldAssets = new WorldAssets();
        }

    }

}