using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class ShopFunction : MonoBehaviour
{
    public Tilemap Walls;
    public RuleTile WallRules;
    public GameObject Bounds;
    public AstarPath Pathfinder;
    private Vector3 mouseLocation;
    public static bool BuildMode;
    // Start is called before the first frame update
    void Start()
    {
        BuildMode = false;
        Pathfinder = Bounds.GetComponent<AstarPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BuildMode == true)
        { 
            if (Input.GetMouseButtonDown(0))
            {
                mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Walls.SetTile(Walls.WorldToCell(mouseLocation), WallRules);
                
                Pathfinder.UpdateGraphs(Walls.localBounds);
                StatsHandeler.playerMoney -= 10;
            }

        }

        if (StatsHandeler.playerMoney < 10)
        {
            BuildMode = false;
        }

        

    }

    public void ClickBuyWall()
    {
        if(StatsHandeler.playerMoney >= 10 && BuildMode == false)
        {
            BuildMode = true;
        }
        else if (BuildMode == true)
        {
            BuildMode = false;
        }
    }
}
