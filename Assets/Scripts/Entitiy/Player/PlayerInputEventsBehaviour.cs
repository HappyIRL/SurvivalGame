using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class PlayerInputEventsBehaviour : MonoBehaviour
{
	[Zenject.Inject] private PlayerInputBroadcast playerInputBroadcast;

	protected virtual void OnEnable()
	{
		playerInputBroadcast.MouseButton0Started += OnMouse0Started;
		playerInputBroadcast.MouseButton0Cancled += OnMouse0Cancled;
		playerInputBroadcast.MouseButton1 += OnMouse1;
		playerInputBroadcast.MousePosChange += OnMousePosChange;
		playerInputBroadcast.Scroll += OnScroll;
	}

	protected virtual void OnScroll(int scrollDelta)
	{
	}

	protected virtual void OnMousePosChange(Vector2 mousePos)
	{
	}

	protected virtual void OnMouse1(Vector2 mousePos)
	{
	}

	protected virtual void OnMouse0Cancled(Vector2 mousePos)
	{
	}

	protected virtual void OnMouse0Started(Vector2 mousePos)
	{
	}

	protected virtual void OnDisable()
	{
		playerInputBroadcast.MouseButton0Started -= OnMouse0Started;
		playerInputBroadcast.MouseButton0Cancled -= OnMouse0Cancled;
		playerInputBroadcast.MouseButton1 -= OnMouse1;
		playerInputBroadcast.MousePosChange -= OnMousePosChange;
		playerInputBroadcast.Scroll -= OnScroll;
	}
}
