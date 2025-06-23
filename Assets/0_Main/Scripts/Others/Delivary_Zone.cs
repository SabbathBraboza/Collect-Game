using UnityEngine;

public class Delivary_Zone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Inventory_System inventory = other.GetComponent<Player_Inventory_System>();
            Customers customers = FindFirstObjectByType<Customers>();

            if (customers != null && inventory != null)
            {
                bool success = inventory.RemoveItem(customers.RequestedItem, customers.RequestedAmount);
                if (success)
                {
                    inventory.AddMoney(customers.RewardMoney);
                    FindFirstObjectByType<Customer_Manager>()?.CustomerLeft();
                    Debug.Log("Delivered via Delivery Zone!");
                }
                else
                {
                    Debug.Log("Not enough items!");

                }
            }
        }
    }
}
