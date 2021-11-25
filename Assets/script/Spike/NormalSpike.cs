using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSpike : BaseEnemy
{
    public NormalSpike(Color myColor, float speed, float endYPos) : base(myColor,speed,endYPos) { }
    protected override void FallingStyle(GameObject GM)
    {
        GM.transform.position += (Vector3.down * speed) * Time.deltaTime;
    }
}
