using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public CardCollection collection;

    public GameDataSO easyData;
    public GameDataSO normalData;
    public GameDataSO hardData;

    GameDataSO gameDatas;

    List<CardController> cardControllers;

    public void Awake()
    {
        cardControllers = new List<CardController>();

        GetDifficulty();
        SetCardGrid();
        GenerateCards();
    }

    private void GenerateCards()
    {
        int cardCount = gameDatas.rows * gameDatas.columns;
        for (int i = 0; i < cardCount; i++) 
        {
            GameObject card = Instantiate(cardPrefab, this.transform);
            card.transform.name = "Card (" + i.ToString() + ")";
            cardControllers.Add(card.GetComponent<CardController>());
        }
    }

    private void SetCardGrid()
    {
        CardGridLayout cardGridLayout = this.GetComponent<CardGridLayout>();

        //cardGridLayout.padding = gameDatas.TopBotPadding;
        cardGridLayout.Rows = gameDatas.rows;
        cardGridLayout.Columns = gameDatas.columns;
        cardGridLayout.spacing = gameDatas.spacing;
    }

    private void GetDifficulty()
    {
        Difficulty difficulty = (Difficulty)PlayerPrefs.GetInt("Difficulty", (int)Difficulty.easy);

        switch (difficulty) 
        {
            case Difficulty.easy:
                gameDatas = easyData;
                break;

            case Difficulty.normal:
                gameDatas = normalData;
                break;

            case Difficulty.hard:
                gameDatas = hardData;
                break;
        }
    }
}
