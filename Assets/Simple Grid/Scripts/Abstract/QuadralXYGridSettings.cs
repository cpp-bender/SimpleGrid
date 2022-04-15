using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Simple Grid/Quadral XY Grid Settings", fileName = "Quadral XY Grid Settings", order = 1)]
public class QuadralXYGridSettings : BaseGridSettings
{
    public override void InitGrid()
    {
        var gridParent = new GameObject(ParentName);

        int index = 0;

        Cells = new List<Cell>();

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Vector3 worldPos = InitialPos + new Vector3(x * WidthOffset, y * HeightOffset, 0f);
                var grid = Instantiate(GridPrefab, worldPos, Quaternion.identity);
                grid.SetText(index).SetName(ChildName + $"{index}").SetParent(gridParent.transform);
                Cells.Add(new Cell(index, worldPos));
                index++;
            }
        }
    }
}
