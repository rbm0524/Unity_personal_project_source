using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����Ǵ� Zombie ����ü
public class Clone : MonoBehaviour
{
    public GameObject zombiePrefab;
    public GameObject player;
    void Start()
    {
        gameObject.SetActive(false); //���� �����

        for (int i = 0; i < 10; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-40f, 40f), // x ��ǥ ���� ������ ������ �� ����
                1.2f, // y ��ǥ�� ����
                Random.Range(-40f, 40f) // z ��ǥ ���� ������ ������ �� ����
            );
            GameObject zombie = Instantiate(zombiePrefab, position, Quaternion.identity);
            zombie.GetComponent<Enemy>().target = player.transform;
            zombie.GetComponent<Enemy>().bottlePrefab = Resources.Load<GameObject>("Bottle_Health"); //Resources������ Bottle_Health Prefab�� �Ҵ�
            zombie.tag = "Zombie"; // ����ü�� tag�� ����
        }

        InvokeRepeating("SpawnZombie", 1f, 1f); // Zombie 1�ʸ��� ����
    }
    void SpawnZombie()
    {
        Vector3 position = new Vector3(
            Random.Range(-40f, 40f), // x ��ǥ ���� ������ ������ �� ����
            1.2f, // y ��ǥ�� ����
            Random.Range(-40f, 40f) // z ��ǥ ���� ������ ������ �� ����
        );
        GameObject zombie = Instantiate(zombiePrefab, position, Quaternion.identity); //����ü ����, zombie ������ ���� ����
        zombie.GetComponent<Enemy>().target = player.transform;
        zombie.GetComponent<Enemy>().bottlePrefab = Resources.Load<GameObject>("Bottle_Health"); //Resources������ Bottle_Health Prefab�� �Ҵ�
        zombie.tag = "Zombie"; // ����ü�� tag�� ����
    }
}



