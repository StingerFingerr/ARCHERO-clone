using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _fadedPanel;


    public void OpenFadedPanel() => _fadedPanel.SetActive(true);
    public void CloseFadedPanel() => _fadedPanel.SetActive(false);
    public void OpenGameOverPanel() => _gameOverPanel.SetActive(true);
    public void OpenMenuPanel() => _menuPanel.SetActive(true);
    public void CloseMenuPanel() => _menuPanel.SetActive(false);
}
