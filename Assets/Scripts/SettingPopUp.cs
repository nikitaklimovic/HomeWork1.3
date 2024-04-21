using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class SettingPopUp : WindowBase
    {
        [SerializeField] private Button _closeButton;

        public override WindowType Type => WindowType.Setting;
        public override bool IsPopup => true;

        private void Start()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            UISystem.Instance.Close(Type);
        }
    }
}