using UnityEngine;
using UnityEngine.UI;

public class ShopMenuManager : MonoBehaviour
{

    public GameObject shopMenu;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        shopMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseShop() 
    {
        shopMenu.SetActive(false);
        Time.timeScale = 1;
    }

}
