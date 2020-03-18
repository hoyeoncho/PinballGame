using UnityEngine;

public class SphereController : MonoBehaviour
{
    // AddForce는 월드 좌표를 기준, AddRelativeForce는 로컬 좌표를 기준

    // ForceMode.Force : 질량 적용, 연속적인 힘을 가함
    // ForceMode.Impulse : 질량 적용, 순간적인 힘을 가함
    // ForceMode.Acceleration : 질량 무시, 연속적인 힘을 가함
    // ForceMode.VelocityChange : 질량 무시, 순간적인 힘을 가함

    /*
    Rigidbody rg;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {

        rg.AddForce(transform.forward * 3f, ForceMode.Force);
    }
    */
}
