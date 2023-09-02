using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HorizontalAnimation : MonoBehaviour
{
    public Transform positiveToNegative, NegativeToPositive;
    // Start is called before the first frame update
    void Start()
    {
        NegativeToPositive.transform.DOMoveZ(-3.6f, 2.5f).OnComplete(() =>
        {
            NegativeToPositive.transform.DOMoveZ(3.6f, 2.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
        });

        positiveToNegative.transform.DOMoveZ(3.6f, 2.5f).OnComplete(() =>
        {
            positiveToNegative.transform.DOMoveZ(-3.6f, 2.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
