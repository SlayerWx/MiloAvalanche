using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public float normalTimeToSpawn;
    public float maxTimeToRandom;
    bool waiting;
    void Start()
    {
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

        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if(bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
        }
        waiting = false;
    }
}
