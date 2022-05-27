using System;
using DualMountain.Facades;
using DualMountain.WorldBusiness.Controllers;

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

        public void FixedTick() {
            
        }

    }

}