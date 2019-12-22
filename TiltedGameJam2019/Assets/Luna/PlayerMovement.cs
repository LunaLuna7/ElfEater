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

    [SerializeField]
    private Rigidbody2D rb;
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
    
    private void Update()
    {
       m_Grounded = Physics2D.Linecast(transform.position, m_GroundCheck.position, m_GroundLayer);
       
       if (Input.GetButtonDown("Transfer" + playerNumber))
       {
           GivePartnerWeight(1);
       }
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleGravity();
        rb.velocity = targetVelocity;
    }

    private void HandleMovement()
    {
        targetVelocity.x = Input.GetAxisRaw("Horizontal" + playerNumber) * horizontalSpeed;
    }
    private void HandleGravity()
    {
        if (m_Grounded)
        {
            targetVelocity.y = 0;
        }
        else
        {
            targetVelocity.y = -fallSpeed;
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

        //The partner
        partner.currentWeigth += argValue;
        partner.UpdateTextWeight(partner.currentWeigth);
    }
}
