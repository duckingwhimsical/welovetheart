using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private float initialX;
    private float initialY;

    private float currentX;
    private float currentY;

    private const float floatFudge = 0.0001f;
    private const float maxDistanceToRespond = 0.5f;
    private const float respondMoveMax = 0.2f;

    public void Initialize(float x, float y)
    {
        initialX = x;
        initialY = y;

        currentX = x;
        currentY = y;
    }

    public bool AtPosition(float x, float y)
    {
        return Mathf.Abs(x - currentX) < floatFudge && Mathf.Abs(y - currentY) < floatFudge;
    }

    public void TouchPointsEngage(Vector3 one, Vector3 two)
    {
        float distanceOne = Vector3.Distance(one, this.transform.position);
        float distanceTwo = Vector3.Distance(one, this.transform.position);

        float distance = distanceOne > distanceTwo ? distanceTwo : distanceOne;

        Vector3 localPosition = this.transform.localPosition;
        if (distance < maxDistanceToRespond)
        {
            float lerp = Mathf.InverseLerp(maxDistanceToRespond, 0, distance); //doesn't account for size of object
            float move = Mathf.Lerp(0, respondMoveMax, lerp);
            localPosition.z = move;
        }
        else
            localPosition.z = 0;

        this.transform.localPosition = localPosition;
    }
    
    public void Move(float x, float y)
    {

    }
}
