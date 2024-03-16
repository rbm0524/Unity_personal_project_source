using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Player를 따라오는 적 + 복제본 생성, 숨겨진 상태로 복제본을 계속 생성해야 함.
public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public static int score = 0; //static인 이유 : clone에서도 score를 공유해야 하기 때문
    public Transform target; //따라갈 오브젝트
    public static int headShot_Count = 0;

    public Vector3 zombiePosition;

    public GameObject bottlePrefab; // 생성할 병 프리팹

    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent navigate;  //NavMesh : NavAgent가 경로를 그리기 위한 바탕, 없으면 에러 navmesh는 static 오브젝트에서만 사용 가능, 바닥을 static으로

    void Awake() // 시작되기 전에 초기화
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        navigate = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navigate.SetDestination(target.position); //오브젝트의 위치를 따라감

        if (currentHealth <= 0)
        {
            score += 10;
            Destroy(gameObject); //좀비 삭제
        }
    }

    void FreezeVelocity() // navagent 이동을 방해하지 못하도록 (물리적인 회전력, 속도를 zero)

    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate() //매 프레임마다 호출, 일정 시간 간격으로 호출
    {
        FreezeVelocity();
    }

    public void OnDestroy()
    {
        Bottle_Health_Clone.zombiePosition = transform.position;
        Bottle_Health_Clone bottleScript = FindObjectOfType<Bottle_Health_Clone>();
        if (bottleScript != null)
        {
            bottleScript.isDestroy = true;
        }
    }
}