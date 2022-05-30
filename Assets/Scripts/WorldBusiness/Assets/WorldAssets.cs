using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DualMountain.WorldBusiness {

    public class WorldAssets {

        Dictionary<string, GameObject> all;

        public WorldAssets() {
            this.all = new Dictionary<string, GameObject>();
        }

        public async Task LoadAll() {
            const string LABEL = "WorldAssets";
            await AddressablesHelper.LoadWithLabel(LABEL, (GameObject go) => {
                all.Add(go.name, go);
            });
        }

        public GameObject GetRolePrefab() {
            all.TryGetValue("go_role", out GameObject go);
            Debug.Assert(go != null);
            return go;
        }

    }

}