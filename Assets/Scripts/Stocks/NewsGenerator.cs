using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class NewsGenerator : MonoBehaviour {
	System.Random randomGenerator = null;
	StockInitialiser stockInitialiser;
	String news;

	public NewsGenerator() {
        randomGenerator = new System.Random();
	}

	// Use this for initialization
	void Start () {
		stockInitialiser = GameObject.Find("StockList").GetComponent<StockInitialiser>();
		System.Console.WriteLine(stockInitialiser);
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public String QuarterlyReports(String stockName) {
		double percentage = randomGenerator.Next(-70,201);

        news = stockName + " quarterly profits went up " + percentage + "%";
		return news;
	}

	public String getNews()
	{
		return news;
	}

	private void PerturbAllStocks(double amount) {
		// Loop through all stocks
		for (int i = 0; i < stockInitialiser.stockList.Length; i++) 
		{
			StockReader stock = stockInitialiser.stockList[i];

			double percentage = 0;

            // fluctuate by ±amount * 0.4 ± skew
			if (Math.Abs(amount) < 30) {
                double skew = randomGenerator.NextDouble() * 2;
                skew *= randomGenerator.NextDouble() < 0.5 ? 1 : -1;
                double fluctuation = fluctuation = randomGenerator.NextDouble() * (amount * 0.4 + skew);
                fluctuation *= randomGenerator.NextDouble() < 0.5 ? 1 : -1;
                percentage = amount + fluctuation;
            }
            // fluctuate by ±amount * 0.3 ± skew
			else {
                double skew = randomGenerator.NextDouble() * 2;
                skew *= randomGenerator.NextDouble() < 0.5 ? 1 : -1;
                double fluctuation = fluctuation = randomGenerator.NextDouble() * (amount * 0.3 + skew);
                fluctuation *= randomGenerator.NextDouble() < 0.5 ? 1 : -1;
                percentage = amount + fluctuation;
            }

			// 3% of the time, the company will be hit very hard
			// |x| = |x| ± 10.0 
			if (randomGenerator.NextDouble() < 0.03) {
				percentage += Math.Sign(percentage) * randomGenerator.NextDouble() * 10.0;
			}
			StockReader lists = GameObject.Find("StockList").GetComponent<StockReader>();
			double weight=System.Math.Sqrt(percentage);
			lists.setWeight(weight);
			lists.setPercentage(percentage);
		}

	}


    public string NewGenerator()
    {
        int ocurrence = randomGenerator.Next(0, 101);
        if (ocurrence == 0)
        {
            news = "Mass internet outage across the world!";
            PerturbAllStocks(-10);
        }
        else if (ocurrence < 5)
        {
            news = "Worldwide Stocks of Graphic Cards are High on Demand";
            StockReader stock = FindStockByName("Aividin");
            changePrice(stock, 10);
        } else if (ocurrence >=5 & ocurrence <= 10)
        {
            news = "Cryptocurrency Miners Raises Graphic Cards Prices";
            StockReader stock = FindStockByName("Dorf");
            changePrice(stock, 12);
        } else if (ocurrence >= 11 && ocurrence <= 15)
        {
            news = "Wendy’s, Found to Contain Salmonella in their Burgers by the CDC";
            StockReader stock = FindStockByName("Sendeys");
            changePrice(stock, -5);
        } else if (ocurrence >= 16 && ocurrence <= 20)
        {
            news = "Man Wins the Ultimate Lotto, Worth $3.1 Billion";
            StockReader stock = FindStockByName("NmazoA");
            changePrice(stock, 3);
        } else if (ocurrence == 21)
        {
            news = "ISIS Leader, Not Seen in Months; Presumed Dead by the Coalition";
            PerturbAllStocks(-20);
        } else if (ocurrence == 22)
        {
            news = "It Has Returned";
            PerturbAllStocks(9);
        } else if (ocurrence >= 23 && ocurrence <30)
        {
            news = "Astronomers Believe that We Are Not Alone";
            StockReader stock = FindStockByName("Oonsantm");
            changePrice(stock, 6);
        } else if (ocurrence >= 31 && ocurrence <= 40)
        {
            news = "Guardians of the Galaxy 2 Has Grossed Over $883 Million";
            StockReader stock = FindStockByName("OellsFargw");
            changePrice(stock, 2);
        } else if (ocurrence >= 41 && ocurrence <= 50)
        {
            news = "Bahrain Asks Gulf Allies for Aid to Stave Off Crisis";
            StockReader stock = FindStockByName("NamecoCorporationc");
            changePrice(stock, -3);
        } else if (ocurrence >= 51 && ocurrence <= 55)
        {
            news = "2 Patients, Found with Superbugs has Resisted All Conventional Medicine and Treatment";
            StockReader stock = FindStockByName("Geoinb");
            changePrice(stock, -10);
        } else if (ocurrence >= 56 && ocurrence <= 60)
        {
            news = "Seoul Kimchi Festival: Thousands Gather in South Korea's Capital to Make Food for Charity";
            StockReader stock = FindStockByName("Talmarw");
            changePrice(stock, 9);
        } else if (ocurrence >= 61 && ocurrence <= 70)
        {
            news = "Walmart Embarks on Worker’s Campaign; Engages Congress to Increase Federal Minimum Wage";
            StockReader stock = FindStockByName("Sendeys");
            changePrice(stock, 7);
        } else if (ocurrence == 71)
        {
            news = "Russia Denies Military Buildup on Ukraine Border; US Believes War is Imminent";
            PerturbAllStocks(100);
        } else if (ocurrence >= 72 && ocurrence <= 80)
        {
            news = "Bitcoin adds another $400 to its Price, a Day After Soaring Past $7,000";
            StockReader stock = FindStockByName("Dorf");
            changePrice(stock, -6);
        } else if (ocurrence >= 81 && ocurrence <=90)
        {
            news = "Wells Fargo Accounts Compromised in Wide-spread Security Hack Last Year";
            StockReader stock = FindStockByName("Aividin");
            changePrice(stock, -4);
        } else if (ocurrence >= 91 && ocurrence <= 100)
        {
            news = "Alt-Right White Supremacists Claim Papa John's as Official Pizza";
            StockReader stock = FindStockByName("NamecoCorporatioc");
            changePrice(stock, -7);
        } else if (ocurrence == 101)
        {
            news = "Pakistan Says It's Ready to Use Nuclear Weapons";
            PerturbAllStocks(-100);
        }
        return news;
    }
    

    private StockReader FindStockByName(string Name)
    {
        // Loop through all stocks
        // Not very efficient but we only have 11 elements, so it's ok
        for (int i = 0; i < stockInitialiser.stockList.Length; i++)
        {
            StockReader stock = stockInitialiser.stockList[i];
            if (stock.name == Name)
            {
                return stock;
            }
        }
        return null;
    }

        // TODO
    	private void changePrice(StockReader stock, double amount) {
        double percentage = 0;

        // fluctuate by ±amount * 0.4 ± skew
        if (Math.Abs(amount) < 30)
        {
            double skew = randomGenerator.NextDouble() * 2;
            skew *= randomGenerator.NextDouble() < 0.5 ? 1 : -1;
            double fluctuation = fluctuation = randomGenerator.NextDouble() * (amount * 0.4 + skew);
            fluctuation *= randomGenerator.NextDouble() < 0.5 ? 1 : -1;
            percentage = amount + fluctuation;
        }
        // fluctuate by ±amount * 0.3 ± skew
        else
        {
            double skew = randomGenerator.NextDouble() * 2;
            skew *= randomGenerator.NextDouble() < 0.5 ? 1 : -1;
            double fluctuation = fluctuation = randomGenerator.NextDouble() * (amount * 0.3 + skew);
            fluctuation *= randomGenerator.NextDouble() < 0.5 ? 1 : -1;
            percentage = amount + fluctuation;
        }

        // Update weight and percentage
        StockReader lists = GameObject.Find("StockList").GetComponent<StockReader>();
        double weight = System.Math.Sqrt(percentage);
        lists.setWeight(weight);
        lists.setPercentage(percentage);
    }

}
