using UnityEngine;

public class UpgradeMenuManager : MonoBehaviour
{

    public GameObject upgradeMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUpgrades()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseUpgrades()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
