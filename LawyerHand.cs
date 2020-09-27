using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawyerHand : MonoBehaviour
{
    public float[] handPositions = new float[1];

    public void SetHandPosition(int lawyerLevel)
    {
        float handX;
        if(lawyerLevel >= handPositions.Length - 1)
        {
            handX = handPositions[handPositions.Length - 1];
        }
        else
        {
            handX = handPositions[lawyerLevel];
        }
        transform.position = new Vector2(handPositions[lawyerLevel], transform.position.y);
    }


}
