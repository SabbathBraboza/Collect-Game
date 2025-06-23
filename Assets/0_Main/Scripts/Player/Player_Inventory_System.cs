using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Inventory_System : MonoBehaviour
{
    [System.Serializable]
    public class ItemVisual
    {
        public string ItemName;
        public GameObject Perfab;
    }

    [Header("Inventory Settings:")]
    public int maxCarry = 7;
    public Transform carryPoint;

    [Header("Visual Prefabs:")]
    public List<ItemVisual> ItemVisuals;

    [Header("UI")]
    [SerializeField] private TMP_Text MoneyText;

    private Dictionary<string, GameObject> PrefabLookUp = new();
    private List<GameObject> CarriedVisuals = new();
    public Dictionary<string, int> Items = new();
    
    private int Money;

    private void Awake()
    {
        foreach (var item in ItemVisuals) 
        {
            if (!PrefabLookUp.ContainsKey(item.ItemName))
                PrefabLookUp.Add(item.ItemName, item.Perfab);
        }
    }

    public bool AddItem(string itemName, int Amount)
    {
        int CurrentTotal = 0;
        foreach (var count in Items.Values) CurrentTotal += count;

        if (CurrentTotal + Amount > maxCarry)
        {
            Debug.Log("Carry Limit Reached");
            return false;
        }

        if (!Items.ContainsKey(itemName)) Items[itemName] = 0;

        Items[itemName] += Amount;

        for (int i = 0; i < Amount; i++)
        {
            if(!PrefabLookUp.ContainsKey(itemName)) continue;

            GameObject Visual = Instantiate(PrefabLookUp[itemName],carryPoint);
            Visual.transform.localPosition = 0.5f * CarriedVisuals.Count * Vector3.up;
            CarriedVisuals.Add(Visual);
        }
        return true;
    }

    public bool RemoveItem(string itemName, int Amount)
    {
        if(!Items.ContainsKey(itemName) || Items[itemName]< Amount) return false;

        Items[itemName] -= Amount;

        for(int i = 0; i < Amount && CarriedVisuals.Count > 0; i++)
        {
            Destroy(CarriedVisuals[CarriedVisuals.Count -1]);
            CarriedVisuals.RemoveAt(CarriedVisuals.Count - 1);
        }
        return true;
    }

      public int GetTotalCarried() => CarriedVisuals.Count;

    public void AddMoney(int  Amount)
    {
        Money += Amount;
        MoneyText.text = $"Money : {Money}";
        Debug.Log($"Money: {Amount}");
    }
}
