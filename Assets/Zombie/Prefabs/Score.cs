using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Text ������Ʈ ������ ���� public ����

    // Text ������Ʈ�� �ʱⰪ ������ ���� Start �Լ�
    void Start()
    {
        scoreText.text = "Score: " + Enemy.score.ToString(); // Enemy ��ũ��Ʈ�� static ������ score�� �����ͼ� Text�� �ݿ�
    }

    // Enemy ��ũ��Ʈ�� static ������ score ����� Text ������Ʈ�� ������Ʈ �ǵ��� Update �Լ����� ȣ��
    void Update()
    {
        scoreText.text = "Score: " + Enemy.score.ToString(); // Enemy ��ũ��Ʈ�� static ������ score�� �����ͼ� Text�� �ݿ�
    }
}



