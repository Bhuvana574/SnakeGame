

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    [SerializeField]
    GridTile GridTilePrefab;
    [SerializeField]
    Transform PlayArea;
    [SerializeField]
    int gridsize = 10;
    public int GridSize
    {
        get { return gridsize; }
    }
    Vector3 startPoint;
    public Vector3 StartPoint { get { return startPoint; } }
    public GridTile GetRandomTile(int margin = 0)
    {
        if ((margin > width || margin > height) && margin < 0)
        {
            return GetTileAt(0, 0);
        }
        int x = UnityEngine.Random.Range(0 + margin, width - margin);
        int y = UnityEngine.Random.Range(0 + margin, height - margin);
        return GetTileAt(x, y);
    }

    public GridTile GetTileAt(int x, int y)
    {
        if (grid[x, y] != null)

        {
            return grid[x, y].GetComponent<GridTile>();
        }
        return null;
    }

    int width, height;
    Transform[,] grid;
    public void InitializeGrid()
    {
        width = Mathf.RoundToInt(PlayArea.localScale.x * gridsize);
        height = Mathf.RoundToInt(PlayArea.localScale.y * gridsize);
        grid = new Transform[width, height];
        startPoint = PlayArea.GetComponent<Renderer>().bounds.min;
        Debug.Log(startPoint);
        CreateGridTile();
    }
    private void CreateGridTile()
    {
        if (GridTilePrefab == null)
            return;
        for (int i = 0; i < width; i++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 worldPos = GetWorldPos(i, y);
                GridTile gridTile = Instantiate(GridTilePrefab, worldPos, Quaternion.identity);
                gridTile.name = string.Format("Tile{0},{1}", i, y);
                grid[i, y] = gridTile.transform;
            }

        }
    }

    private Vector3 GetWorldPos(int a, int b)
    {
        float sp = a;
        float ep = b;
        return new Vector3(startPoint.x + (sp / gridsize), startPoint.y + (ep / gridsize), startPoint.z);

    }

    private void Start()
    {
        InitializeGrid();
    }
}
