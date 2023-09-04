using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(0, 1).OnComplete(() =>
        {
            transform.DOMoveY(-2.05f, 1f)
            .SetEase(Ease.OutCirc)
            .SetLoops(-1, LoopType.Yoyo);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
