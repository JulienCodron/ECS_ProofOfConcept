using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimulationMode
{
    public enum ModeType
    {
        None,
        Color,
        Position,
        PositionAndColor
    }

    public struct Mode
    {
        public ModeType type;
        public float time;
        public float deltaTime;
    }

    public static Mode getCurrentMode()
    {
        float time = Time.timeSinceLevelLoad;
        float deltaTime = Time.deltaTime;

        var mode = ((int)(time / 5.0f) % 4);

        Mode result;
        result.time = time;
        result.deltaTime = deltaTime;
        if (mode == 0)
            result.type = ModeType.None;
        else if (mode == 1)
            result.type = ModeType.Color;
        else if (mode == 2)
            result.type = ModeType.Position;
        else if (mode == 3)
            result.type = ModeType.PositionAndColor;
        else
            result.type = ModeType.None;
        return result;
    }
}
