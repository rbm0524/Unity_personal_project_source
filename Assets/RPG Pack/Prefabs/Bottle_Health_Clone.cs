using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Bottle_Health_Clone : MonoBehaviour //ü�º� Ŭ�� ����
{
    public bool isDestroy;
    public int spawnProbability;
    public static Vector3 zombiePosition;
    Enemy enemy;

    IEnumerator WaitForSpawn()
    {
        yield return new WaitUntil(() => isDestroy);

        int a = Random.Range(0, 101);
        spawnProbability = 15;
        if (a <= spawnProbability)
        {
            // Enemy�� �ı��ư�, ���� Ȯ���� ������� �� ����ü�� ����
            GameObject enemyObject = GameObject.FindGameObjectWithTag("Zombie");
            enemy = enemyObject.GetComponent<Enemy>();
            zombiePosition.y = 0f;
            GameObject clone = Instantiate(enemy.bottlePrefab, zombiePosition, Quaternion.identity);
            gameObject.GetComponent<Renderer>().enabled = true;
            clone.SetActive(true); // Ȱ��ȭ
            isDestroy = false;
            clone.tag = "Health";
        }
    }

    private void Start()
    {
        StartCoroutine(WaitForSpawn()); //isDestroy�� true�� �ɶ����� ��ٸ���.
    }
}