using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGridSettings : ScriptableObject
{
    [SerializeField, Space(5f)] Vector3 initialPos = Vector3.zero;
    [SerializeField, Space(5f)] Grid gridPrefab = null;
    [SerializeField, Space(5f)] GridCoords gridCoords = GridCoords.PositiveXZ;
    [SerializeField, Space(5f)] int width = 5;
    [SerializeField, Space(5f)] int height = 5;
    [SerializeField, Space(5f)] float widthOffset = 2f;
    [SerializeField, Space(5f)] float heightOffset = 2f;
    [SerializeField, Space(5f)] string parentName = "Grid";
    [SerializeField, Space(5f)] string childName = "Cell";

    private List<Cell> cells;
    private int size;
    private Vector3 gridPlane;
    private Vector3 canvasRot;

    public Vector3 InitialPos { get => initialPos; }
    public int Width { get => width; }
    public int Height { get => height; }
    public float WidthOffset { get => widthOffset; }
    public float HeightOffset { get => heightOffset; }
    public List<Cell> Cells { get => cells; protected set => cells = value; }
    public int Size { get => size;  }
    public GridCoords GridCoords { get => gridCoords; }

    protected abstract Vector3 MapToGridPlane(int w, float width, int h, float height);

    public void Create()
    {
        var gridParent = new GameObject(parentName);

        gridPlane = SimpleGridUtility.GetPlane(gridCoords);
        canvasRot = SimpleGridUtility.GetCanvasRotation(gridCoords);

        int index = 0;

        Cells = new List<Cell>();

        for (int h = 0; h < Height; h++)
        {
            for (int w = 0; w < Width; w++)
            {
                Vector3 pos = MapToGridPlane(w, widthOffset, h, heightOffset);

                pos = new Vector3(gridPlane.x * pos.x, gridPlane.y * pos.y, gridPlane.z * pos.z);

                Vector3 worldPos = InitialPos + pos;

                var grid = Instantiate(gridPrefab, worldPos, Quaternion.identity);
                grid.SetText(index).SetName(childName + $"{index}").SetParent(gridParent.transform).SetCanvasRotation(canvasRot);

                var cell = new Cell();
                cell.SetIndex(index).SetWorldPos(worldPos);

                Cells.Add(cell);
                index++;
            }
        }
    }
}
