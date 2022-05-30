using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DualMountain.Facades;
using DualMountain.UIRenderer.Entry;
using DualMountain.TitleBusiness.Controller;
using DualMountain.WorldBusiness;
using DualMountain.WorldBusiness.Controller;
using DualMountain.WorldBusiness.Facades;

namespace DualMountain {

    public class App : MonoBehaviour {

        bool isInit;

        // UI ENTRY
        UIEntry uiEntry;

        // TODL: TITLE ENTRY
        TitlePageController titlePageController;

        // TODO: WORLD ENTRY
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
                    uiEntry = new UIEntry();

                    titlePageController = new TitlePageController();

                    worldSpawnController = new WorldSpawnController();
                    inputController = new InputController();
                    roleController = new RoleController();

                    // ==== FAKE CTOR ====
                    AllGlobalRepo.Ctor();
                    AllWorldRepo.Ctor();

                    AllWorldAssets.Ctor();

                    uiEntry.Ctor(transform);

                    // ==== INJECT ====
                    AllGlobalRepo.Inject(Camera.main);

                    // ==== INIT ====
                    await uiEntry.Init();
                    await AllWorldAssets.WorldAssets.LoadAll();

                    // 生成 控制器
                    inputController.Init();

                    // ==== GAME START ====
                    // TODO: 打开UI
                    AllGlobalEventCenter.SetOpenTitlePage(true);

                    // TODO: 临时触发生成世界
                    // AllWorldEventCenter.SetTriggerSpawnWorld(true);

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

            // 标题页
            titlePageController.Tick();

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
