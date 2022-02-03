using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hand : MonoBehaviour
{
    public enum HandEnum
    {
        Rock,
        Paper,
        Scissor
    }

    public HandEnum currentHand;
    public GameObject owner;
}

