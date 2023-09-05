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

    public bool completedLevel;

    [SerializeField] float dirSpeedRight;
    [SerializeField] float dirSpeedForward;

    [SerializeField] float jumpForce;

    private bool hasPlayedDivingSound;

    private Animator playerAnim;
    private Rigidbody playerRb;

    public bool isLive;

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
        Movement();
        Jump();
        DivingAnimation();
        CompletedLevel();
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
        if (Input.GetKeyDown(KeyCode.Space) && isLive && IsGrounded() && !completedLevel)
        {
            audioManager.PlaySFX(audioManager.jumpSFX);
            playerAnim.SetTrigger("Jumped");
            //playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);

            playerRb.transform.DOMoveY(2, 0.5f).SetEase(barrelEase).OnComplete(() =>
            {
                playerRb.transform.DOMoveY(0, 0.4f).SetEase(barrelEase); // InOutFlash
            });
        }
    }

    private void Movement()
    {
        if (isLive && !completedLevel)
        {
            dirRight = Input.GetAxis("Horizontal") * dirSpeedRight * Time.deltaTime;
            if(Input.GetKey(KeyCode.D))
            {
                playerAnim.SetBool("Run Right", true);
                playerAnim.SetBool("Run Left", false);
                dirSpeedForward = 4.5f;

            }
            else if (Input.GetKey(KeyCode.A))
            { 
                playerAnim.SetBool("Run Left", true);
                playerAnim.SetBool("Run Right", false);
                dirSpeedForward = 4.5f;
            }

            else
            {
                playerAnim.SetBool("Run Right", false);
                playerAnim.SetBool("Run Left", false);
                dirSpeedForward = 6;
            }
        }

        if (isLive)
        {
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

    private void DivingAnimation()
    {
        if(transform.position.x <= -268 && !hasPlayedDivingSound) 
        {
            playerAnim.SetTrigger("Diving");
            audioManager.PlaySFX(audioManager.wooSFX);
            hasPlayedDivingSound = true;
        }
    }

    private void CompletedLevel()
    {
        if(transform.position.x <= -245)
        {
            completedLevel = true;
            transform.DOMoveZ(0, 2f);
            playerAnim.SetBool("Run Right", false);
            playerAnim.SetBool("Run Left", false);
        }
        else
        {
            completedLevel = false;
        }
    }
}
