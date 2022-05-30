using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DualMountain.UIRenderer {

    public class UIManager : MonoBehaviour {

        // ==== ASSETS ====
        UILayoutAssets layoutAssets;

        // ==== BACKGROUND ====
        Image bg;

        // ==== ROOT ====
        Transform pageRoot, windowRoot, worldTipsRoot, uiTipsRoot;

        void Awake() {

            layoutAssets = new UILayoutAssets();

            bg = transform.GetChild(0).GetComponent<Image>();

            worldTipsRoot = transform.GetChild(1);
            pageRoot = transform.GetChild(2);
            windowRoot = transform.GetChild(3);
            uiTipsRoot = transform.GetChild(4);

            Debug.Assert(bg != null);
            Debug.Assert(worldTipsRoot != null);
            Debug.Assert(pageRoot != null);
            Debug.Assert(windowRoot != null);
            Debug.Assert(uiTipsRoot != null);

        }

        public async Task Init() {
            await layoutAssets.LoadAll();
        }

        GameObject GetPrefab<T>() {
            return layoutAssets.GetUIPrefabWithType(typeof(T));
        }

        public T OpenPage<T>() where T : IUIPanel {
            var prefab = GetPrefab<T>();
            prefab = GameObject.Instantiate(prefab, pageRoot);
            return prefab.GetComponent<T>();
        }

    }

}