using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Player

public class Player : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public bool isDamage;
    public bool Getitem;
    public GameObject[] items; //아이템들의 배열
    public bool[] hasitems; //아이템을 가지고 있는지 여부 검사
    public string sceneName = "GameOver";

    public int count; //Bottle_Health 개수
    public bool recovery;

    GameObject nearObject;
    public GameObject mysteryBoxPrefab;

    public void OnTriggerEnter(Collider other) //좀비와 충돌 시
    {
        if (other.tag == "Zombie")
        {
            if (!isDamage) //데미지를 받지 않을 때 실행 여러명한테 순간적으로 맞는 것을 방지(무적타임)
            {
                currentHealth -= 1; //Zombie의 데미지를 1로 설정한 셈
                Debug.Log("Player Health : " + currentHealth);
                StartCoroutine(Ondamage());
            }
        }
    }

    public void OnTriggerStay(Collider other) //물약과 충돌 시 어떤 물체를 감지하는 동안 처리
    {
        if(other.tag == "Health")
        {
            nearObject = other.gameObject;
        }   
    }

    public void OnTriggerExit(Collider other) //nearObject 초기화
    {
        if (other.tag == "Health")
        {
            nearObject = null;
        }
    }

    void GetInput()
    {
        Getitem = Input.GetButton("Get"); // e를 입력 시 Getitem을 true

        recovery = Input.GetButtonDown("Recovery"); //f를 입력 시 recovery를 true로
    }

    void Get()
    {
        if(Getitem && nearObject != null) //Getitem이 true이고 nearObject가 not null일 때
        {
            if(nearObject.tag == "Health") //충돌한 것의 tag가 Health면 실행
            {
                Bottle_Health health = nearObject.GetComponent<Bottle_Health>();
                int itemIndex = health.value;
                hasitems[itemIndex] = true; //health는 0번째 값이므로 인벤토리의 0번째 값이 true

                if(count == 0)
                {
                    hasitems[itemIndex] = false;
                }


                Destroy(nearObject);
                nearObject = null;
                count += 1; //Bottle_Health 개수 올리기
            }
        }
    }

    IEnumerator Recovery()
    {
        while(true)
        {
            yield return new WaitUntil(() => recovery && count > 0 && currentHealth < maxHealth); //recovery가 true이고 소지한 물약의 개수가 0개 이상이고 현재 체력이 최대 체력보다 작을 때
            currentHealth += 1;
            count -= 1;
            recovery = false;
            yield return null;
        }
    }

    private void Start()
    {
        recovery = false;
        StartCoroutine(Recovery());
        StartCoroutine(CreateMysteryBox()); //MysteryBox 생성 코루틴
    }

    IEnumerator CreateMysteryBox() // mysterBox생성
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(45f); // 45초마다 하나씩 생성
            Vector3 playerPos = GameObject.Find("Player").transform.position;
            float playerX = playerPos.x;
            float playerZ = playerPos.z;

            float minX = -40f;
            float maxX = 40f;
            float minZ = -40f;
            float maxZ = 40f;
            //생성될 수 있는 범위 제한
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);

            while (Mathf.Abs(randomX - playerX) <= 10f && Mathf.Abs(randomZ - playerZ) <= 10f) //player와의 거리 검사, 거리가 10 이상일 때만 mysterybox 생성되도록 좌표 설정
            {
                randomX = Random.Range(minX, maxX);
                randomZ = Random.Range(minZ, maxZ);
            }

            Vector3 randomPos = new Vector3(randomX, 0.52f, randomZ); //y좌표 0.52로 고정
            GameObject box = Instantiate(mysteryBoxPrefab, randomPos, Quaternion.identity);
            box.GetComponent<Rigidbody>().WakeUp();
            box.tag = "Box";
        }
    }

    void Update()
    {
        GetInput();
        Get();
        if(currentHealth <= 0)
        {
            int currentscore = Enemy.score;
            if (currentscore > PlayerPrefs.GetInt("MaxScore")) //값이 없으면 0을 반환함.
            {
                PlayerPrefs.SetInt("MaxScore", currentscore);
            }
            Enemy.score = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator Ondamage()
    {
        isDamage = true; //데미지를 받으면 true로
        yield return new WaitForSeconds(1f);
        isDamage = false;
    }

}
