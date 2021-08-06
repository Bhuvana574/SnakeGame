
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] SnakeTile SnakeTilePrefab;
    private List<SnakeTile> snakePieces;
    public List<SnakeTile> SnakePieces { get { return snakePieces; } }
    public void InitizeSnake()
    {
        snakePieces = new List<SnakeTile>();
        GameManager.onApplePickup += AppleEaten;
        transform.position = GridManager.Instance.GetRandomTile(5).transform.position;
        SnakeTile snaketile = Instantiate(SnakeTilePrefab, transform.position, Quaternion.identity);
        snaketile.transform.parent = transform;
        SnakePieces.Add(snaketile);
    }

    private void AppleEaten()
    {
        AddPiece();
    }

    void AddPiece()
    {
        SnakeTile snaketile = Instantiate(SnakeTilePrefab, transform.position, Quaternion.identity);
        snaketile.MoveToTile(SnakePieces[snakePieces.Count - 1]);
        switch (PlayerInput.dir)
        {
            case PlayerInput.Direction.up:
                snaketile.MoveUp();
                break;
            case PlayerInput.Direction.down:
                snaketile.MoveDown();
                break;
            case PlayerInput.Direction.right:
                snaketile.MoveRight();
                break;
            case PlayerInput.Direction.left:
                snaketile.MoveLeft();
                break;
            default:
                break;

        }
        snaketile.MoveLeft();
        snakePieces.Add(snaketile);
    }
    public void Tick()
    {
        Move();
    }
    private void Move()
    {
        for (int i = snakePieces.Count - 1; i >= 0; i++)
        {
            if (i == 0)
            {
                switch (PlayerInput.dir)
                {
                    case PlayerInput.Direction.up:
                        snakePieces[i].MoveUp();
                        break;
                    case PlayerInput.Direction.down:
                        snakePieces[i].MoveDown();
                        break;
                    case PlayerInput.Direction.right:
                        snakePieces[i].MoveRight();
                        break;
                    case PlayerInput.Direction.left:
                        snakePieces[i].MoveLeft();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                snakePieces[i].MoveToTile(snakePieces[i]);
            }
        }
    }
    public SnakeTile GetHeadTile()
    {
        return snakePieces[0];
    }

}
