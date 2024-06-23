using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGridLayout : LayoutGroup
{
    public int Rows;
    public int Columns;

    public Vector2 cardSize;

    public Vector2 spacing;

    public int topPadding;

    public override void CalculateLayoutInputVertical()
    {
        if (Rows == 0 || Columns == 0) 
        {
            Rows = 4;
            Columns = 5;
        }

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cardHeight = (parentHeight - 2 * topPadding - spacing.y * (Rows - 1)) / Rows;
        float cardWidth = cardHeight;

        if (cardWidth * Columns + spacing.x * (Columns - 1) > parentWidth) 
        {
            cardWidth = (parentWidth - 2 * topPadding - (Columns - 1) * spacing.x) / Columns;
            cardHeight = cardWidth;
        }

        cardSize = new Vector2(cardWidth, cardHeight);

        padding.left = Mathf.FloorToInt((parentWidth - Columns * cardWidth - spacing.x * (Columns - 1)) / 2 );
        padding.top = Mathf.FloorToInt((parentHeight - Rows * cardHeight - spacing.y * (Rows - 1)) / 2);
        padding.bottom = padding.top;


        for (int i = 0; i < rectChildren.Count; i++) 
        {
            int rowCount = i / Columns;
            int columnCount = i % Columns;

            var item = rectChildren[i];

            var xPos = padding.left + cardSize.x * columnCount + spacing.x * columnCount;
            var yPos = padding.top + cardSize.y * rowCount + spacing.y * rowCount;

            SetChildAlongAxis(item, 0, xPos, cardSize.x);
            SetChildAlongAxis(item, 1, yPos, cardSize.y);

        }
    }

    public override void SetLayoutHorizontal()
    {
        return;
    }

    public override void SetLayoutVertical()
    {
        return;
    }
}
