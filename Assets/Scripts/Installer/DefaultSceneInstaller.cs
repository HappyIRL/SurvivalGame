using ModestTree;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	[CreateAssetMenu(menuName = "ScriptableObject/DefaultSceneInstaller")]
	public class DefaultSceneInstaller : ScriptableObjectInstaller<DefaultSceneInstaller>
	{
		[SerializeField] private GameObject mainCamera;
		[SerializeField] private GameObject player;
		[SerializeField] private GameObject playerInputHandler;
		[SerializeField] private GameObject selector;
		[SerializeField] private GameObject playerEntitiesMover;


		public override void InstallBindings()
		{
			Container.Bind<PlayerCamera>().FromComponentInNewPrefab(mainCamera).AsSingle().NonLazy();
			Container.Bind<Character>().FromComponentInNewPrefab(player).AsSingle().NonLazy();
			Container.Bind<PlayerInputHandler>().FromComponentInNewPrefab(playerInputHandler).AsSingle().NonLazy();
			Container.Bind<Selector>().FromComponentInNewPrefab(selector).AsSingle().NonLazy();
			Container.Bind<PlayerEntitiesMover>().FromComponentInNewPrefab(playerEntitiesMover).AsSingle().NonLazy();


			Container.BindFactory<GameObject, Transform, PrefabFactory>().FromFactory<CustomPrefabFactory>();
		}
	}

	public class PrefabFactory : PlaceholderFactory<GameObject, Transform>
	{
		//public Transform Create(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
		//{
		//	var t = Create(prefab);
		//	t.SetParent(parent, worldPositionStays: false);
		//	t.position = position;
		//	t.rotation = rotation;
		//	return t;	
		//}
		//public Transform Create(GameObject prefab, Transform parent)
		//{
		//	var t = Create(prefab);
		//	t.SetParent(parent, worldPositionStays: false);
		//	return t;
		//}
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