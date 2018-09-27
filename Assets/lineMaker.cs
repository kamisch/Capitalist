using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineMaker : MonoBehaviour 
{
	// Use this for initialization
	
	void Start () 
	{
		double[] x=new double[7];
		decimal[] stockPriceHistory;
		// StockReader things = GameObject.Find("StockList").GetComponent<StockReader>();
		StockReader[] things = GameObject.Find("StockList").GetComponent<StockInitialiser>().stockList;
		LineRenderer liners=GameObject.Find("LineGrapher").GetComponent(typeof(LineRenderer)) as LineRenderer;
		LineRenderer liners1=GameObject.Find("LineGrapher (1)").GetComponent(typeof(LineRenderer)) as LineRenderer;
		LineRenderer liners2=GameObject.Find("LineGrapher (2)").GetComponent(typeof(LineRenderer)) as LineRenderer;
		LineRenderer liners3=GameObject.Find("LineGrapher (3)").GetComponent(typeof(LineRenderer)) as LineRenderer;
		LineRenderer liners4=GameObject.Find("LineGrapher (4)").GetComponent(typeof(LineRenderer)) as LineRenderer;
		LineRenderer liners5=GameObject.Find("LineGrapher (5)").GetComponent(typeof(LineRenderer)) as LineRenderer;
		// TODO read from specified stock
		decimal[] doubleArray = System.Array.ConvertAll(things[0].getHistory(), y => (decimal)y);
		stockPriceHistory=doubleArray;
        if (stockPriceHistory.Length - 7 >= 0)
        {
			int j = 0;
            for (int i = stockPriceHistory.Length - 7; i < stockPriceHistory.Length; i++)
            {
                x[j] = (double)stockPriceHistory[i];
				j++;
            }
        }
		else {
			for (int i = 0; i < 7; i++) {
				x[i] = 0;
			}
			int j = 6;
            for (int i = stockPriceHistory.Length - 1; i > 0; i--) {
                x[j] = (double)stockPriceHistory[i];
				j--;
            }
		}
		int minX=0;
		int maxX=0;
		for (int i=0;i<7;i++)
		{
			if (maxX<x[i])
			{
				maxX=(int)x[i];
			} else if  (minX>x[i])
			{
				minX=(int)x[i];
			}
		}
			int k=0;
			if (maxX-minX<1)
			{
				k=1;
			} else
			{
				k=maxX-minX;
			}
		int domain=142;
		int range=140/(k);
		Vector3 one=new Vector3(domain, (float)(x[0]*range),7);
		Vector3 two=new Vector3(domain*2, (float)(x[1]*range),7);
		Vector3 three=new Vector3(domain*3, (float)(x[2]*range),7);
		Vector3 four=new Vector3(domain*4, (float)(x[3]*range),7);
		Vector3 five=new Vector3(domain*5, (float)(x[4]*range),7);
		Vector3 six=new Vector3(domain*6, (float)(x[5]*range),7);
		Vector3 seven=new Vector3(domain*7, (float)(x[6]*range),7);
		liners.SetPosition(0,one);
		liners.SetPosition(1,two);
		liners1.SetPosition(0,two);
		liners1.SetPosition(1,three);
		liners2.SetPosition(0,three);
		liners2.SetPosition(1,four);
		liners3.SetPosition(0,four);
		liners3.SetPosition(1,five);
		liners4.SetPosition(0,five);
		liners4.SetPosition(1,six);
		liners5.SetPosition(0,six);
		liners5.SetPosition(1,seven);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void doo()
	{
		double[] x=new double[7];
		decimal[] stockPriceHistory;
		// StockReader things = GameObject.Find("StockList").GetComponent<StockReader>();
		StockReader[] things = GameObject.Find("StockList").GetComponent<StockInitialiser>().stockList;
		LineRenderer liners=GameObject.Find("LineGrapher").GetComponent(typeof(LineRenderer)) as LineRenderer;
		LineRenderer liners1=GameObject.Find("LineGrapher (1)").GetComponent(typeof(LineRenderer)) as LineRenderer;
		LineRenderer liners2=GameObject.Find("LineGrapher (2)").GetComponent(typeof(LineRenderer)) as LineRenderer;
		LineRenderer liners3=GameObject.Find("LineGrapher (3)").GetComponent(typeof(LineRenderer)) as LineRenderer;
		LineRenderer liners4=GameObject.Find("LineGrapher (4)").GetComponent(typeof(LineRenderer)) as LineRenderer;
		LineRenderer liners5=GameObject.Find("LineGrapher (5)").GetComponent(typeof(LineRenderer)) as LineRenderer;
		// stockPriceHistory=things.getHistory();
		// TODO
		decimal[] doubleArray = System.Array.ConvertAll(things[0].getHistory(), y => (decimal)y);
		stockPriceHistory=doubleArray;
		for (int i=stockPriceHistory.Length-7;i<stockPriceHistory.Length;i++)
		{
			x[i]=(double)stockPriceHistory[i];
		}
		int minX=0;
		int maxX=0;
		for (int i=0;i<7;i++)
		{
			if (maxX<x[i])
			{
				maxX=(int)x[i];
			} else if  (minX>x[i])
			{
				minX=(int)x[i];
			}
		int domain=142;
		int range=140/(maxX-minX);
		Vector3 one=new Vector3(domain, (float)(x[0]*range),7);
		Vector3 two=new Vector3(domain*2, (float)(x[1]*range),7);
		Vector3 three=new Vector3(domain*3, (float)(x[2]*range),7);
		Vector3 four=new Vector3(domain*4, (float)(x[3]*range),7);
		Vector3 five=new Vector3(domain*5, (float)(x[4]*range),7);
		Vector3 six=new Vector3(domain*6, (float)(x[5]*range),7);
		Vector3 seven=new Vector3(domain*7, (float)(x[6]*range),7);
		liners.SetPosition(0,one);
		liners.SetPosition(1,two);
		liners1.SetPosition(0,two);
		liners1.SetPosition(1,three);
		liners2.SetPosition(0,three);
		liners2.SetPosition(1,four);
		liners3.SetPosition(0,four);
		liners3.SetPosition(1,five);
		liners4.SetPosition(0,five);
		liners4.SetPosition(1,six);
		liners5.SetPosition(0,six);
		liners5.SetPosition(1,seven);
		}
	}
}
