using System;
using DualMountain.UIRenderer;

namespace DualMountain.TitleBusiness.Facades {

    public static class AllTitleRepo {

        // Title Page
        static UIPageTitle uiPageTitle;
        public static UIPageTitle UIPageTitle => uiPageTitle;
        public static void SetUIPageTitle(UIPageTitle ui) => uiPageTitle = ui;

    }

}