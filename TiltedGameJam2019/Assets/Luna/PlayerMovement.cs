using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int playerNumber;
    [SerializeField]
    private PlayerMovement partner;

    [SerializeField, Tooltip("speed the player incrementally falls")] 
    private float fallSpeed;

    [SerializeField] 
    private float horizontalSpeed;

    [Space]
    [Header("Components")]
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject gift;
    [SerializeField]
    private TextMeshProUGUI textGiftUI;

    [Space]
    [Header("Ground")]

    [SerializeField]
    private bool m_Grounded = false;
    
    [SerializeField]
    private LayerMask m_GroundLayer;

    [SerializeField]
    private Transform m_GroundCheck;
    
    [Tooltip("The players current weight")]
    public int currentWeigth = 1;
    
    [SerializeField]
    private TextMeshPro textWeight;
    private Vector2 targetVelocity;
    private float dir;

    private float horizontalDashSpeed;
    private float originalHorizontalSpeed;
    
    private void Start() 
    {
        originalHorizontalSpeed = horizontalSpeed;
        horizontalDashSpeed = horizontalSpeed * 1.4f;    
        GivePartnerWeight(0);
    }

    private void Update()
    {
       m_Grounded = Physics2D.Linecast(transform.position, m_GroundCheck.position, m_GroundLayer);
       anim.SetBool("Grounded", m_Grounded);
       
       if (Input.GetButtonDown("Transfer" + playerNumber) && currentWeigth > 0 && currentWeigth < 11)
       {
           GivePartnerWeight(1);
       }
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleGravity();
        rb.velocity = targetVelocity;

        if (dir > 0)
        {
            sprite.flipX = true;
        }
        else if(dir < 0)
        {
            sprite.flipX = false;
        }
    }

    private void HandleMovement()
    {
        dir = Input.GetAxisRaw("Horizontal" + playerNumber);
        targetVelocity.x = dir * horizontalSpeed;
    }
    private void HandleGravity()
    {
        if (m_Grounded)
        {
            targetVelocity.y = 0;
        }
        else
        {
            targetVelocity.y = -fallSpeed - (currentWeigth * .5f);
        }
    }

    public void UpdateTextWeight(int argValue)
    {
        textWeight.text = argValue.ToString();
    }

    private void GivePartnerWeight(int argValue)
    {
        //This player
        currentWeigth -= argValue;
        UpdateTextWeight(currentWeigth);
        gift.transform.localScale -= new Vector3(.1f,.1f,.1f);
        textGiftUI.text = currentWeigth.ToString();

        //The partner
        partner.currentWeigth += argValue;
        partner.UpdateTextWeight(partner.currentWeigth);
        partner.gift.transform.localScale += new Vector3(.1f,.1f,.1f);
        partner.textGiftUI.text = partner.currentWeigth.ToString();
    }

    public void Dash()
    {
        horizontalSpeed = horizontalDashSpeed;
        StartCoroutine(NormalSpeed());
    }

    private IEnumerator NormalSpeed()
    {
        yield return new WaitForSeconds(5f);
        horizontalSpeed = originalHorizontalSpeed;
    }
}
