using System;

namespace DualMountain.UIRenderer {

    public interface IUIPanel {
        UIRootLevel RootLevel { get; }
        int TypeID { get; }
    }
}