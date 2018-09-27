using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceChanger : MonoBehaviour 
{
	NewsGenerator news;
	StockInitialiser lists;
	// Use this for initialization
	void Start () {
		news=new NewsGenerator();
		lists = GameObject.Find("StockList").GetComponent<StockInitialiser>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void QuarterlyPriceUpdate()
	{
		StockReader ares = GameObject.Find("StockList").GetComponent<StockReader>();
		for (int i=0;i<11;i++)
		{
			System.Random randomNumber=new System.Random();
			double percentage=randomNumber.NextDouble()*.6+.7;

			//news.QuarterlyReports(name);

			lists.getReader(i).SetPrice(lists.getReader(i).GetPrice()*(double)((ares.getPercentage()/35)*percentage));
		}
	}

    public void NewsPriceUpdate()
	{
		StockReader ares = GameObject.Find("StockList").GetComponent<StockReader>();
		for (int i=0;i<11;i++)
		{
			System.Random randomNumber=new System.Random();
			double percentage=randomNumber.NextDouble()*.4+.5;
//			lists.getReader(i).SetPrice((decimal)ares.getPercentage()*lists.getReader(i).GetPrice()*(decimal)percentage);
		}
	}
}