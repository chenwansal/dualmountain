using System;

namespace DualMountain.UIRenderer.Facades {

    public static class AllUI {

        static UIManager uiManager;
        public static UIManager UIManager => uiManager;
        public static void SetUIManager(UIManager ui) => uiManager = ui;

    }
}