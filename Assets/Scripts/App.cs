using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DualMountain.Facades;
using DualMountain.WorldBusiness;

namespace DualMountain.MainEntry {

    public class App : MonoBehaviour {

        bool isInit;
        bool isTearDown;

        WorldEntry worldEntry;

        void Awake() {

            AllGlobalRepo.Ctor();
            
            worldEntry = new WorldEntry();

            worldEntry.Ctor();

            worldEntry.Init();

            isInit = true;

            Debug.Log("Hello World");

        }

        void Start() {

        }

        void Update() {
            
            if (!isInit) {
                return;
            }

            worldEntry.Tick();
        }

        void FixedUpdate() {
            
            if (!isInit) {
                return;
            }

            worldEntry.FixedTick();
        }

        void LateUpdate() {

        }

        void OnDestroy() {

        }

        void OnApplicationQuit() {

        }
    }

}

