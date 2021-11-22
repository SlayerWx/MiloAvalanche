using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpikeManager : MonoBehaviour
{
    public float normalTimeToSpawn;
    public float maxTimeToRandom;
    bool waiting;
    float screenWidth;
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

        GameObject Spike = ObjectPool.SharedInstance.GetPooledObject();
        if(Spike != null)
        {
            Spike.transform.position = new Vector3(Random.Range(-screenWidth, screenWidth),transform.position.y, 0);
            Spike.SetActive(true);
        }
        waiting = false;
    }
}
