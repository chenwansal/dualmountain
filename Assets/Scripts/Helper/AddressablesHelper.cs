using System;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DualMountain {

    public static class AddressablesHelper {

        public static async Task LoadWithLabel<T>(string label, Action<T> callback) {
            try {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = label;
                var list = await Addressables.LoadAssetsAsync<T>(labelReference, null).Task;
                for (int i = 0; i < list.Count; i += 1) {
                    var res = list[i];
                    callback(res);
                }
            } catch {
                throw new Exception("Failed to load assets with label: " + label);
            }
        }
    }
}