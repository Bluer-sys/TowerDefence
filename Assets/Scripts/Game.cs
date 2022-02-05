using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameBoard _board;
    [SerializeField] private Vector2Int _boardSize;
    
    [SerializeField] private Camera _camera;

    [SerializeField] private GameTileContentFactory _contentFactory;
    
    private Ray TouchRay => _camera.ScreenPointToRay(Input.mousePosition);
    
    private void Start()
    {
        _board.Initialize(_boardSize, _contentFactory);
        _board.ShowGrid = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleTouch();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            HandleAlternativeTouch();
        }
        
        if (Input.GetKeyDown(KeyCode.V)) {
            _board.ShowPaths = !_board.ShowPaths;
        }
        
        if (Input.GetKeyDown(KeyCode.G)) {
            _board.ShowGrid = !_board.ShowGrid;
        }
    }

    private void HandleTouch()
    {
        GameTile tile = _board.GetTile(TouchRay);

        if (tile != null)
        {
            _board.ToggleWall(tile);
        }
    }

    private void HandleAlternativeTouch()
    {
        GameTile tile = _board.GetTile(TouchRay);

        if (tile != null)
        {
            _board.ToggleDestination(tile);
        }
    }
}
