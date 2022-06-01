using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMonitor : MonoBehaviour
{
    private float rotationRange;

    // Start is called before the first frame update
    void Start()
    {
        rotationRange = Random.Range(0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        // Add rotation to the alien
        gameObject.GetComponent<Rigidbody2D>().rotation += rotationRange;

        float rightOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;
        float leftOfScreen = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width * -1), Screen.height, 0)).x;
        float topOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;
        float bottomOfScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).y;

        // Determine if the astroid is off screen either left, up, or down.
        // If so, destroy the gameObject.
        if (gameObject.transform.position.x < leftOfScreen ||
            gameObject.transform.position.y < bottomOfScreen ||
            gameObject.transform.position.y > topOfScreen)
        {
            Destroy(gameObject);
        }
    }
}
