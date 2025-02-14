using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private int _resetCardLimit = 2;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private AudioSource _playGameOverSound;

    private Stack<CardController> _selectedCards;
    private CardController _resultCard;
    private GameController _gameController;
    private int _cardCount;

    private void Awake()
    { 
        _selectedCards = new Stack<CardController>(_resetCardLimit);
        _gameController = FindObjectOfType<GameController>();
    }


    public void SetSelectedCards(CardController card)
    {
        card.ChangeButtonImage();

        ResetCards();

        _selectedCards.Push(card);

        if (_resultCard == null)
        {
            _resultCard = _selectedCards.Peek();
        }

        if (_selectedCards.Count >= _resetCardLimit)
        {
           IEnumerator CardDelay()
            {
                yield return new WaitForSeconds(0.2f);
                _cardCount = _gameController.CheckCards(_resultCard, card);
                if (_cardCount == 10)
                {
                    GameOverPanel.SetActive(true);
                    _playGameOverSound.Play();

                }
            }
            StartCoroutine(CardDelay());
            
        }
        
    }

    private void ResetCards()
    {
        if(_selectedCards.Count >= _resetCardLimit)
        {
            for(int cardIndex = 0; cardIndex < _selectedCards.Count; cardIndex++)
            {
                CardController resetCard1 = _selectedCards.Pop();
                CardController resetCard2 = _selectedCards.Pop();
                resetCard1.ResetData();
                resetCard2.ResetData();
            }
            _resultCard = null;
        }
    }
}
