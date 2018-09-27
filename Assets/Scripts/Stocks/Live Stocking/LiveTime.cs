using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class LiveTime : MonoBehaviour {

	// Use this for initialization
	int tick;
	StockInitialiser lists;
	
	void Start () 
	{
		tick=0;
		lists = GameObject.Find("StockList").GetComponent<StockInitialiser>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		tick++;
		if (tick>=360)
		{
			for (int i=0;i<11;i++)
			{
				int buy=buying(lists.getReader(i).getWeight(),lists.getReader(i).GetPrice(),
				lists.getReader(i).dayBeforePrice(),lists.getReader(i).thirtyDayAverage(),
				lists.getReader(i).weekHigh(),lists.getReader(i).weekLow());
				int sell=selling(lists.getReader(i).getWeight(),lists.getReader(i).GetPrice(),
				lists.getReader(i).dayBeforePrice(),lists.getReader(i).thirtyDayAverage(),
				lists.getReader(i).weekHigh(),lists.getReader(i).weekLow());

				double priceChange=5*Math.Pow(Math.Sqrt(buy-sell),3);

				lists.getReader(i).SetPrice((double)priceChange);
				
			}
			tick=0;
		}
		//if (tick
	}

	public int buying(double weight, double price, double originalPrice, double thirtyDayAvg,
		double high, double low)
	{
		System.Random randomNumber=new System.Random();
		double ran=randomNumber.NextDouble()*.9+.2;
		if (price*(double).98>high)
		{
			high=(double).8;
			low=1;
		}else if (price*(double).03<low)
		{
			low=(double)1.2;
			high=1;
		}
		return (int)((double)weight*(price-originalPrice)*(double)thirtyDayAvg*high*low*(double)ran);
	}

	public int selling(double weight, double price, double originalPrice, double thirtyDayAvg,
		double high, double low)
	{
		System.Random randomNumber=new System.Random();
		double ran=randomNumber.NextDouble()*.9+.2;
		if (price*(double).98>high)
		{
			high=(double)1.2;
			low=1;
		} else if (price*(double).03<low)
		{
			low=(double).8;
			high=1;
		}
		return (int)((double)weight*(originalPrice-price)*(double)thirtyDayAvg*high*low*(double)ran);
	}
}
