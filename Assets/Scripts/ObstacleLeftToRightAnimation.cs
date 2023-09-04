using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleLeftToRightAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveZ(3.6f, 2.5f).OnComplete(() =>
        {
            transform.DOMoveZ(-3.6f, 2.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
