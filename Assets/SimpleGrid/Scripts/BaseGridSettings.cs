using UnityEngine;

public abstract class BaseGridSettings : ScriptableObject
{
    [SerializeField, Space(2f)] GameObject gridPrefab = null;
    [SerializeField, Space(2f)] Vector3 initialPos = Vector3.zero;
    [SerializeField, Space(2f)] int width = 5;
    [SerializeField, Space(2f)] int height = 5;
    [SerializeField, Space(2f)] float widthThreshold = 2f;
    [SerializeField, Space(2f)] float heightThreshold = 2f;

    public GameObject GridPrefab { get => gridPrefab; }
    public Vector3 InitialPos { get => initialPos; }
    public int Width { get => width; }
    public int Height { get => height; }
    public float WidthThreshold { get => widthThreshold; }
    public float HeightThreshold { get => heightThreshold; }

    public abstract void InitGrid();
}
