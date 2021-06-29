using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour
{
    public GameObject[] characterPrefabs;//����һ������Ԥ�������飬�洢�����ɫ
    private int selectedIndex = 0;//����ѡ�������ı���
    // Use this for initialization
    void Start()
    {
        //������ʾ�����ɫ�ķ���
        CharacterShow();
    }
    //���Ҳ���ʾ��Ӧ�������ɫ 
    void CharacterShow()
    {
        characterPrefabs[selectedIndex].SetActive(true);//��ʾ��Ӧ����������Ԥ����
        //ͨ��ѭ�����ز���Ӧ������Ԥ����
        for (int i = 0; i < 2; i++)
        {
            if (i != selectedIndex)
            {
                characterPrefabs[i].SetActive(false);//��δѡ��Ľ�ɫ����Ϊ����
            }
        }
    }
    //�����ǵ������һ����ť
    public void OnNextButtonClick()
    {
        selectedIndex++;
        selectedIndex %= 2;
        CharacterShow();
    }
    //�����ǵ������һ����ť
    public void OnPrevButtonClick()
    {
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = 2 - 1;
        }
        CharacterShow();
    }
}
