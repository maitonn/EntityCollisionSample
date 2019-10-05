using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	EntityManager m_entityManager = null;
	[SerializeField]
	Material m_material;
	[SerializeField]
	Mesh m_mesh;
	// Start is called before the first frame update
	void Start()
	{
		m_entityManager = World.Active.EntityManager;
		// entity生成
		Entity entity = m_entityManager.CreateEntity(
			typeof(SphereCollisionComponent),
			typeof(Translation),
			typeof(LocalToWorld)
		);
		m_entityManager.AddSharedComponentData(entity, new RenderMesh
		{
			castShadows = UnityEngine.Rendering.ShadowCastingMode.On, receiveShadows = true,
			material = m_material, mesh = m_mesh
		});
		m_entityManager.Instantiate(entity);
	}
}
