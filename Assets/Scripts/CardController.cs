using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [SerializeField] private AudioSource _playClickSound;

    public Sprite _newButtonImage { get; private set; }
    private Button _button;
    private CardManager _cardManager;
    private GameplayManager _gameplayManager;

    private void Awake()
    {
        _cardManager = FindObjectOfType<CardManager>();
        _gameplayManager = FindObjectOfType<GameplayManager>();
        _button = GetComponent<Button>();
    }

    #region UI callbacks
    public void OnCardClicked()
    {
        _cardManager.SetSelectedCards(this);
        _gameplayManager.CountMoves();
        _playClickSound.Play();


    }
    #endregion

    public void ChangeButtonImage()
    { 
        _button.image.sprite = _newButtonImage;
    }

    public void ResetData()
    {
        _button.image.sprite = null;
    }

    public void SetSprite(Sprite sprite)
    {
        _newButtonImage = sprite;
    }

}
