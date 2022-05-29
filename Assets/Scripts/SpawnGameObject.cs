using Unity.Mathematics;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{
    public GameObject Prefab;
    public int CountX;
    public int CountY;

    // Start is called before the first frame update
    void Start()
    {
        var localToWorld = transform.localToWorldMatrix;

        for (int x = 0; x < CountX; ++x)
        {
            for (int y = 0; y < CountY; ++y)
            {
                var pos = new float4(
                    x,
                    0.0f,
                    y,
                    1);
                pos = math.mul(localToWorld, pos);

                var gameObj = Instantiate(Prefab, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                var gameObjectAnimationSystem = gameObj.GetComponent<GameObjectAnimation>();
                if (gameObjectAnimationSystem)
                {
                    gameObjectAnimationSystem.spawnIndex = (y * CountX) + x;
                    gameObjectAnimationSystem.height = CountY;
                }
            }
        }
    }
}
