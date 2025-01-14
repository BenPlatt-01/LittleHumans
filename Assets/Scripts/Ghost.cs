using UnityEngine;

public class Ghost : MonoBehaviour
{

    public GameObject objectToSpawn;

    private Animator camAnim;
    public GameObject buildEffect;

    public GameObject buildSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        mousePos.z = 0; 

        transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildSound);
            Instantiate(buildEffect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("Shake");
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
