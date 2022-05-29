using Unity.Entities;
using UnityEngine;

struct PositionAnimated : IComponentData
{
}

namespace Authoring
{
    [DisallowMultipleComponent]
    public class PositionAnimated : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponent(entity, ComponentType.ReadWrite<global::PositionAnimated>());
        }
    }
}
