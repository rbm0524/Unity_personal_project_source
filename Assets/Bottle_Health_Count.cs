using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bottle_Health_Count : MonoBehaviour
{
    public TextMeshProUGUI HealthCount; // Text ������Ʈ ������ ���� public ����
    public Player player; // Player ��ũ��Ʈ�� ����ϱ� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        HealthCount.text = player.count.ToString(); // Enemy ��ũ��Ʈ�� static ������ score�� �����ͼ� Text�� �ݿ�
    }

    // Update is called once per frame
    void Update()
    {
        HealthCount.text = player.count.ToString(); // Enemy ��ũ��Ʈ�� static ������ score�� �����ͼ� Text�� �ݿ�
    }
}