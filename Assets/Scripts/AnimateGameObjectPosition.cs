using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
public class AnimateGameObjectPosition : MonoBehaviour
{
    public int spawnIndex
    {
        get { return m_spawnIndex; }
        set { m_spawnIndex = value; }
    }
    private int m_spawnIndex = 0;

    public int height
    {
        get { return m_height; }
        set { m_height = value; }
    }
    private int m_height = 100;

    // Update is called once per frame
    void Update()
    {
        var mode = SimulationMode.getCurrentMode();
        if ((mode.type == SimulationMode.ModeType.Position) ||
            (mode.type == SimulationMode.ModeType.PositionAndColor))
        {
            float indexAdd = 0.00123f * (float)spawnIndex;

            int y = spawnIndex / height;
            int x = spawnIndex - (y * height);
            var pos = new float4(
                x,
                math.sin(mode.time + indexAdd) * 4.0f,
                y,
                1);

            transform.position = new Vector3(pos.x, pos.y, pos.z);

        }
    }
}

