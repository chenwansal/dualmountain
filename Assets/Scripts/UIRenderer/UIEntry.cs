using System;
using System.Threading.Tasks;
using UnityEngine;
using DualMountain.UIRenderer.Facades;

namespace DualMountain.UIRenderer.Entry {

    public class UIEntry {

        public UIEntry() {}

        public void Ctor(Transform root) {
            var canvas = root.Find("UI_CANVAS");
            var uiManager = canvas.GetComponent<UIManager>();
            AllUI.SetUIManager(uiManager);
        }

        public async Task Init() {
            await AllUI.UIManager.Init();
        }

    }
}