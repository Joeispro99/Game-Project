using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Tile grassmiddle;
    [SerializeField] private Tile grassfloating;
    [SerializeField] private Tilemap map;
    private Vector3 ctposition;
    [SerializeField] private Transform ct;
    private void Update()
    {
        ctposition = new Vector3(ct.position.x, ct.position.y-1.5f, ct.position.z);
        Vector3Int currentCell = map.WorldToCell(ctposition);
        map.SetTile(currentCell,grassmiddle);
    }
    
}
