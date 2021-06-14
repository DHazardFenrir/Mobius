using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] PuzzleData[] puzzles;

    private void Start()
    {
        puzzles = FindObjectsOfType<PuzzleData>();
    }


}
