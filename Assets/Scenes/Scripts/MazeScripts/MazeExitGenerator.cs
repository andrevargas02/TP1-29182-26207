using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeExitGenerator : MonoBehaviour
{
    public MazeGenerator mazeGenerator; // Referência ao gerador de labirinto
    public GameObject exitPrefab; // Prefab para a saída do labirinto

    public Vector2Int FindRandomExitPosition()
    {
        bool isTopOrBottom = Random.value < 0.5f;
        int x = 0, y = 0;
        if (isTopOrBottom)
        {
            x = Random.Range(0, mazeGenerator.mazeWidth);
            y = Random.Range(0, 2) * (mazeGenerator.mazeHeight - 1);
        }
        else
        {
            x = Random.Range(0, 2) * (mazeGenerator.mazeWidth - 1);
            y = Random.Range(0, mazeGenerator.mazeHeight);
        }

        return new Vector2Int(x, y);
    }

    public void CreateExit() {
        Vector2Int exitPosition = FindRandomExitPosition();
        Direction wallToRemove = DetermineExitWallDirection(exitPosition);
        mazeGenerator.RemoveWallAt(exitPosition, wallToRemove);

       Vector3 exitWorldPosition = new Vector3(exitPosition.x * mazeGenerator.CellSize, 0, exitPosition.y * mazeGenerator.CellSize);
        Instantiate(exitPrefab, exitWorldPosition, Quaternion.identity, transform);
    }

    private Direction DetermineExitWallDirection(Vector2Int exitPosition) {
        if (exitPosition.y == 0) return Direction.Down;
        if (exitPosition.y == mazeGenerator.mazeHeight - 1) return Direction.Up;
        if (exitPosition.x == 0) return Direction.Left;
        if (exitPosition.x == mazeGenerator.mazeWidth - 1) return Direction.Right;

        return Direction.Up; // Default direction, should never reach here in a proper setup
    }
}
