using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CartBag : MonoBehaviour
{
    [SerializeField] private int Coin;

    public int GetSetCoin
    {
        get { return Coin;  } // ���������� �������� ��������
        
        set { Coin = value; }// ������������� ����� �������� ��������}
    }

    public UnityEvent ChengeAmountCoin;
    public void AddCoin(int coin)
    {
        Coin += coin;
        ChengeAmountCoin.Invoke();
    }

    public int GetAmountCoin()
    {
        return Coin;
    }
}
