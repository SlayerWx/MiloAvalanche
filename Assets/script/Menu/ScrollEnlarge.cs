using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScrollEnlarge : MonoBehaviour
{
    public RectTransform from;
    public RectTransform to;

    public void ChangeHeight()
    {
        to.rect.Set(to.rect.x, to.rect.y, to.rect.width, from.rect.height);
    }
}
