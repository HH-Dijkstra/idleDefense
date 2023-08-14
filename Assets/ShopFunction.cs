using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class ShopFunction : MonoBehaviour
{
    public Tilemap Walls;
    public Tile Wall;
    public RuleTile WallRules;
    private Vector3 mouseLocation;
    // Start is called before the first frame update
    void Start()
    {
        //Wall = Walls.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Walls.SetTile(Walls.WorldToCell(mouseLocation), Wall);
        }
        

    }

    public void ClickBuyWall()
    {

    }
}
