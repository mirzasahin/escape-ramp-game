using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;

public class PlayerController : MonoBehaviour
{
    AudioManager audioManager;

    private float dirRight;

    [SerializeField] float dirSpeedRight;
    [SerializeField] float dirSpeedForward;

    [SerializeField] float jumpForce;

    private Animator playerAnim;
    private Rigidbody playerRb;

    private bool isLive;

    public Ease barrelEase;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        isLive = true;
    }

    // Update is called once per frame

    private void Update()
    {
        Live();
        Jump();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && isLive)
        {
            audioManager.PlaySFX(audioManager.hitWoodSFX);
            audioManager.StopBackgroundMusic();
            isLive = false;
            playerAnim.SetBool("Die", true);

            yield return new WaitForSeconds(0.9f);
            audioManager.PlaySFX(audioManager.fallingSFX);

        }
    }



    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isLive && IsGrounded())
        {
            audioManager.PlaySFX(audioManager.jumpSFX);
            playerAnim.SetTrigger("Jumped");
            playerRb.transform.DOMoveY(2, 0.5f).SetEase(barrelEase).OnComplete(() =>
            {
                playerRb.transform.DOMoveY(0, 0.4f).SetEase(barrelEase); // InOutFlash
            });
        }
    }

    private void Live()
    {
        if (isLive)
        {
            dirRight = Input.GetAxis("Horizontal") * dirSpeedRight * Time.deltaTime;
            transform.Translate(dirRight, 0, dirSpeedForward * Time.deltaTime);
             
        }
    }

    private bool IsGrounded()
    {
        if(transform.position.y <= 0.1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
