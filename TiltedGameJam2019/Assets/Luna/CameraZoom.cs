using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float smallScopeTreshold;

    [SerializeField]
    private float transitionBetweenCamerasSpeed;
    [SerializeField]
    private CinemachineVirtualCamera vcam;
    [SerializeField]
    private CinemachineVirtualCamera vcam2;
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( vcam.gameObject.activeSelf == false && PlayerYDistance() < smallScopeTreshold)
        {
            vcam.gameObject.SetActive(true);
            vcam2.gameObject.SetActive(false);
        }
        else if(vcam.gameObject.activeSelf == true && PlayerYDistance() >= smallScopeTreshold)
        {
            vcam.gameObject.SetActive(false);
            vcam2.gameObject.SetActive(true);
            //vcam.m_Lens.OrthographicSize = Mathf.Lerp( vcam.m_Lens.OrthographicSize, 15, 10f * Time.deltaTime);
        }
    }

    private float PlayerYDistance()
    {
        return Mathf.Abs(player1.transform.position.y - player2.transform.position.y);
    }
}
