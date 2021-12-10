using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class PlayerManager : MonoBehaviour
	{
		[SerializeField] private GameObject playerPrefab;

		[Zenject.Inject] PrefabFactory prefabFactory;

		private Transform playerTransform;
		private IPlayerController player;

		private void Awake()
		{
			var p = prefabFactory.Create(playerPrefab);
			SetupNewPlayer(p);
		}

		private void SetupNewPlayer(Transform newObject)
		{
			playerTransform = newObject;
			if (newObject != null)
			{
				player = newObject.GetComponent<IPlayerController>();
			}
		}

		public IPlayerController GetPlayer()
		{
			return player;
		}
	}
}