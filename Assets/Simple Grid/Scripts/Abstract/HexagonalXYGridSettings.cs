using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Simple Grid/Hexagonal XY Grid Settings", fileName = "Hexagonal XY Grid Settings", order = 3)]
public class HexagonalXYGridSettings : BaseGridSettings
{
    [SerializeField, Space(5f)] float hexagonalOffset = 1f;

    public float HexagonalOffset { get => hexagonalOffset; }

    public override void InitGrid()
    {
        var gridParent = new GameObject(ParentName);

        int index = 0;

        Cells = new List<Cell>();

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Vector3 worldPos = InitialPos + new Vector3(x * WidthOffset + (y % 2 * hexagonalOffset), y * HeightOffset, 0f);
                var grid = Instantiate(GridPrefab, worldPos, Quaternion.identity);
                grid.SetText(index).SetName(ChildName + $"{index}").SetParent(gridParent.transform);

                var cell = new Cell();
                cell.SetIndex(index).SetWorldPos(worldPos);

                Cells.Add(cell);
                index++;
            }
        }
    }
}
