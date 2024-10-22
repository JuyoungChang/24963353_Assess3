using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCollision : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase wall;
    public TileBase pellet;
    private UIManager ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = gameObject.GetComponent<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ui.ScoreAdd(10);
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
