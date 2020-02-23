using System.Collections;
using System.Collections.Generic;
using Fight.World;
using UnityEngine;

public class ShopManager : MonoBehaviour, IWorldStateListener
{
    public static bool ShopIsOpened = false;
    public GameObject UI_Shop;
    public GameObject ShopButton;
    public GameObject UiShade;

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
        UiShade.SetActive(true);
    }

    public void ShopClose()
    {
        UI_Shop.SetActive(false);
        ShopButton.SetActive(true);
        UiShade.SetActive(false);
    }

    public void OnWorldStateChanged(WorldState state)
    {
        var active = state == WorldState.Day;
        ShopButton.SetActive(active);
        if (state == WorldState.Night)
        {
            UI_Shop.SetActive(false);
        }
    }
}
