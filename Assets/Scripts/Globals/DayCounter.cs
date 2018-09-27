using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DayCounter {
	private static uint day = 0 ;
	private static uint hour = 15;
	private static uint minute = 30;

	private static uint tick=6000;
    public static PriceChanger price;
    public static NewsGenerator news;
	public static lineMaker lines;

    static void Start()
    {

        price = GameObject.Find("StockList").GetComponent<PriceChanger>();
		lines = GameObject.Find("Trends").GetComponent<lineMaker>();
        news = GameObject.Find("StockList").GetComponent<NewsGenerator>();
    }

	static void Update()
	{
		if (tick>=6000)
		{
			NextDay();
		}
	}

	public static uint GetDay() {
		return day;
	}

	public static uint GetHour() {
		return hour;
	}

	public static uint GetMinute() {
		return minute;
	}

	public static void NextDay() 
	{
        Debug.Log(day.ToString());
		price = GameObject.Find("StockList").GetComponent<PriceChanger>();
		day++;
		price.NewsPriceUpdate();
		for (int i=0;i<11;i++)
		{
			if (day%63==0)
			{
				price.QuarterlyPriceUpdate();
			}
		}
		lines.doo();
	}
	public static void resetTick()
	{
		tick=0;
	}
}
