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
        resourceArray = Resources.LoadAll<GameObject>("items"); //Resources의 하위 디렉토리인 items 디렉토리의 prefab들을 모두 로드한다. 코인을 넣은 이유는 아이템이 2개 이상 존재할 때 랜덤하게 생성되는 것을 보여주기 위해
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
        int randomIndex = Random.Range(0, resourceArray.Length); // 무작위로 인덱스 선택
        Debug.Log(randomIndex);
        Vector3 spawnPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        Instantiate(resourceArray[randomIndex], spawnPosition, Quaternion.identity); // 선택된 프리팹 인스턴스화
    }
}