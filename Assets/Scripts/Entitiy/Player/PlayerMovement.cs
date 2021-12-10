using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	public class PlayerMovement : EntityMovement
	{
		private IPlayerController player;

		protected override void Awake()
		{
			base.Awake();
			player = GetComponent<IPlayerController>();
		}

		public override void Move(Vector3 destination)
		{
			if(player.IsSelected)
				base.Move(destination);
		}
	}
}