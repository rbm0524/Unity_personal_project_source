using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle_Health : MonoBehaviour //�� ������ �𸣰����� prefab�� inspector���� �Ҵ��ϴ� ���� �Ұ� �׷��� Resources.load�� �ذ�
{

    public enum Type {Health }; //������Ʈ �� Coin�̳� �ٸ� ������ �߰��ؼ� ������Ʈ �����ϰ�, Ÿ�� ����
    public Type type;
    public int value; //������ �ĺ���, �ٸ� �������� �߰��� ��� value�� �ٸ��� ����
}
