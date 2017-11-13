using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public PlayerController player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 newCameraPosition = new Vector2(
            player.transform.position.x,
            transform.position.y);
        transform.position = newCameraPosition;
	}
}
