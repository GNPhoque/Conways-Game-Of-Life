using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGrid : MonoBehaviour
{
	[SerializeField]
	Cell cell;
	[SerializeField]
	[Min(0)]
	int rows;
	[SerializeField]
	[Min(0)]
	int columns;
	[SerializeField]
	float padding;

	Transform t;
	Cell[,] grid;

	private void Start()
	{
		t = GetComponent<Transform>();
		grid = new Cell[rows, columns];
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < columns; col++)
			{
				grid[row, col] = Instantiate(cell, new Vector3(row + row * padding, col + col * padding), Quaternion.identity, t);
				//grid[row, col].transform.position += new Vector3(row + row * padding, col + col * padding);
				//grid[row, col].name = $"({row}, {col})";
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

	private void Update()
	{
		if (Input.GetKeyDown( KeyCode.Space))
		{
			Debug.Log("Simulating");
			RunSimulation();
		}
	}

	void RunSimulation()
	{
			Debug.Log("SET ALL CELLS NEIGHBOURS");
		SetAllCellsNeighbours();
			Debug.Log("APPLY SIMULATION");
		ApplyAllCellsSimulation();
	}

	void SetAllCellsNeighbours()
	{
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				grid[i, j].Neighbours = NumberAliveAroundCell(i, j);
			}
		}
	}

	int NumberAliveAroundCell(int row, int col)
	{
		int ret = 0;
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				if (i == 0 && j == 0)
				{
					continue;
				}
				if (IsInGrid(row + i, col + j) && IsAlive(row + i, col + j))
				{
					ret++;
				}
			}
		}
		return ret;
	}

	bool IsAlive(int i, int j)
	{
			return IsInGrid(i, j) && grid[i, j].IsAlive;
	}

	bool IsInGrid(int i, int j)
	{
		return i >= 0 && i < rows && j >= 0 && j < columns;
	}

	private void ApplyAllCellsSimulation()
	{
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				grid[i, j].ApplySimulation();
			}
		}
	}
}
