using TMPro;
using UnityEngine;

public class Customers : MonoBehaviour
{
     public string RequestedItem = "Apple";
     public int RequestedAmount = 3;

    public int RewardMoney = 10;

    private bool Fulfilled = false;

    public TMP_Text RequestText;

    private void Start()
    {
        string[] PossibleItem = { "Apple", "Carrot"};
        RequestedItem = PossibleItem[UnityEngine.Random.Range(0, PossibleItem.Length)];
        RequestedAmount = Random.Range(2, 6);

        RequestText.text = $"{RequestedAmount} x {RequestedItem}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Fulfilled) return;

        if (other.CompareTag("Player"))
        {
            Player_Inventory_System inventory = other.GetComponent<Player_Inventory_System>();
            if (inventory != null && inventory.RemoveItem(RequestedItem, RequestedAmount))
            {
                Fulfilled = true;
                inventory.AddMoney(RewardMoney);

                FindFirstObjectByType<Customer_Manager>()?.CustomerLeft();
            }
            else
            {
                Debug.Log("Not enough items to fulfill request.");
            }
        }
    }
}
