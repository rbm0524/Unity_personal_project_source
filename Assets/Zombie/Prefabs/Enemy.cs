using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Player�� ������� �� + ������ ����, ������ ���·� �������� ��� �����ؾ� ��.
public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public static int score = 0; //static�� ���� : clone������ score�� �����ؾ� �ϱ� ����
    public Transform target; //���� ������Ʈ
    public static int headShot_Count = 0;

    public Vector3 zombiePosition;

    public GameObject bottlePrefab; // ������ �� ������

    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent navigate;  //NavMesh : NavAgent�� ��θ� �׸��� ���� ����, ������ ���� navmesh�� static ������Ʈ������ ��� ����, �ٴ��� static����

    void Awake() // ���۵Ǳ� ���� �ʱ�ȭ
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        navigate = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navigate.SetDestination(target.position); //������Ʈ�� ��ġ�� ����

        if (currentHealth <= 0)
        {
            score += 10;
            Destroy(gameObject); //���� ����
        }
    }

    void FreezeVelocity() // navagent �̵��� �������� ���ϵ��� (�������� ȸ����, �ӵ��� zero)

    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate() //�� �����Ӹ��� ȣ��, ���� �ð� �������� ȣ��
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