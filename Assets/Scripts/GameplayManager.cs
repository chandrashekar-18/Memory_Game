using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private int moves=0;
    [SerializeField] private Text movesText;

    public int CountMoves()
    {
        movesText.text = (moves).ToString();
        moves++;
        return moves;
    }

}

