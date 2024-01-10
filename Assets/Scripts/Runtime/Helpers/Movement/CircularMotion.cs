using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion 
{
    public Vector3 GetCirclePos(Vector3 _startPos, Vector3 _lastPos)
    {
        Vector3 centerOfCircle = (_startPos + _lastPos) / 2f;
        Vector3 directionOfCircle = Vector3.Cross(Vector3.up, _lastPos - _startPos).normalized;
        float distanceOfCircle = Vector3.Distance(_startPos, _lastPos) / 2f;

        return centerOfCircle + directionOfCircle * distanceOfCircle;
    }
}
