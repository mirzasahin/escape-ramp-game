using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 offset = new Vector3(5.5f, 5.5f, 6.64f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = target.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * 5);
    }
}
