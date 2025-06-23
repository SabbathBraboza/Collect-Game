using System.Collections;
using UnityEngine;

public class Customer_Manager : MonoBehaviour
{
    [SerializeField] private float MinDelay = 5f;
    [SerializeField] private float MaxDelay = 8f;

    [Space(3f)]
    [SerializeField] private GameObject CustomerPerfabs;
    public Transform customerSpawnPoint;

    private GameObject CurrentCustomer;

    private void Start() => StartCoroutine(SpawnCustomerLoop());

    private IEnumerator SpawnCustomerLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(MinDelay, MaxDelay));

            if(CurrentCustomer == null)
            {
                CurrentCustomer = Instantiate(CustomerPerfabs, customerSpawnPoint.position, Quaternion.identity);
            }
        }
    }

    public void CustomerLeft()
    {
        if (CurrentCustomer != null)
        {
            Destroy(CurrentCustomer);
            CurrentCustomer = null;
        }
    }
}
