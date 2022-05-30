using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DualMountain.Facades;
using DualMountain.WorldBusiness;
using DualMountain.WorldBusiness.Controller;
using DualMountain.WorldBusiness.Facades;

namespace DualMountain {

    public class App : MonoBehaviour {

        bool isInit;

        WorldSpawnController worldSpawnController;
        InputController inputController;
        RoleController roleController;

        void Awake() {

            isInit = false;

            DontDestroyOnLoad(gameObject);
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;

            Action action = async () => {

                try {

                    // ==== CTOR ====
                    AllGlobalRepo.Ctor();
                    AllWorldRepo.Ctor();

                    worldSpawnController = new WorldSpawnController();
                    inputController = new InputController();
                    roleController = new RoleController();

                    AllWorldAssets.Ctor();

                    // ==== INJECT ====
                    AllGlobalRepo.Inject(Camera.main);

                    // ==== INIT ====
                    await AllWorldAssets.WorldAssets.LoadAll();

                    // 生成 控制器
                    inputController.Init();

                    // ==== GAME START ====
                    // TODO: 临时触发生成世界
                    AllWorldEventCenter.SetTriggerSpawnWorld(true);

                    isInit = true;

                } catch (Exception ex) {

                    Debug.LogException(ex);

                }

            };

            action.Invoke();

        }

        void Start() {

        }

        void Update() {

            if (!isInit) {
                return;
            }

            float dt = Time.deltaTime;

            // 世界生成
            worldSpawnController.Tick();

            // 输入控制
            inputController.Tick(dt);

            // 角色控制
            roleController.Tick(dt);

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
