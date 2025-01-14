using UnityEngine;

public class Worker : MonoBehaviour
{

    bool isSelected;

    public LayerMask resourceLayer;
    public float collectDistance;
    Resource currentResource;

    public float timeBetweenCollect;
    float nextCollectTime;
    public int collectAmount;

    GameObject bloodAltar;

    public float distanceToAltar;

    public GameObject resourcePopUp;

    private AudioSource source;

    public GameObject deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        bloodAltar = GameObject.FindGameObjectWithTag("Altar");
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            mousePos.z = 0; 

            transform.position = mousePos; 
        }
        else 
        {
            if (Vector3.Distance(transform.position, bloodAltar.transform.position)<= distanceToAltar) 
            {
                Instantiate(deathSound);
                ResourceManager.instance.AddSacrificiedWorker();
                Destroy(gameObject);
            }

            Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
            if (col != null && currentResource == null) 
            { 
                currentResource = col.GetComponent<Resource>();

            }
            else
            {
                currentResource = null;
            }

            if (currentResource != null) 
            {
                if (Time.time > nextCollectTime) 
                {
                    GameObject popup = Instantiate(resourcePopUp, transform.position, Quaternion.identity, transform);
                    popup.transform.localPosition = new Vector3(0, 3, 0); // Adjust this value as needed

                    nextCollectTime = Time.time + timeBetweenCollect;
                    currentResource.resourceAmount -= collectAmount;

                    ResourceManager.instance.addResource(currentResource.resourceType, collectAmount);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        source.Play();
        isSelected = true;
    }

    private void OnMouseUp() 
    { 
        isSelected = false;
    }
}
