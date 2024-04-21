using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class UISystem : MonoBehaviour
    {
        public static UISystem Instance;
        [SerializeField] private WindowBase[] _windows;
        private List<WindowBase> _openedWindows = new List<WindowBase>();
        private WindowBase _currentWindow;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        private void Start()
        {
            _windows = GetComponentsInChildren<WindowBase>(true);
            foreach (var  window in _windows)
            {
                window.Close();
            }
            OpenWindow(WindowType.StartWindow, false);
        }
        public void OpenWindow(WindowType windowType, bool setAsLast)
        {
            var windowToOpen = _windows.FirstOrDefault(x => x.Type == windowType);
            if (windowToOpen == null)
            {
                return;
            }
            if (setAsLast)
            {
                windowToOpen.transform.SetAsLastSibling();
            }
            if (_openedWindows.Contains(windowToOpen))
            {
                return;
            }
            if (!windowToOpen.IsPopup)
            {
                if (_currentWindow != null)
                {
                    foreach (var window in _openedWindows)
                    {
                        window.Close();
                    }
                    _openedWindows.Clear();
                }
            }
            windowToOpen.Open();
            _currentWindow = windowToOpen;
            _openedWindows.Add(windowToOpen);
        }
        public void Close(WindowType windowType)
        {
            var windowToClose = _windows.FirstOrDefault(x=>x.Type == windowType);
            if (windowToClose == null)
            {
                return;
            }
            if (!_openedWindows.Contains(windowToClose))
            {
                return;
            }
            if (_openedWindows.Count < 2)
            {
                return;
            }
            var indexOf = _openedWindows.IndexOf(windowToClose);
            _openedWindows[indexOf].Close();
            _openedWindows.Remove(_openedWindows[indexOf]);
            _currentWindow = _openedWindows[^1];
        }
        }
    }
   