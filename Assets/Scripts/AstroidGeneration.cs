using System.Collections;
using UnityEngine;

public class AstroidGeneration : MonoBehaviour
{
    /// <summary>
    /// The astroid Prefab game object.
    /// </summary>
    public GameObject astroid;

    /// <summary>
    /// The minimum speed for an astroid.
    /// </summary>
    public float minAstroidSpeed = 3f;

    /// <summary>
    /// The maximum speed for an astroid.
    /// </summary>
    public float maxAstroidSpeed = 10f;

    /// <summary>
    /// Determines the amount of vertical variance there will be in an astroid's heading.
    /// </summary>
    public float yVariance = 20f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateAstroids());
    }

    /// <summary>
    /// Generates a new astroid on an interval.
    /// </summary>
    public IEnumerator GenerateAstroids()
    {
        while(true)
        {
            // Grab to camera screen bounds.
            float rightOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;
            float topOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;
            float bottomOfScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).y;

            // Create the astroid with no rotation, an x that is off the right of the screen
            // and a random y value within the bounds of the screen.
            var astroidPrefab = Instantiate(
                astroid,
                new Vector2(rightOfScreen, Random.Range(bottomOfScreen, topOfScreen)),
                Quaternion.identity
            );

            // TODO: Does not seem to be working.
            astroidPrefab.transform.Rotate(Vector3.down, Space.Self);

            // Grab the astroid's rigid body component and apply force to it.
            var rb = astroidPrefab.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(-1 * Random.Range(minAstroidSpeed, maxAstroidSpeed),
                                    Random.Range(bottomOfScreen - yVariance, topOfScreen + yVariance)));

            // Wait on interval before spawning the next astroid.
            yield return new WaitForSeconds(0.3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
