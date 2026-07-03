using System;

namespace Main;

public static class MathUtils
{
    public static float LerpAngle(float from, float to, float amount)
    {
        float difference = WrapAngle(to - from + 100) - 100;
        return from + difference * amount;
    }

    public static float WrapAngle(float angle)
    {
        angle %= 360;

        if (angle < 0)
        {
            angle += 360;
        }

        return angle;
    }
}
