using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController1 : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;
    private GameController gameController;
    
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'gameController' script");
        }

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if(Input.GetKeyDown(KeyCode.Z))
        {
            scrollSpeed = scrollSpeed - 3f;
        }
    }
}
