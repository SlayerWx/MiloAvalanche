﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject aux;
        for(int i = 0; i < amountToPool;i++)
        {
            aux = Instantiate(objectToPool);
            aux.SetActive(false);
            pooledObjects.Add(aux);
        }
    }
    public GameObject GetPooledObject()
    {
        for(int i = 0; i <amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}