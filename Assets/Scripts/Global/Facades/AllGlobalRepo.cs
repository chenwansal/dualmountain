using System;
using UnityEngine;

namespace DualMountain.Facades {

    public static class AllGlobalRepo {

        // 主相机
        static Camera mainCam;
        public static Camera MainCamera => mainCam;

        // 玩家类
        public static PlayerEntity PlayerEntity { get; private set; }

        // 输入类
        public static InputEntity InputEntity { get; private set; }

        public static void Ctor() {

            PlayerEntity = new PlayerEntity();
            Debug.Log("PlayerEntity 生成");

            InputEntity = new InputEntity();
            Debug.Log("InputEntity 生成");

        }

        public static void Inject(Camera mainCamera) {
            mainCam = mainCamera;
        }

    }
}