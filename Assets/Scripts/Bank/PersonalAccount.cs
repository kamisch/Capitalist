using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalAccount : MonoBehaviour {

    GameObject Balance;
    Account myAccount = new Account(5000);
	// Use this for initialization
	void Start () {
        Balance = GameObject.Find("amount");
        Debug.Log("money is " + myAccount.getBalance().ToString());
        
    }

    private void Update()
    {
        Balance.GetComponent<Text>().text = myAccount.getBalance().ToString();
    }

    public void addMoneyStock(decimal amount)
    {
        myAccount.withdraw(amount);
    }

    public void addMoneyToAccount(decimal amount)
    {
        myAccount.deposit(amount);
    }





  
}
