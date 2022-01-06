using UnityEngine;
using UnityEngine.AI;
public class MazeSpawner : MonoBehaviour
{

    [SerializeField] private NavMeshSurface _surface;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Vector3 _cellSize = new Vector3(1,1,0);
    [SerializeField] private Maze _maze;

    private Renderer _renderer;

    private void Start()
    {
        SpawnWall();

        _surface.BuildNavMesh();

    }

    private void SpawnWall(){
        MazeGenerator generator = new MazeGenerator();
        _maze = generator.GenerateMaze();

        for (int x = 0; x < _maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < _maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(_cellPrefab, new Vector3(x * _cellSize.x, y * _cellSize.y, y * _cellSize.z), Quaternion.identity, transform);

                c.WallLeft.SetActive(_maze.cells[x, y].WallLeft);
                c.WallBottom.SetActive(_maze.cells[x, y].WallBottom);
            }
        }
    }
}