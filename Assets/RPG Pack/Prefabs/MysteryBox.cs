using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    public int boxHealth;
    public GameObject[] resourceArray;


    private void Start()
    {
        boxHealth = 3;
        resourceArray = Resources.LoadAll<GameObject>("items"); //Resources�� ���� ���丮�� items ���丮�� prefab���� ��� �ε��Ѵ�. ������ ���� ������ �������� 2�� �̻� ������ �� �����ϰ� �����Ǵ� ���� �����ֱ� ����
    }

    private void Update()
    {
        if(boxHealth == 0)
        {
            Destroy(gameObject);
            DestroyBox();
        }
    }

    private void DestroyBox()
    {
        int randomIndex = Random.Range(0, resourceArray.Length); // �������� �ε��� ����
        Debug.Log(randomIndex);
        Vector3 spawnPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        Instantiate(resourceArray[randomIndex], spawnPosition, Quaternion.identity); // ���õ� ������ �ν��Ͻ�ȭ
    }
}