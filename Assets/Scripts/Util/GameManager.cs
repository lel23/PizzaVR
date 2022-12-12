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

    // this gets set by the VRManager script
    public bool isVR;
    void OnEnable()
    {
        for (int i = 0; i < allPizzaRecipients.transform.childCount; i++)
        {
            pizzaRecipients.Add(allPizzaRecipients.transform.GetChild(i).gameObject);
        }
        // initialize an ordered dictionary that stores all data about pizzas delivered
        pizzasDelivered = new Dictionary<GameObject, bool>();
        foreach (GameObject pizzaRecipient in pizzaRecipients)
        {
            pizzasDelivered[pizzaRecipient] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getNextPizzaRecipientPosition()
    {
        return pizzaRecipients[0].transform.position;
    }

    public void getPizza(GameObject recipient)
    {
        pizzasDelivered[recipient] = true;
        pizzaRecipients.Remove(recipient);
    }

    // returns True if the recipient has not been delivered to yet, false otherwise
    public bool isValidRecipient(GameObject recipient)
    {
        Debug.Log(!pizzasDelivered[recipient]);
        return !pizzasDelivered[recipient];
    }
}
