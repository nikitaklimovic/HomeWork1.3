using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class StartWindow : WindowBase
    {
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _startButton;

        public override WindowType Type => WindowType.StartWindow;
        public override bool IsPopup => false;
        private void Start()
        {
            _settingButton.onClick.AddListener(OnSettingButtonClick);
            _startButton.onClick.AddListener(OnStartButtonClick);
        }
        private void OnStartButtonClick()
        {
            UISystem.Instance.OpenWindow(WindowType.SelectStage, false);
        }
        private void OnSettingButtonClick()
        {
            UISystem.Instance.OpenWindow(WindowType.Setting, true);

        }
    }
}

        