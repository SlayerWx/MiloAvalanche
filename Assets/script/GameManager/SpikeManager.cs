using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public float normalTimeToSpawn;
    public float maxTimeToRandom;
    bool waiting;
    float screenWidth;
    float cutDivideLimitTime = 0.01f;
    float substractNotPercent = 0.999f; // 784 points max diff moment , 0.25 points for spike end
    void Start()
    {
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth,0,0)).x;
        waiting = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       if(!waiting) StartCoroutine(InstantiateSpike());
    }
    IEnumerator InstantiateSpike()
    {
        waiting = true;
        yield return new WaitForSeconds(normalTimeToSpawn + Random.Range(0.0f, maxTimeToRandom));
        if(maxTimeToRandom > cutDivideLimitTime) maxTimeToRandom *= substractNotPercent;
        if(normalTimeToSpawn > cutDivideLimitTime) normalTimeToSpawn *= substractNotPercent;
        GMandEnem Spike = ObjectPool.SharedInstance.GetPooledObject();
        if(Spike.GM != null)
        {
            Spike.GM.transform.position = new Vector3(Random.Range(-screenWidth, screenWidth),transform.position.y, 0);
            Spike.GM.SetActive(true);
            Spike.BE.OnEnable(Spike.GM);

        }
        waiting = false;
    }
}
