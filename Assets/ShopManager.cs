using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static bool ShopIsOpened = false;
    public GameObject UI_Shop;
    public GameObject ShopButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ShopOpen()
    {
        UI_Shop.SetActive(true);
        ShopButton.SetActive(false);
    }

    public void ShopClose()
    {
        UI_Shop.SetActive(false);
        ShopButton.SetActive(true);
    }
}
