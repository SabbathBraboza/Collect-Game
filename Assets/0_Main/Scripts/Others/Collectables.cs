using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private string itemName;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Inventory_System inventory_System = collision.GetComponent<Player_Inventory_System>();
            if (inventory_System != null && inventory_System.AddItem(itemName, 1))
            {
                Destroy(gameObject);
            }
        }
    }
}
