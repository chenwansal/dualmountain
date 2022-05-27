using System;

namespace DualMountain.Facades {

    public static class AllGlobalRepo {

        public static PlayerEntity PlayerEntity { get; private set; }
        public static PlayerInputEntity InputEntity { get; private set; }

        public static void Ctor() {
            PlayerEntity = new PlayerEntity();
            InputEntity = new PlayerInputEntity();
        }

    }
}