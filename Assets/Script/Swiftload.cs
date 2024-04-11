using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiftload : MonoBehaviour
{
    public static float porcentageTime;
    [SerializeField] private float porcentage;
    public static bool swiftloadActivated;
    private void Start()
    {
        swiftloadActivated = true;
        porcentageTime = porcentage;
    }
}
