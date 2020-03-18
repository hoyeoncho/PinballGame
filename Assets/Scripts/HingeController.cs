using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeController : MonoBehaviour
{
    // 힌지조인트 ( 반드시 리지드바디 ) 
    HingeJoint hj;
    // 입력받을 키 이름 -> 유니티 Input 설정 -> size 늘려서 받을 닉네임 추가 -> 해당 키 세팅
    public string inputName;
    // 스프링은 연결된 리지드바디와 비교하여, 일정한 각도에 도달시킨다. 
    // 해당 위치로 이동하는 힘 : spring
    public float pullingForce = 1000f;
    // 이 값이 높을수록 오브젝트 속도가 저하 : Damper
    public float dampperForce = 100f;
    // 목표 각도와 기본각도
    public float targetAngle = 45f;
    public float restAngle = 0f;
    //sfx sound
    public AudioClip sfxSound;


    void Start()
    {
        hj = GetComponent<HingeJoint>();
        hj.useSpring = true;
    }

    void Update()
    {
        JointSpring jointSpring = new JointSpring();
        jointSpring.spring = pullingForce;
        jointSpring.damper = dampperForce;

        // 지정한 키가 입력됬을 때 스프링객체의 목표 포지션을 설정
        if(Input.GetButtonDown(inputName))
        { 
            GameManager.Get.PlaySound(sfxSound, transform.position);
        }
        if (Input.GetAxis(inputName) == 1)
        {
            jointSpring.targetPosition = targetAngle;
        }
        else
        {
            jointSpring.targetPosition = restAngle;
        }
        // 만든 스프링객체 전달
        hj.spring = jointSpring;
        // 활성화하면 Min과 Max 값 내에 힌지 각도가 제한 됨 
        hj.useLimits = true;
    }
}
