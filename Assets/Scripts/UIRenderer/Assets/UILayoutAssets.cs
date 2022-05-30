using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace DualMountain.UIRenderer {

    public class UILayoutAssets {

        Dictionary<int, GameObject> all;
        Dictionary<Type, GameObject> allInTypes;

        public UILayoutAssets() {
            this.all = new Dictionary<int, GameObject>();
            this.allInTypes = new Dictionary<Type, GameObject>();
        }

        public async Task LoadAll() {
            const string LABEL = "UILayoutAssets";
            await AddressablesHelper.LoadWithLabel(LABEL, (GameObject go) => {
                IUIPanel panel = go.GetComponent<IUIPanel>();
                Debug.Assert(panel != null);
                all.Add(panel.TypeID, go);
                allInTypes.Add(panel.GetType(), go);
            });
        }

        public GameObject GetUIPrefab(int typeID) {
            all.TryGetValue(typeID, out var go);
            Debug.Assert(go != null);
            return go;
        }

        public GameObject GetUIPrefabWithType(Type type) {
            allInTypes.TryGetValue(type, out var go);
            Debug.Assert(go != null);
            return go;
        }

    }
}