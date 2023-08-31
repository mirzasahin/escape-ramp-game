using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (!gameObject)
        {
            return;
        }
        transform.DORotate(new Vector3(0, 360, 0), 5f)
            .SetLoops(-1, LoopType.Restart)
            .SetRelative()
            .SetEase(Ease.Linear);

        transform.DOMoveY(1.2f, 3f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    


}
