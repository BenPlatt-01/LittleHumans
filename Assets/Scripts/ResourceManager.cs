using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{

    public int wood;
    public int blood;
    public int crystal;
    public int sacrificeGoal;
    public int numberOfWorkersSacrificed;

    public TMP_Text woodDisplay;
    public TMP_Text bloodDisplay;
    public TMP_Text crystalDisplay;
    public TMP_Text sacrificiedText;

    public static ResourceManager instance;

    
    public void Awake()
    { 
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addResource(string resourceType, int amount)
    {
        if (resourceType == "wood")
        {
            wood += amount;
            woodDisplay.text = wood.ToString();
        }
        if (resourceType == "blood")
        {
            blood += amount;
            bloodDisplay.text = blood.ToString();
        }
        if (resourceType == "crystal")
        {
            crystal += amount;
            crystalDisplay.text = crystal.ToString();
        }
    }

    public void AddSacrificiedWorker() 
    {
        numberOfWorkersSacrificed++;
        sacrificiedText.text = numberOfWorkersSacrificed + " / " + sacrificeGoal;

        if (numberOfWorkersSacrificed >= sacrificeGoal) 
        {
            print("YOU HAVE WON!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }

}
