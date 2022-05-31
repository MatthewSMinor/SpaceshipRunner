using System.Collections;
using UnityEngine;

public class AlienGeneration : MonoBehaviour
{
    /// <summary>
    /// The alien Prefab game object.
    /// </summary>
    public GameObject alien;

    /// <summary>
    /// The minimum speed for an Alien.
    /// </summary>
    public float minAlienSpeed = 3f;

    /// <summary>
    /// The maximum speed for an Alien.
    /// </summary>
    public float maxAlienSpeed = 10f;

    /// <summary>
    /// Determines the amount of vertical variance there will be in an Alien's heading.
    /// </summary>
    public float yVariance = 20f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateAliens());
    }

    /// <summary>
    /// Generates a new Alien on an interval.
    /// </summary>
    public IEnumerator GenerateAliens()
    {
        while(true)
        {
            // Grab to camera screen bounds.
            float rightOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;
            float topOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;
            float bottomOfScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).y;

            // Create the Alien with no rotation, an x that is off the right of the screen
            // and a random y value within the bounds of the screen.
            var alienPrefab = Instantiate(
                alien,
                new Vector2(rightOfScreen, Random.Range(bottomOfScreen, topOfScreen)),
                Quaternion.identity
            );

            // TODO: Does not seem to be working.
            alienPrefab.transform.Rotate(Vector3.down, Space.Self);

            // Grab the Alien's rigid body component and apply force to it.
            var rb = alienPrefab.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(-1 * Random.Range(minAlienSpeed, maxAlienSpeed),
                                    Random.Range(bottomOfScreen - yVariance, topOfScreen + yVariance)));

            // Wait on interval before spawning the next Alien.
            yield return new WaitForSeconds(10f);
        }
    }
}
