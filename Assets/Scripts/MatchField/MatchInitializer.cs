using UnityEngine;

public class MatchInitializer : MonoBehaviour {

    public GameObject FieldItem;
    private MatchGrid grid;

	void Start () 
    {
        grid = new MatchGrid();
        VisualizeGrid(grid);
	}

    private void VisualizeGrid(MatchGrid grid)
    {
        for (int x = 0; x < grid.Xsize; x++)
        {
            for (int y = 0; y < grid.Ysize; y++)
            {
                Vector3 position = new Vector3(x, y);
                Instantiate(FieldItem, position, Quaternion.identity);
            }
        }
    }
}
