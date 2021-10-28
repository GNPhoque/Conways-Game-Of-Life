using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	[SerializeField]
	Material alive;
	[SerializeField]
	Material dead;
	[SerializeField]
	Renderer rend;

	bool isAlive;
	bool isAliveNext;
	private int neighbours;

	public bool IsAlive
	{
		get => isAlive; set
		{
			isAlive = value;
			rend.material = isAlive ? alive : dead;
		}
	}
	public int Neighbours
	{
		get => neighbours; set
		{
			neighbours = value;
			SimulationStep();
		}
	}

	private void Awake()
	{
		rend = GetComponent<Renderer>();
		//isAlive = Random.Range(0, 2) == 1;
		//rend.material = isAlive ? alive : dead;
	}

	private void OnMouseDown()
	{
		isAlive = !isAlive;
		rend.material = isAlive ? alive : dead;
	}

	void SimulationStep()
	{
		if (Neighbours == 3)
		{
			isAliveNext = true;
		}
		else if (Neighbours < 2 || Neighbours > 3)
		{
			isAliveNext = false;
		}
		else if( Neighbours == 2)
		{
			isAliveNext = isAlive;
		}
	}

	public void ApplySimulation()
	{
		IsAlive = isAliveNext;
	}


}
