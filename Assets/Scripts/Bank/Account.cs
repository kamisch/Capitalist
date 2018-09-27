using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TransactionTypes {
	Withdraw,
	Deposit
}

// Immutable
class AccountLedgerEntry : MonoBehaviour{

	public TransactionTypes transactionType { get; }
	public decimal transactionAmount { get; }
	public decimal balance { get; }


 	public AccountLedgerEntry(TransactionTypes transactionType,
    	decimal transactionAmmount, decimal balance) {
    	this.transactionType = transactionType;
    	this.transactionAmount = transactionAmount;
    	this.balance = balance;
	}

}

public class Account : MonoBehaviour{

	private List<AccountLedgerEntry> entries;
    
	public Account(decimal startingAmount) {
        Debug.Log(startingAmount.ToString());
    	this.entries = new List<AccountLedgerEntry>();
    	AccountLedgerEntry initialEntry = new AccountLedgerEntry(
        	TransactionTypes.Deposit,
        	startingAmount,
        	startingAmount
    	);
    	this.entries.Add(initialEntry);
	}

	public decimal getBalance() {
    	// Get the last entry in the book
    	return this.entries[this.entries.Count - 1].balance;
	}

	public decimal deposit(decimal amount) {
    	if (amount < 0) {
        	throw new ArgumentOutOfRangeException("Amount cannot be negative");
    	}

    	decimal newBalance = this.getBalance() + amount;

    	AccountLedgerEntry entry = new AccountLedgerEntry(
        	TransactionTypes.Deposit,
        	amount,
        	newBalance
    	);

    	this.entries.Add(entry);

    	return newBalance;
	}

	public decimal withdraw(decimal amount) {
    	if (amount < 0) {
        	throw new ArgumentOutOfRangeException("Amount cannot be negative");
    	}

    	decimal newBalance = this.getBalance() - amount;

    	if (newBalance < 0) {
        	throw new ArgumentException("Withdrawal will cause account balance to be negative");
    	}

    	AccountLedgerEntry entry = new AccountLedgerEntry(
        	TransactionTypes.Withdraw,
        	amount,
        	newBalance
    	);

    	this.entries.Add(entry);

    	return newBalance;
	}

}
