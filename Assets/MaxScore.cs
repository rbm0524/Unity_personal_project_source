using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxScore : MonoBehaviour
{
    public TextMeshProUGUI maxscoreText; // Text ������Ʈ ������ ���� public ����
    // Start is called before the first frame update
    void Start()
    {
        maxscoreText.text = "Max Score : " + PlayerPrefs.GetInt("MaxScore").ToString(); // Enemy ��ũ��Ʈ�� static ������ score�� �����ͼ� Text�� �ݿ�
    }

    // Enemy ��ũ��Ʈ�� static ������ score ����� Text ������Ʈ�� ������Ʈ �ǵ��� Update �Լ����� ȣ��
    void Update()
    {
        maxscoreText.text = "Max Score : " + PlayerPrefs.GetInt("MaxScore").ToString(); // Enemy ��ũ��Ʈ�� static ������ score�� �����ͼ� Text�� �ݿ�
    }
}
