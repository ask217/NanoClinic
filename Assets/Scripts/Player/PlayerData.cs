using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")] //project menu에서 우클릭으로 플레이어의 정보를 저장합니다
public class PlayerData : ScriptableObject
{
    [Header("Gravity")]
    [HideInInspector] public float gravityStrength; //jumpHeight와 jumpTimeToApex에 필요한 힘(중력)을 아래로 가하는 정도
    [HideInInspector] public float gravityScale = 1; //플레이어 중력 배수(ProjectSettings/Physics2D에서 설정 가능)
                                                     //플레이어 rigidbody2D.gravityScale도 이 값으로 설정
    [Space(5)]
    public float fallGravityMult; //중력 배수
    public float maxFallSpeed; //기본 최대 낙하 속도
    [Space(5)]
    public float fastFallGravityMult; //아래키를 누르고 있을 때 적용되는 중력 배수
    public float maxFastFallSpeed; //아래키로 빠르게 낙하할 때 최대 낙하 속도

    [Space(20)]

    [Header("Run")]
    public float runMaxSpeed; //플레이어 최대 속도
    public float runAcceleration; //플레이어 가속
    [HideInInspector] public float runAccelAmount; //플레이어에게 가해지는 실제 힘(가속)
    public float runDecceleration; //플레이어 감속
    [HideInInspector] public float runDeccelAmount; //플레이어에게 가해지는 실제 힘(감속)
    [Space(5)]
    [Range(0f, 1)] public float accelInAir; //공중에서 적용되는 플레이어 가속
    [Range(0f, 1)] public float deccelInAir;//공중에서 적용되는 플레이어 감속
    [Space(5)]
    public bool doConserveMomentum = true;

    [Space(20)]

    [Header("Jump")]
    public float jumpHeight; //점프 높이
    public float jumpTimeToApex; //점프 후 원하는 높이까지 도달하는 시간(중력과 점프력 제어)
    [HideInInspector] public float jumpForce; //플레이어에게 가해지는 실제 힘(위쪽)

    [Header("Both Jumps")]
    public float jumpCutGravityMult; //점프 중 버튼을 땠을 때 증가하는 중력 값
    [Range(0f, 1)] public float jumpHangGravityMult; //최대 점프 높이에 가까워질 때 감소하는 중력 값
    public float jumpHangTimeThreshold; //플레이어가 점프가 끝났다고 느끼는 속도(0에 가깝다)
    [Space(0.5f)]
    public float jumpHangAccelerationMult;
    public float jumpHangMaxSpeedMult;

    [Header("Wall Jump")]
    public Vector2 wallJumpForce; //벽 점프 시 가해지는 실제 힘.
    [Space(5)]
    [Range(0f, 1f)] public float wallJumpRunLerp; //벽 점프 시 적용되는 이속 감소
    [Range(0f, 1.5f)] public float wallJumpTime; //벽 점프 시 플레이어가 감속되는 일정 시간
    public bool doTurnOnWallJump; //플레이어가 벽 점프 시 방향 전환에 가능 여부

    [Space(20)]

    [Header("Slide")]
    public float slideSpeed;
    public float slideAccel;

    [Header("Assists")]
    [Range(0.01f, 0.5f)] public float coyoteTime; //플렛폼에서 떨어진 후에도 점프할 수 있는 여분의 시간
    [Range(0.01f, 0.5f)] public float jumpInputBufferTime; //점프를 누른 후 여분 시간, 여분 시간 내 조건이 충족되면 자동으로 점프가 됨(만약 공중에 있을 때 점프를 누르고 이 여분 시간이 끝나기 전 땅에 닿았다면 자동으로 점프합니다))

    [Space(20)]

    [Header("Dash")]
    public int dashAmount;
    public float dashSpeed;
    public float dashSleepTime; //대쉬를 눌렀을 때 공중에서 방향을 입력받고 힘을 주기 전 공중에서 멈춰있는 시간 
    [Space(5)]
    public float dashAttackTime;
    [Space(5)]
    public float dashEndTime; //대쉬가 끝나는 시간(기본 상태와 부드럽게 전환하기 위함)
    public Vector2 dashEndSpeed; //플레이어 속도 저하, 대시 반응성 향상
    [Range(0f, 1f)] public float dashEndRunLerp; //대쉬 중 플레이어 감속
    [Space(5)]
    public float dashRefillTime;
    [Space(5)]
    [Range(0.01f, 0.5f)] public float dashInputBufferTime;


    //인스펙터가 업데이트 될 때 호출되는 유니티 콜백
    private void OnValidate()
    {
        //중력 세기 계산 식 : (gravity = 2 * jumpHeight / timeToJumpApex^2) 
        gravityStrength = -(2 * jumpHeight) / (jumpTimeToApex * jumpTimeToApex);

        //리지드바디의 중력스케일 계산, (ProjectSettings/Physics2D 참조) 
        gravityScale = gravityStrength / Physics2D.gravity.y;

        //달릴 때 가속, 감속 계산 식 : amount = ((1 / Time.fixedDeltaTime) * acceleration) / runMaxSpeed
        runAccelAmount = (50 * runAcceleration) / runMaxSpeed;
        runDeccelAmount = (50 * runDecceleration) / runMaxSpeed;

        //점프 힘 계산 식 (initialJumpVelocity = gravity * timeToJumpApex)
        jumpForce = Mathf.Abs(gravityStrength) * jumpTimeToApex;

        #region 가속,감속 가변 범위
        runAcceleration = Mathf.Clamp(runAcceleration, 0.01f, runMaxSpeed);
        runDecceleration = Mathf.Clamp(runDecceleration, 0.01f, runMaxSpeed);
        #endregion
    }
}

// created by Dawnosaur :D
