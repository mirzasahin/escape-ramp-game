using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenManager : MonoBehaviour
{
    public Transform mushRoom;
    // Start is called before the first frame update
    void Start()
    {
        mushRoom.DOMoveZ(-3.6f, 2f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
