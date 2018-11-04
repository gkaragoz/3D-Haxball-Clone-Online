using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {


    public GameObject ball;
    private Rigidbody rigidbody;
    public float speed = 2;
    private float cachedPlayerAngle;

    public Slider m_AimSlider;

    public Text boosttext;


    public float m_MinLaunchForce = 5f;       
    public float m_MaxLaunchForce = 15f;      
    public float m_MaxChargeTime = 0.75f;

    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;                
    private bool m_Fired;

    

    void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }




    void Start () {

        rigidbody = GetComponent<Rigidbody>();
 

        boosttext.text = "";


        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;

    }
	
	void FixedUpdate () {


        var horizantal = CrossPlatformInputManager.GetAxis("Horizontal");
        var vertical = CrossPlatformInputManager.GetAxis("Vertical");

   
        //playerin joystick e göre dönmesi
        if (horizantal != 0 || vertical != 0)
        {
            float myAngle = Mathf.Atan2(horizantal, vertical) * Mathf.Rad2Deg;
            float lerpangle = Mathf.LerpAngle(cachedPlayerAngle, myAngle, Time.deltaTime * 10);
            cachedPlayerAngle = lerpangle;
            transform.eulerAngles = new Vector3(0, lerpangle, 0);
        }

        //playerin joystick e göre hareket etmesi
        Vector3 moveVec = new Vector3(horizantal, 0, vertical) * speed;
        rigidbody.velocity=moveVec;



        m_AimSlider.value = m_MinLaunchForce;
        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        {
            m_CurrentLaunchForce = m_MaxLaunchForce;
            Fire();
        }
        else if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            m_Fired = false;
            m_CurrentLaunchForce = m_MinLaunchForce;

         //   m_ShootingAudio.clip = m_ChargingClip;
        //    m_ShootingAudio.Play();
        }
        else if (CrossPlatformInputManager.GetButton("Jump") && !m_Fired)
        {
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
            m_AimSlider.value = m_CurrentLaunchForce;
        }
        else if (CrossPlatformInputManager.GetButtonUp("Jump") && !m_Fired)
        {
            Fire();
        }



      

    }
    private void Fire()
    {
       // boosttext.text = "topa uzak";
        var ballpos = ball.transform.position;
        var playerpos = transform.position;


        float dist = Vector3.Distance(ballpos, playerpos);

        if (dist<4) //player topa 3 birimden yakınsa topa vurabilsin.
        {
            Vector3 newVector = ballpos - playerpos;
            ball.GetComponent<Rigidbody>().AddForce(2*newVector * m_CurrentLaunchForce*(3/dist));

          //  boosttext.text = (2*newVector * m_CurrentLaunchForce / dist).ToString();
        }



        m_CurrentLaunchForce = m_MinLaunchForce;

    }
}
