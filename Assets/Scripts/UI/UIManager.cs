using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _fadedPanel;
    [SerializeField] private PlayerHpBar _playerHpBar;


    public void OpenFadedPanel() => _fadedPanel.SetActive(true);
    public void CloseFadedPanel() => _fadedPanel.SetActive(false);
    public void OpenGameOverPanel() => _gameOverPanel.SetActive(true);
    public void CloseGameOverPanel() => _gameOverPanel.SetActive(false);
    public void OpenMenuPanel() => _menuPanel.SetActive(true);
    public void CloseMenuPanel() => _menuPanel.SetActive(false);
    public void UpdatePlayerHP(float normalazedValue) => _playerHpBar.SetNormalizedValue(normalazedValue);
}
