using UnityEngine;
using System.Collections;

public class CameraFollowing : MonoBehaviour
{

    // please attach this script same with the player script

    // credits
    // https://unity3d.com/learn/tutorials/projects/2d-ufo-tutorial/following-player-camera

    [HideInInspector]
    public GameObject player;       //Public variable to store a reference to the player game object

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        // init the player object with the one in Player script, update this in character changing
        if (GetComponent<Player>()){
            player = GetComponent<Player>().character.gameObject;  
        }else{
            Debug.LogError("Please attach this script at the same object with player script");
        }

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}