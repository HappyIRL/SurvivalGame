using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	public class CharacterMovement : EntityMovement, IMoveable
	{
		[Inject] private Character character;

		public void Move(Vector3 destination)
		{
			if(character.IsSelected)
				MoveToVector(destination);
		}
	}
}