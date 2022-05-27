using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DualMountain.WorldBusiness;
using DualMountain.WorldBusiness.Controller;
using DualMountain.WorldBusiness.Facades;

namespace DualMountain {

    public class App : MonoBehaviour {

        bool isInit;

        InputController inputController;
        RoleController roleController;

        void Awake() {

            isInit = false;

            // ==== 游戏准备 ====
            // 找到相机 && 虚拟相机
            AllWorldRepo.SetCamera(Camera.main);
            AllWorldRepo.SetCameraEntity(transform.GetComponentInChildren<CameraEntity>());

            // 生成 PlayerEntity
            AllWorldRepo.Ctor();

            // 生成 控制器
            inputController = new InputController();
            inputController.Init();

            // 生成 玩家
            roleController = new RoleController();
            roleController.Init(transform);

            isInit = true;
            
        }

        void Start() {

        }

        void Update() {

            if (!isInit) {
                return;
            }

        }

        void FixedUpdate() {

            if (!isInit) {
                return;
            }

            float fixedDeltaTime = Time.fixedDeltaTime;

            // 角色控制
            roleController.FixedTick(fixedDeltaTime);

        }

    }

}
