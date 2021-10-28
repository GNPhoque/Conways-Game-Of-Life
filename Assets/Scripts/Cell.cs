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

	private void Awake()
	{
		rend = GetComponent<Renderer>();
	}

	private void OnMouseDown()
	{
		isAlive = !isAlive;
		rend.material = isAlive ? alive : dead;
	}
}
