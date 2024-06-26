using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDatas", menuName = "Game / Datas")]
public class GameDataSO : ScriptableObject
{
    public Difficulty difficulty;
    public int rows;
    public int columns;

    public Sprite background;

    public int TopBotPadding;
    public Vector2 spacing;
}
