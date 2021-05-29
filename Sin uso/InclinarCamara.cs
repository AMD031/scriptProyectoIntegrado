using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InclinarCamara : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineVirtualCamera vcam;
    private CinemachineTransposer transposer;
    private float v;
    private float inlinacion = 2.34f;
    void Start()
    {
       transposer =  vcam.GetCinemachineComponent<CinemachineTransposer>();

      
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Mouse ScrollWheel");

        if (v > 0 && transposer.m_FollowOffset.y <= 9.22f)
        {
            transposer.m_FollowOffset = new Vector3(0f,inlinacion +=1f, -6.38f);
        }

        if (v < 0 && transposer.m_FollowOffset.y >= -0.22f)
        {
            transposer.m_FollowOffset = new Vector3(0f, inlinacion -= 1f, -6.38f);
        }


    }
}
