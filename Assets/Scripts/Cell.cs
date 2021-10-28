using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	[SerializeField]
	Material alive;
	[SerializeField]
	Material dead;

	bool isAlive;
	Renderer rend;

	public bool IsAlive { get => isAlive; set => isAlive = value; }
	public int Neighbours { get; set; }

	private void Awake()
	{
		rend = GetComponent<Renderer>();
		isAlive = Random.Range(0, 2) == 1;
		rend.material = isAlive ? alive : dead;
	}

	private void OnMouseDown()
	{
		isAlive = !isAlive;
		rend.material = isAlive ? alive : dead;
	}

	public void SetIsAlive(bool living) => isAlive = living;
}
