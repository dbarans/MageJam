using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] private entry entry1;
    [SerializeField] private entry entry2;
    [SerializeField] private entry entry3;
    [SerializeField] private gameManager gameManager;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Items items;
    [SerializeField] private SoundManager soundManager;
    private float value;

   
    private void Update()
    {
        UpdateEntry();
        value = entry1.quantity * entry1.price + entry2.quantity * entry2.price + entry3.quantity * entry3.price;
        valueText.text = "Total: " + value.ToString("0.00") + "$";
        moneyText.text = "Money: " + gameManager.money.ToString("0.00") + "$";

    }
    public void UpdateEntry()
    {
        if (entry1.quantity <= 0)
        {
            entry1.gameObject.SetActive(false);
        }
        else
        {
            entry1.gameObject.SetActive(true);
        }
        if (entry2.quantity <= 0)
        {
            entry2.gameObject.SetActive(false);
        }
        else
        {
            entry2.gameObject.SetActive(true);
        }
        if (entry3.quantity <= 0)
        {
            entry3.gameObject.SetActive(false);
        }
        else
        {
            entry3.gameObject.SetActive(true);
        }
    }
    
    public void Buy()
    {
        
        
        if (gameManager.money >= value)
        {
            soundManager.PlayCashRegisterSound();
            gameManager.money -= value;
            items.itemQuantities[1] += entry1.quantity;
            items.itemQuantities[2] += entry2.quantity;
            items.itemQuantities[3] += entry3.quantity;
            Debug.Log(items.itemQuantities[1]);

            entry1.quantity = 0;
            entry2.quantity = 0;
            entry3.quantity = 0;

            
           
            


        }
       

    }
}
