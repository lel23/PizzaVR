using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject allPizzaRecipients;

    public List<GameObject> pizzaRecipients;
    private Dictionary<GameObject, bool> pizzasDelivered;
    void Awake()
    {
        for (int i = 0; i < allPizzaRecipients.transform.childCount; i++)
        {
            pizzaRecipients.Add(allPizzaRecipients.transform.GetChild(i).gameObject);
        }
        // initialize an ordered dictionary that stores all data about pizzas delivered
        pizzasDelivered = new Dictionary<GameObject, bool>();
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
        Debug.Log("method called");
        Debug.Log(pizzaRecipients[0].transform.position);
        return pizzaRecipients[0].transform.position;
    }

    public void getPizza(GameObject recipient)
    {
        pizzasDelivered[recipient] = true;
        pizzaRecipients.Remove(recipient);
    }
}
