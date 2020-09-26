using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawyerHand : MonoBehaviour
{
    Transform holderTransform;
    public float[] handPositions = new float[1];

    // Start is called before the first frame update
    void Start()
    {
        holderTransform = transform;
    }

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
        holderTransform.position = new Vector2(handPositions[lawyerLevel], holderTransform.position.y);
    }


}
