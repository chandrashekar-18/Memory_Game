using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private Sprite[] _spriteArray;
    [SerializeField] private int _cardLimit = 20;
    [SerializeField] private CardController _cardPrefab;
    [SerializeField] private Transform _gridContent;

    private CardGridLayout _cardGridLayout;
    private int _rand;
    private Sprite[] _randomizedSprites;
    private int[] _cardCount;

    private void Awake()
    {
        _randomizedSprites = new Sprite[_cardLimit];
        _cardGridLayout = GetComponent<CardGridLayout>();
    }

    void Start()
    {
        RandomizedSprites();
        StartCoroutine(SpawnCards());
    }

    void RandomizedSprites()
    {
        _cardCount = new int[_spriteArray.Length];
        for (int spriteIndex = 0; spriteIndex < _cardLimit; spriteIndex++)
        {
            _rand = Random.Range(0, _spriteArray.Length);

            if(_cardCount[_rand] < 2)
            {
                _randomizedSprites[spriteIndex] = _spriteArray[_rand];
                _cardCount[_rand]++;
            }
            else
            {
                spriteIndex--;
                continue;
            }
        }
    }

    private IEnumerator SpawnCards()
    {
        int resultantIndex = 0;
        for(int gridIndex = 0; gridIndex < _cardLimit; gridIndex++)
        {
            CardController card = Instantiate(_cardPrefab, _gridContent);
            card.SetSprite(_randomizedSprites[gridIndex]);
            card.name = "card " + gridIndex;
            resultantIndex = gridIndex;
        }

        yield return new WaitUntil(() => resultantIndex >= _cardLimit-1);
        _cardGridLayout.enabled = false;
    }
}
