//ORG: ghostyii & MOONLIGHTGAME
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUtility
{
    //sen 为最低敏感度 (unit: pixel)
    public static Direction? GetDirection(Vector2 start, Vector2 end, Vector2 sen)
    {
#if UNITY_EDITOR
        if (sen.x < 0 || sen.y < 0)
            Debug.Log("敏感度不得为负数");
#endif
        //Direction res = Direction.Up;
        Vector2 delta = end - start;
        Vector2 absDelta = new Vector2(Mathf.Abs(delta.x), Mathf.Abs(delta.y));

        if (absDelta.x < sen.x && absDelta.y < sen.y)
            return null;

        Vector2 tmpEnd = start;
        tmpEnd.x = start.x + 50f;
        float angle = Vector2.SignedAngle(Vector2.ClampMagnitude(tmpEnd - start, 1), Vector2.ClampMagnitude(end - start, 1));

        if (angle > 0)
        {
            if (angle <= 45)
                return Direction.Right;
            else if (angle > 45 && angle <= 135)
                return Direction.Up;
            else
                return Direction.Left;
        }
        else if (angle < 0)
        {
            angle = -angle;
            if (angle <= 45)
                return Direction.Right;
            else if (angle > 45 && angle <= 135)
                return Direction.Down;
            else
                return Direction.Left;
        }
        else
            return Direction.Right;
    }

    
}
