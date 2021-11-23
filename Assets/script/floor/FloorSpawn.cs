using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawn : MonoBehaviour
{
    public GameObject initialBody;
    public Vector3 offset = new Vector3(0.5f,0.5f,0.0f);
    void Start()
    {
        Vector3 last = Camera.main.ViewportToWorldPoint(Vector3.zero);
        float screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x;
        last = last + offset;
          for (float i = last.x; i < screenWidth;i= last.x + 1)
        {
            GameObject aux = Instantiate(initialBody,new Vector3(i,last.y,transform.position.z),Quaternion.identity,transform);
            last = aux.transform.position;
        }
    }
}
