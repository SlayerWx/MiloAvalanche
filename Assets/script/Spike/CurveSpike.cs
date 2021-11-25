using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CurveSpike : BaseEnemy
{
    public float maxDistance;
    public float closeCurveForMulty = 1;
    float xOrientation;
    const float badRotateCorrection = -90;
    public CurveSpike(Color myColor, float speed, float endYPos) : base(myColor, speed, endYPos) { }
    public override void OnEnable(GameObject GM)
    {
        base.OnEnable(GM);
        maxDistance = Vector3.Distance(GM.transform.position, Vector3.down * endYPos);
        if (GM.transform.position.x < 0) xOrientation = 1;
        else xOrientation = -1;
        GM.transform.rotation = Quaternion.identity;
    }
    protected override void FallingStyle(GameObject GM)
    {
        float aux = (Mathf.Sin(Vector3.Distance(GM.transform.position, Vector3.down * endYPos) / maxDistance)
            * Vector3.Distance(GM.transform.position, Vector3.down * endYPos) * closeCurveForMulty) * xOrientation;
        Debug.Log(maxDistance);
        Vector3 nextPos;
        nextPos = GM.transform.position + new Vector3(aux, -speed) * Time.deltaTime;
        nextPos = (GM.transform.position - nextPos).normalized;
        GM.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(nextPos.y, nextPos.x) * Mathf.Rad2Deg, Vector3.forward);
        GM.transform.Rotate(0, 0, badRotateCorrection);
        GM.transform.position += new Vector3(aux, -speed) * Time.deltaTime;
    }
}
