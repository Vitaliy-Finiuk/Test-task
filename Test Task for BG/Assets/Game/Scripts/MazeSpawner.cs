using UnityEngine;
using UnityEngine.AI;
public class MazeSpawner : MonoBehaviour
{

    [SerializeField] private NavMeshSurface _surface;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Vector3 CellSize = new Vector3(1,1,0);
    [SerializeField] private Maze maze;

    private Renderer _renderer;

    private void Start()
    {
        SpawnWall();

        _surface.BuildNavMesh();

    }

    private void SpawnWall(){
        MazeGenerator generator = new MazeGenerator();
        maze = generator.GenerateMaze();

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity, transform);

                c.WallLeft.SetActive(maze.cells[x, y].WallLeft);
                c.WallBottom.SetActive(maze.cells[x, y].WallBottom);
            }
        }
    }
}