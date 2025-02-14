using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private AudioSource _playMatchSound;
    [SerializeField] private AudioSource _playWrongSound;

    private int _cardCount = 0;

    public int CheckCards(CardController resultCard, CardController card)
    {
        
        var resultCardSprite = resultCard.GetComponent<Image>().sprite;
        var cardSprite = card.GetComponent<Image>().sprite;

        if (resultCard == card)
        {
            _playWrongSound.Play();
        }
        else
        {
            if (resultCardSprite.name == cardSprite.name)
            {
                resultCard.gameObject.SetActive(false);
                card.gameObject.SetActive(false);
                _cardCount++;
                _playMatchSound.Play();
                return _cardCount;
            }
        }
        return 0;
    }   
}



