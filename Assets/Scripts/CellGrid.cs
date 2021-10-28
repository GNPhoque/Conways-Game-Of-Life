using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGrid : MonoBehaviour
{
	[SerializeField]
	GameObject cell;
	[SerializeField]
	[Min(0)]
	int rows;
	[SerializeField]
	[Min(0)]
	int columns;
	[SerializeField]
	float padding;

	Transform t;
	GameObject[,] grid;

	private void Start()
	{
		t = GetComponent<Transform>();
		grid = new GameObject[rows, columns];
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < columns; col++)
			{
				grid[row, col] = Instantiate(cell, t);
				grid[row, col].transform.position += new Vector3(row + row * padding, col + col * padding);
			}
		}
		Vector3 cameraPos = grid[rows - 1, columns - 1].transform.position / 2;
		Camera.main.transform.position = new Vector3(cameraPos.x, cameraPos.y, -10f);
		if (cameraPos.x > cameraPos.y * 16f / 9f)
		{
			Camera.main.orthographicSize = ((cameraPos.x) + 0.5f + (2 * padding)) / (16f / 9f);
		}
		else
		{
			Camera.main.orthographicSize = cameraPos.y + 0.5f + 2 * padding;
		}
	}

	bool IsInGrid(int i, int j)
	{
		return i < rows && j < columns;
	}

	bool IsAlive(int i, int j)
	{
		return IsInGrid(i, j) && grid[i, j].GetComponent<Cell>().IsAlive;
	}

	int NumberAliveAroundCell(int row, int col)
	{
		int ret = 0;
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < col; j++)
			{
				if (IsAlive(i,j))
				{
					ret++;
				}
			}
		}
		return ret;
	}

	void SetAllCellsNeighbours()
	{
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				grid[i, j].GetComponent<Cell>().Neighbours = NumberAliveAroundCell(i, j);
			}
		}
	}
}
