using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySpike : MonoBehaviour
{
    public float basicSpeed = 10.0f;
    public float endYPos = 0.0f;
    public float probNormalSpike = 80.0f;
    public Color normalSpikeColor;
    public float probCurveSpike = 20.0f;
    public Color curveSpikeColor;
    public BaseEnemy NewSpike()
    {
        switch(Random.Range(0, probNormalSpike + probCurveSpike))
        {
            case float a when probNormalSpike >= a:
                return new NormalSpike(normalSpikeColor,basicSpeed,endYPos); 
            case float a when probCurveSpike + probNormalSpike >= a:
                return new CurveSpike(curveSpikeColor,basicSpeed, endYPos);
        }
        return new NormalSpike(normalSpikeColor,basicSpeed, endYPos);
    }
}
