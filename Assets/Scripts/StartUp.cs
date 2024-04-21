using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    [SerializeField] private string _uiSceneName;
    private void Start()
    {
        SceneManager.LoadScene(_uiSceneName);
    }
}