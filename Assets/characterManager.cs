using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterManager : MonoBehaviour
{
    public int level = 1;
    public bool one = false;
    public bool two = false;
    public bool three = false;
    public bool four = false;
    public bool five = false;
    public bool six = false;
    public bool win = false;
    public bool lose = false;

    // Use this for initialization
    void Start()
    {
        level = 1;
        LevelSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if (lose)
        {
            LevelSetup();
        }
        if (win)
        {
            level += 1;
            LevelSetup();
        }
        if (Input.GetKey("1"))
        {
            if (one)
            {

                one = false;
            }
        }
        if (Input.GetKey("2"))
        {
            if (two)
            {

                two = false;
            }
        }
        if (Input.GetKey("3"))
        {
            if (three)
            {

                three = false;
            }
        }
        if (Input.GetKey("4"))
        {
            if (four)
            {

                four = false;
            }
        }
        if (Input.GetKey("5"))
        {
            if (five)
            {

                five = false;
            }
        }
        if (Input.GetKey("6"))
        {
            if (six)
            {

                six = false;
            }
        }
    }
    void ResetLevel()
    {
        one = false;
        six = false;
        two = false;
        three = false;
        four = false;
        five = false;

    }
    void LevelSetup()
    {
        ResetLevel();
        if (level == 1)
        {
            one = true;
            two = true;
        }
        if (level == 2)
        {
            two = true;
            four = true;
            five = true;
        }
        if (level == 3)
        {
            one = true;
            three = true;
            five = true;

        }
        if (level == 4)
        {
            two = three = four = six = true;
        }
        if (level == 5)
        {
            one = two = four = five = six = true;
        }


    }
}
