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
    public GameObject[] items; //�����۵��� �迭
    public bool[] hasitems; //�������� ������ �ִ��� ���� �˻�
    public string sceneName = "GameOver";

    public int count; //Bottle_Health ����
    public bool recovery;

    GameObject nearObject;
    public GameObject mysteryBoxPrefab;

    public void OnTriggerEnter(Collider other) //����� �浹 ��
    {
        if (other.tag == "Zombie")
        {
            if (!isDamage) //�������� ���� ���� �� ���� ���������� ���������� �´� ���� ����(����Ÿ��)
            {
                currentHealth -= 1; //Zombie�� �������� 1�� ������ ��
                Debug.Log("Player Health : " + currentHealth);
                StartCoroutine(Ondamage());
            }
        }
    }

    public void OnTriggerStay(Collider other) //����� �浹 �� � ��ü�� �����ϴ� ���� ó��
    {
        if(other.tag == "Health")
        {
            nearObject = other.gameObject;
        }   
    }

    public void OnTriggerExit(Collider other) //nearObject �ʱ�ȭ
    {
        if (other.tag == "Health")
        {
            nearObject = null;
        }
    }

    void GetInput()
    {
        Getitem = Input.GetButton("Get"); // e�� �Է� �� Getitem�� true

        recovery = Input.GetButtonDown("Recovery"); //f�� �Է� �� recovery�� true��
    }

    void Get()
    {
        if(Getitem && nearObject != null) //Getitem�� true�̰� nearObject�� not null�� ��
        {
            if(nearObject.tag == "Health") //�浹�� ���� tag�� Health�� ����
            {
                Bottle_Health health = nearObject.GetComponent<Bottle_Health>();
                int itemIndex = health.value;
                hasitems[itemIndex] = true; //health�� 0��° ���̹Ƿ� �κ��丮�� 0��° ���� true

                if(count == 0)
                {
                    hasitems[itemIndex] = false;
                }


                Destroy(nearObject);
                nearObject = null;
                count += 1; //Bottle_Health ���� �ø���
            }
        }
    }

    IEnumerator Recovery()
    {
        while(true)
        {
            yield return new WaitUntil(() => recovery && count > 0 && currentHealth < maxHealth); //recovery�� true�̰� ������ ������ ������ 0�� �̻��̰� ���� ü���� �ִ� ü�º��� ���� ��
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
        StartCoroutine(CreateMysteryBox()); //MysteryBox ���� �ڷ�ƾ
    }

    IEnumerator CreateMysteryBox() // mysterBox����
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(45f); // 45�ʸ��� �ϳ��� ����
            Vector3 playerPos = GameObject.Find("Player").transform.position;
            float playerX = playerPos.x;
            float playerZ = playerPos.z;

            float minX = -40f;
            float maxX = 40f;
            float minZ = -40f;
            float maxZ = 40f;
            //������ �� �ִ� ���� ����
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);

            while (Mathf.Abs(randomX - playerX) <= 10f && Mathf.Abs(randomZ - playerZ) <= 10f) //player���� �Ÿ� �˻�, �Ÿ��� 10 �̻��� ���� mysterybox �����ǵ��� ��ǥ ����
            {
                randomX = Random.Range(minX, maxX);
                randomZ = Random.Range(minZ, maxZ);
            }

            Vector3 randomPos = new Vector3(randomX, 0.52f, randomZ); //y��ǥ 0.52�� ����
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
            if (currentscore > PlayerPrefs.GetInt("MaxScore")) //���� ������ 0�� ��ȯ��.
            {
                PlayerPrefs.SetInt("MaxScore", currentscore);
            }
            Enemy.score = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    IEnumerator Ondamage()
    {
        isDamage = true; //�������� ������ true��
        yield return new WaitForSeconds(1f);
        isDamage = false;
    }

}
