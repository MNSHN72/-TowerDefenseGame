using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCountScript : MonoBehaviour
{
    [SerializeField] private Bank bank;
    private TMP_Text goldCountText;

    private void start()
    {
        goldCountText = this.gameObject.GetComponent<TMP_Text>();
    }
    private void Update()
    {
        Debug.Log(goldCountText);
        UpdateGoldCount();
    }

    private void UpdateGoldCount()
    {
        if (bank == null)
        {
            return;
        }
        goldCountText.text = $"Gold : {bank.CurrentBalance}";
    }
}
