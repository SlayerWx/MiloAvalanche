using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct GMandEnem
{
    public GameObject GM;
    public BaseEnemy BE;
        
};
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public float substractToScale = 2.0f;
    private List<SpikeTypeController> baseEnemyComponents; //toHelpFactory
    public FactorySpike factorySpike;
    void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        baseEnemyComponents = new List<SpikeTypeController>();
        GameObject aux;
        for(int i = 0; i < amountToPool;i++)
        {
            aux = Instantiate(objectToPool);
            aux.transform.localScale = Vector3.one * (Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x / substractToScale);
            aux.SetActive(false);
            pooledObjects.Add(aux);
            SpikeTypeController aux2 = aux.GetComponent<SpikeTypeController>();
            aux2.myBaseEnemy = factorySpike.NewSpike();
            baseEnemyComponents.Add(aux2);
        }
    }
    public GMandEnem GetPooledObject()
    {
        GMandEnem aux;
        for (int i = 0; i <amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                baseEnemyComponents[i].myBaseEnemy = factorySpike.NewSpike();
                baseEnemyComponents[i].TheOnEnable();
                aux.GM = pooledObjects[i];
                aux.BE = baseEnemyComponents[i].myBaseEnemy;
                return aux;
            }
        }
        aux.GM = null;
        aux.BE = null;
        return aux;
    }
}
