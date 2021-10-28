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
				grid[row, col] = Instantiate(cell, t);
				grid[row, col].transform.position += new Vector3(row + row * padding, col + col * padding);
			Debug.Log(new Vector3(row + row * padding, col + col * padding));
			}
		}
		Vector3 cameraPos = grid[rows - 1, columns - 1].transform.position / 2;
			Debug.Log(grid[rows - 1, columns - 1].transform.position);
			Debug.Log(cameraPos);
		Camera.main.transform.position = new Vector3(cameraPos.x, cameraPos.y, -10f);
		if (cameraPos.x > cameraPos.y * 16f / 9f)
		{
			Debug.Log("in if");
			Camera.main.orthographicSize = ((cameraPos.x) + 0.5f + (2 * padding)) / (16f / 9f);
		}
		else
		{
			Debug.Log("in else");
			Camera.main.orthographicSize = cameraPos.y + 0.5f + 2 * padding;
		}
	}
}
