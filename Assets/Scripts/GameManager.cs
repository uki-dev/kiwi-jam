using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
     * This is the game manager, 
     * Can do
     *  - set up chanracters
     *  - chage characters
     */

    public static GameManager instance = null;

    public GameObject[] characters;
    public Player player;


    private Dictionary<int, bool> pressed = new Dictionary<int, bool>();

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (characters.Length <= 0){
            return;
        }
        if (player == null){
            player = GetComponent<Player>();
        }
    }

    private void changeCharacter(int i){

        // if press a key, which is not in characters list, do nothing
        if (i > characters.Length || i<0){
            return;
        }

        // if the character moved before, do nothing
        if (pressed.ContainsKey(i)){
            Debug.Log("You use this character before, cannot use it again");
            return;
        }

        // change character
        Debug.Log("change to character " + i);
        player.character = characters[i].GetComponent<Character>();


        pressed.Add(i, true);

    }


    //Update is called every frame.
    void Update()
    {
        // detect the key pressed
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {

                Debug.Log("KeyCode down: " + kcode);

                // use switch case to detect which number is pressed
                switch (kcode)
                {
                    case KeyCode.Alpha1:

                        changeCharacter(0);

                        break;
                    case KeyCode.Alpha2:

                        changeCharacter(1);

                        break;
                    case KeyCode.Alpha3:

                        changeCharacter(2);

                        break;
                    case KeyCode.Alpha4:

                        changeCharacter(3);

                        break;
                    case KeyCode.Alpha5:


                        changeCharacter(4);
                        break;
                    case KeyCode.Alpha6:
                        changeCharacter(5);


                        break;
                    case KeyCode.Alpha7:


                        changeCharacter(6);
                        break;
                    case KeyCode.Alpha8:


                        changeCharacter(7);
                        break;
                    case KeyCode.Alpha9:

                        changeCharacter(8);

                        break;
                    case KeyCode.Alpha0:

                        changeCharacter(9);

                        break;

                    default:
                        break;
                }
            }
        }
    }

    /*
     * Run this when player solve the puzzle successfully
     * 
     */
    public void GoNextLevel(){

        Debug.Log("solved, go to next level");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}