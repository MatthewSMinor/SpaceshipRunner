using System.Collections;
using UnityEngine;

public class AstroidGeneration : MonoBehaviour
{
    public GameObject astroid;

    public float minAstroidSpeed = 3f;
    public float maxAstroidSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateAstroids());
    }

    public IEnumerator GenerateAstroids()
    {
        while(true)
        {
            float rightOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;
            float topOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;
            float bottomOfScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).y;

            var astroidPrefab = Instantiate(
                astroid,
                new Vector2(rightOfScreen, Random.Range(bottomOfScreen, topOfScreen)),
                Quaternion.identity
            );

            var rb = astroidPrefab.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.left * Random.Range(minAstroidSpeed, maxAstroidSpeed));

            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
