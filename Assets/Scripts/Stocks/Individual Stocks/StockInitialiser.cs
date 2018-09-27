using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StockInitialiser : MonoBehaviour {
    public StockReader[] stockList;

    public GameObject[] stocks;

    StockReader currentMidStock;
    StockReader currentLeftStock;
    StockReader currentRightStock;


    public StockReader currentStock;


    public GameObject leftCam;
    public GameObject rightCam;
    public GameObject midCam;

    public GameObject currentPriceText;

    // Use this for initialization
    void Start () {
		stocks = new GameObject[] {
			GameObject.Find("Stock"),
			GameObject.Find("Stock (1)"),
			GameObject.Find("Stock (2)"),
			GameObject.Find("Stock (3)"),
			GameObject.Find("Stock (4)"),
			GameObject.Find("Stock (5)"),
			GameObject.Find("Stock (6)"),
			GameObject.Find("Stock (7)"),
			GameObject.Find("Stock (8)"),
			GameObject.Find("Stock (9)"),
			GameObject.Find("Stock (10)"),
		};

        for (int i = 0; i < stockList.Length; i++)
        {
            stockList[i] = stocks[i].GetComponent<StockReader>();
       }
        
        /*
		stockList.Add(new StockReader("AVDN","Aividin",(decimal)(208.69 * (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1,new System.Random().NextDouble()*(1.06 -.95) + .95, 0));
		stockList.Add( new StockReader("DRF","Dorf",(decimal)(12.36 * (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1,new System.Random().NextDouble()*(1.06 -.95) + .95, 0));
        stockList.Add(new StockReader("GENB", "Goeinb", (decimal)(261.75* (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1, new System.Random().NextDouble() * (1.06 - .95) + .95, 0));
        stockList.Add( new StockReader("NMCO", "NamecoCorporatioc", (decimal)(8.48 * (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1, new System.Random().NextDouble() * (1.06 - .95) + .95, 0));
        stockList.Add(new StockReader("NMZA", "NmazoA", (decimal)(1111.6 * (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1, new System.Random().NextDouble() * (1.06 - .95) + .95, 0));
        stockList.Add( new StockReader("OSFW", "OellsFargw", (decimal)(56.35 * (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1, new System.Random().NextDouble() * (1.06 - .95) + .95, 0));
        stockList.Add(new StockReader("OSNM", "Oonsantm", (decimal)(119.87 * (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1, new System.Random().NextDouble() * (1.06 - .95) + .95, 0));
        stockList.Add( new StockReader("PNAS", "Panas", (decimal)(91.6 * (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1, new System.Random().NextDouble() * (1.06 - .95) + .95, 0));
        stockList.Add(new StockReader("SDYW", "Sendeyw", (decimal)(15.02 * (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1, new System.Random().NextDouble() * (1.06 - .95) + .95, 0));
        stockList.Add( new StockReader("SlPE", "SppliedOptpelectronica", (decimal)(37.82 * (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1, new System.Random().NextDouble() * (1.06 - .95) + .95, 0));
        stockList.Add(new StockReader("TLMR", "Talmarw", (decimal)(89.68 * (new System.Random().NextDouble() * (1.06 - .95) + .95)),
            1, new System.Random().NextDouble() * (1.06 - .95) + .95, 0));
            */
   
     

        currentPriceText = GameObject.Find("Current Price");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setReader(StockReader stocks, int i)
	{
		stockList[i]=stocks;
	}

	public StockReader getReader(int i)
	{
		return stockList[i];
	}
    
    public void getCurrent()
    {
        if (stockList[1] == null)
        {
            Debug.Log("this shit is fucking null");
        } else
        {
            Debug.Log("is not null");
            Debug.Log(stockList[1].GetComponent<StockReader>().getInitialPrice().ToString());
        }
       if (leftCam.active == true)
        {
            currentLeftStock = stockList[0];
            currentMidStock = stockList[1];
            currentRightStock = stockList[2];
        } else if (midCam.active == true)
        {
            currentLeftStock = stockList[3];
            currentMidStock = stockList[4];
            currentRightStock = stockList[5];
        } else if (rightCam.active == true)
        {
            currentLeftStock = stockList[6];
            currentMidStock = stockList[7];
            currentRightStock = stockList[9];
        }
    }

    public void stock1()
    {
        if (currentLeftStock == null)
        {
            Debug.Log("not nool");
        }
        currentStock = currentLeftStock;
        //currentPriceText.GetComponent<Text>().text = "Current price: "; //+ 500.ToString();//currentStock.GetPrice().ToString();
    }

    public void stock2()
    {
        currentStock = currentMidStock;
       // currentPriceText.GetComponent<Text>().text = " Current price: " + currentStock.GetPrice().ToString();


    }

    public void stock3()
    {
        currentStock = currentRightStock;
        //currentPriceText.GetComponent<Text>().text = " Current priceL " + currentStock.GetPrice().ToString();

    }


   
}