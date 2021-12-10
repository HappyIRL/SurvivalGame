using ModestTree;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	[CreateAssetMenu(menuName = "ScriptableObject/DefaultSceneInstaller")]
	public class DefaultSceneInstaller : ScriptableObjectInstaller<DefaultSceneInstaller>
	{
		[SerializeField] private GameObject playerCameraPrefab, playerManagerPrefab, playerInputHandlerPrefab, selectorPrefab, playerEntitiesMoverPrefab;


		public override void InstallBindings()
		{
			Container.Bind<PlayerCamera>().FromComponentInNewPrefab(playerCameraPrefab).AsSingle().NonLazy();
			Container.Bind<PlayerManager>().FromComponentInNewPrefab(playerManagerPrefab).AsSingle().NonLazy();
			Container.Bind<PlayerInputBroadcast>().FromComponentInNewPrefab(playerInputHandlerPrefab).AsSingle().NonLazy();
			Container.Bind<Selector>().FromComponentInNewPrefab(selectorPrefab).AsSingle().NonLazy();
			Container.Bind<PlayerEntitiesMover>().FromComponentInNewPrefab(playerEntitiesMoverPrefab).AsSingle().NonLazy();


			Container.BindFactory<GameObject, Transform, PrefabFactory>().FromFactory<CustomPrefabFactory>();
		}
	}

	public class PrefabFactory : PlaceholderFactory<GameObject, Transform>
	{
		public Transform Create(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			var t = Create(prefab);
			t.SetParent(parent, worldPositionStays: false);
			t.position = position;
			t.rotation = rotation;
			return t;
		}
		public Transform Create(GameObject prefab, Transform parent)
		{
			var t = Create(prefab);
			t.SetParent(parent, worldPositionStays: false);
			return t;
		}
	}

	public class CustomPrefabFactory : IFactory<GameObject, Transform>
	{
		[Inject]
		readonly DiContainer container = null;

		public Transform Create(GameObject prefab)
		{
			Assert.That(prefab != null, "Null prefab given to factory create method");

			return container.InstantiatePrefab(prefab).transform;
		}
	}
}