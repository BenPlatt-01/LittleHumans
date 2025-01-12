using UnityEngine;

public class Resource : MonoBehaviour
{

    public string resourceType;
    public int resourceAmount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resourceAmount <= 0) 
        {
            Destroy(gameObject);
        }
        
    }
}
