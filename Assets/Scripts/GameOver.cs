using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text _movesText;
    private GameplayManager _gameplayManager;
    private int _movesCount;

    private void Awake()
    {
        _gameplayManager = FindObjectOfType<GameplayManager>();
        Display();
    }

    private void Display()
    {
        _movesCount = _gameplayManager.CountMoves();
        _movesText.text = (_movesCount-1).ToString();
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
  

}
