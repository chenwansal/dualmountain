using System;
using UnityEngine;
using UnityEngine.UI;

namespace DualMountain.UIRenderer {

    public class UIPageTitle : MonoBehaviour, IUIPanel {

        UIRootLevel IUIPanel.RootLevel => UIRootLevel.Page;
        int IUIPanel.TypeID => (int)UITypeID.PageTitle;

        // MVVM
        Button startGameButton;

        // EVENTS
        public event Action OnStartGameHandle;

        void Awake() {

            var bd = transform.GetChild(0);

            var buttonGroup = bd.GetChild(0);

            startGameButton = buttonGroup.GetChild(0).GetComponent<Button>();

            startGameButton.onClick.AddListener(() => {
                OnStartGameHandle.Invoke();
            });

        }

        public void TearDown() {
            startGameButton.onClick.RemoveAllListeners();
            GameObject.Destroy(gameObject);
        }

    }
}