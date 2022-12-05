using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> pizzaRecipients;
    private OrderedDictionary pizzasDelivered;
    void Start()
    {

        // initialize an ordered dictionary that stores all data about pizzas delivered
        pizzasDelivered = new OrderedDictionary();
        foreach (GameObject pizzaRecipient in pizzaRecipients)
        {
            pizzasDelivered.Add(pizzaRecipient, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getNextPizzaRecipientPosition()
    {
        
    }
}
