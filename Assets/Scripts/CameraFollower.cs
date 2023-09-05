using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 offset = new Vector3(4.8f, 4.8f, 6.64f);

    private Camera mainCamera;

    Vector3 finishPosOffset = new Vector3(-250, 3, 0);

    Quaternion finishRotateOffset = Quaternion.Euler(5, -90, 0);
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.fieldOfView = 15;
        transform.position = target.transform.position + offset;
        AnimateFOV();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target.transform.position.x <= -245)
        {
            RotateCameraWithTween();
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * 5);
        }

        FinishCameraAnimationFOV();
    }

    private void AnimateFOV()
    {
        mainCamera.DOFieldOfView(50, 3f)
            .SetEase(Ease.InOutQuad).
            SetDelay(1.5f);
    }

    private void FinishCameraAnimationFOV()
    {
        if(target.transform.position.x <= -245)
        {
            mainCamera.DOFieldOfView(35, 3f)
            .SetEase(Ease.Linear);
            //.SetDelay(1.5f);
        }
    }

    private void RotateCameraWithTween()
    {
        // DOTween ile pozisyon ve dönüþü animasyonla deðiþtir
        transform.DOMove(finishPosOffset, 3f);
        transform.DORotateQuaternion(finishRotateOffset, 3f);
    }

    private void BlurCamera()
    {

    }
}
