using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGrid : MonoBehaviour
{
	[SerializeField]
	GameObject cell;
	[SerializeField]
	int rows;
	[SerializeField]
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
				grid[row, col] = Instantiate(cell, t, false);
				grid[row, col].transform.position += new Vector3(row + row * padding, col + col * padding);
			}
		}
	}
}
