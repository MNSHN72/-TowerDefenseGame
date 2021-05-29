using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int goldCost = 25;
    private Bank bank;

    public bool InstantiateTower(Tower towerPrefab, Vector3 position)
    {
        bank = FindObjectOfType<Bank>();
        bool successfullyPlaced = false;
        if (bank == null) 
        {
            return false;
        }
        if (bank.CurrentBalance >= goldCost)
        {
            bank.Withdraw(goldCost);
            Instantiate(towerPrefab, position, Quaternion.identity);
            successfullyPlaced = true;
        }
        return successfullyPlaced;
    }
}
