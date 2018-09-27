using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStock : MonoBehaviour {

    public GameObject leftCam;
    public GameObject rightCam;
    public GameObject midCam;

    public GameObject stockUI;

    Vector3 playerPostion;

    StockInitialiser stocks;
	// Use this for initialization
	void Start () {
        stockUI.SetActive(false);
        stocks = GameObject.Find("StockList").GetComponent<StockInitialiser>();
    }

    // Update is called once per frame
    void Update () {
       
	}
    private void OnTriggerEnter(Collider other)
    {
        stocks.getCurrent();

        try
        {
        other.gameObject.SetActive(false);

        playerPostion = new Vector3 (other.transform.position.x, other.transform.position.y, other.transform.position.z -2);
        stockUI.SetActive(true);
        midCam.SetActive(true);
       
        other.transform.position = playerPostion;
        } catch (System.NullReferenceException e)
        {

        }
    }

}
