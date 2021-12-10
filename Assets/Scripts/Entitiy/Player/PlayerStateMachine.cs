using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour, IPlayerController, ISelectable
{
	private bool isSelected;

	public bool IsSelected => isSelected;

	public void Select()
	{
		isSelected = true;
	}

	public void DeSelect()
	{
		isSelected = false;
	}
}
