using System;
using UnityEngine;
using DualMountain.Facades;
using DualMountain.TitleBusiness.Facades;
using DualMountain.UIRenderer;
using DualMountain.UIRenderer.Facades;

namespace DualMountain.TitleBusiness.Controller {

    public class TitlePageController {

        public TitlePageController() { }

        public void Tick() {

            if (!AllGlobalEventCenter.IsOpenTitlePage) {
                return;
            }

            AllGlobalEventCenter.SetOpenTitlePage(false);

            // 打开 TitlePage
            var ui = AllUI.UIManager;
            var titlePage = ui.OpenPage<UIPageTitle>();
            titlePage.OnStartGameHandle += OnStartGame;

            AllTitleRepo.SetUIPageTitle(titlePage);

        }

        void OnStartGame() {

            // 开始游戏
            AllGlobalEventCenter.SetTriggerSpawnWorld(true);

            // 关闭 TitlePage
            var page = AllTitleRepo.UIPageTitle;
            page.OnStartGameHandle -= OnStartGame;
            page.TearDown();

        }

    }
}