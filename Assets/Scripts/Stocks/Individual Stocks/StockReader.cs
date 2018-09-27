using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StockReader : MonoBehaviour {

    private System.Random random;
    public string stockSymbol;
    public string stockName;
	private List<double> stockPriceHistory;
    private double currentPrice;
    public double number;
    public double weight;
    private double percentage;
    PersonalAccount account;
    public int amount;
    // Use this for initialization
    /*
    public StockReader ( string stockSymbol, string stockName, double number, double weight, int amount)
    {
        this.stockSymbol = stockSymbol;
        this.stockName = stockName;
        this.number = number;
        this.weight = weight;
        this.amount = amount;

    }
    */

	public void Start() {
		Debug.Log("stuff should be here right?");
        random = new System.Random();
		stockPriceHistory = new List<double>();
        Debug.Log("stockPriceHistory should be create now:");
        Debug.Log(stockPriceHistory);
        this.currentPrice = (double) (number * (random.NextDouble() * (1.06 - .95) + .95));
        this.percentage = (random.NextDouble() * (1.06 - .95) + .95);
        account = GameObject.Find("BankManager").GetComponent<PersonalAccount>();
        this.AddCurrentPriceToHistory(currentPrice);
        for (int i=0;i<30;i++)
        {
			stockPriceHistory.Add((double)(number *(random.NextDouble() * (1.06 - .95) + .95)));
            //Debug.Log(stockPriceHistory[i]);
        }
		
	}
  

    public void SetPrice(double price)
    {
        this.currentPrice = price;
    }

    
    public void AddCurrentPriceToHistory(double price)
    {
        double dec = random.NextDouble() * (1.06 - .95) + .95;
        stockPriceHistory.Add(currentPrice);
		/*
        for (int i = 1; i < 31; i++)
        {
            stockPriceHistory[i] = (double)dec * price;
        }
		*/
    }

    public double GetPrice()
    {
        return this.currentPrice;
    }

    public string GetStockSymbol()
    {
        return stockSymbol;
    }

    public double thirtyDayAverage()
    {
        double total = 0;
        double average = 0;
        if (stockPriceHistory.Count >= 30)
        {
            for (int i = stockPriceHistory.Count - 1; i > stockPriceHistory.Count - 30; i--)
            {
                total += stockPriceHistory[i];
                average = total / 30;
            }
        }
		else if (stockPriceHistory.Count < 30)
        {
            for (int j = 0; j < stockPriceHistory.Count; j++)
            {
                total += stockPriceHistory[j];
                average = total / j;
            }
        }
        return average;
    }

    public double getInitialPrice()
    {
        return stockPriceHistory[0];
    }

    public double thirtyDayHigh()
    {
        double high = 0;
        if (stockPriceHistory.Count >= 30)
        {
            for (int i = stockPriceHistory.Count - 1; i < stockPriceHistory.Count - 30; i--)
            {
                if (stockPriceHistory[i] > stockPriceHistory[i + 1])
                {
                    high = stockPriceHistory[i];
                }
            }
        }
        else if (stockPriceHistory.Count < 30)
        {
            for (int i = 0; i < stockPriceHistory.Count; i++)
            {
                if (stockPriceHistory[i] > stockPriceHistory[i + 1])
                {
                    high = stockPriceHistory[i];
                }
            }
        }
        return high;
    }

    public double thirtyDayLow()
    {
        double low = 0;
        if (stockPriceHistory.Count >= 30)
        {
            for (int i = stockPriceHistory.Count - 1; i < stockPriceHistory.Count - 30; i--)
            {
                if (stockPriceHistory[i] < stockPriceHistory[i + 1])
                {
                    low = stockPriceHistory[i];
                }
            }
        }
        else if (stockPriceHistory.Count < 30)
        {
            for (int i = 0; i < stockPriceHistory.Count; i++)
            {
                if (stockPriceHistory[i] < stockPriceHistory[i + 1])
                {
                    low = stockPriceHistory[i];
                }
            }
        }
        return low;
    }

    public double weekAverage()
    {
        double total = 0;
        double average = 0;
        if (stockPriceHistory.Count >= 7)
        {
            for (int i = stockPriceHistory.Count - 1; i > stockPriceHistory.Count - 7; i--)
            {
                total += stockPriceHistory[i];
                average = total / 7;
            }
        }
        else if (stockPriceHistory.Count < 7)
        {
            for (int j = 0; j < stockPriceHistory.Count; j++)
            {
                total += stockPriceHistory[j];
                average = total / j;
            }
        }
        return average;
    }


    public double weekHigh()
    {
        double high = 0;
        if (stockPriceHistory.Count >= 7)
        {
            for (int i = stockPriceHistory.Count - 1; i < stockPriceHistory.Count - 7; i--)
            {
                if (stockPriceHistory[i] > stockPriceHistory[i + 1])
                {
                    high = stockPriceHistory[i];
                }
            }
        }
        else if (stockPriceHistory.Count < 7)
        {
            for (int i = 0; i < stockPriceHistory.Count; i++)
            {
                if (stockPriceHistory[i] > stockPriceHistory[i + 1])
                {
                    high = stockPriceHistory[i];
                }
            }
        }
        return high;
    }

    public double weekLow() {
        double low = 0;
        if (stockPriceHistory.Count >= 7)
        {
            for (int i = stockPriceHistory.Count - 1; i < stockPriceHistory.Count - 7; i--)
            {
                if (stockPriceHistory[i] < stockPriceHistory[i + 1])
                {
                    low = stockPriceHistory[i];
                }
            }
        }
        else if (stockPriceHistory.Count < 7)
        {
            for (int i = 0; i < stockPriceHistory.Count; i++)
            {
                if (stockPriceHistory[i] < stockPriceHistory[i + 1])
                {
                    low = stockPriceHistory[i];
                }
            }
        }
        return low;
    }

    public double dayBeforePrice()
    {
        if (stockPriceHistory.Count==0)
        {
            return currentPrice;
        } else
        return stockPriceHistory[stockPriceHistory.Count - 1];
    }

    public void setWeight(double weight)
    {
        this.weight=weight;
    }

    public double getWeight()
    {
        return weight;
    }

    public void setPercentage(double percentage)
    {
        this.percentage=percentage;
    }

    public double getPercentage()
    {
        return percentage;
    }

    public void sellStock(int amount)
    {
        
        if (this.amount == 0)
        {
            // print("You don't have any stocks to sell");
        }
        else if (this.amount < amount)
        {
            // print("You do not have that many stocks to sell");
        }
        else if (amount < 0)
        {
            // print("You cannot sell negative stocks");
        }
        else 
        {
            this.amount -= amount;
            double insert = (amount * currentPrice) - 7;
			account.addMoneyToAccount((decimal) insert);
        }
        }


    public void buyStock(int amount)
    {
        double insert = amount * currentPrice;
        this.amount += amount;
		account.addMoneyStock((decimal) (insert + 7));
    }

	public double[] getHistory()
    {
		return stockPriceHistory.ToArray();
    }

}