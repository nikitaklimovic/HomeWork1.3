using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{

    public class SelectStage : WindowBase
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private WindowType _windowType;
        public override WindowType Type => WindowType.SelectStage;
        public override bool IsPopup => false;
        private void Start()
        {
            _backButton.onClick.AddListener(OnBackButtonClick);
        }
        private void OnBackButtonClick()
        {
            UISystem.Instance.OpenWindow(_windowType, true);
        }

    }

}