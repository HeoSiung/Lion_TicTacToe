using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public BlockController blockController;     // ���� ó���� ��ü

    private Constants.PlayerType[,] _board;     // ������ ���� ����

    public BasePlayerState firstPlayerState;        // �÷��̾� A
    public BasePlayerState secondPlayerState;       // �÷��̾� B

    public enum GameResult { None, Win, Lose, Draw }

    private BasePlayerState _currentPlayerState;    // ���� ���� �÷��̾�

    public GameLogic(BlockController blockController, Constants.GameType gameType)
    {
        this.blockController = blockController;

        // ������ ���� ���� �ʱ�ȭ
        _board = new Constants.PlayerType[Constants.BlockColumnCount, Constants.BlockColumnCount];

        // Game Type �ʱ�ȭ
        switch (gameType)
        {
            case Constants.GameType.SinglePlay:
                break;
            case Constants.GameType.DualPlay:
                firstPlayerState = new PlayerState(true);
                secondPlayerState = new PlayerState(false);
                // ���� ����
                SetState(firstPlayerState);
                break;
            case Constants.GameType.MultiPlay:
                break;
        }
    }

    // ���� �ٲ� ��, ���� �����ϴ� ���¸� Exit �ϰ�
    // �̹� �ش� ���� ���¸� _currentPlayerState�� �Ҵ��ϰ�
    // �̹� ���� ���°� Enter ȣ��
    public void SetState(BasePlayerState state)
    {
        _currentPlayerState?.OnExit(this);
        _currentPlayerState = state;
        _currentPlayerState?.OnEnter(this);
    }

    // _board �迭�� ���ο� Marker ���� �Ҵ�
    public bool SetNewBoardValue(Constants.PlayerType playerType, int row, int col)
    {
        if (_board[row, col] != Constants.PlayerType.None) return false;

        if (playerType == Constants.PlayerType.PlayerA)
        {
            _board[row, col] = playerType;
            blockController.PlaceMarker(Block.MarkerType.o, row, col);
            return true;
        }
        else if (playerType == Constants.PlayerType.PlayerB)
        {
            _board[row, col] = playerType;
            blockController.PlaceMarker(Block.MarkerType.x, row, col);
            return true;
        }
        return false;
    }

    // ���� ���� ó��
    public void EndGame(GameResult gameResult)
    {
        // Game Logic ����
        SetState(null);
        firstPlayerState = null;
        secondPlayerState = null;

        // TODO: ���� ���� ǥ��
        Debug.Log("### ���� ���� ###");
    }

    // ���� ��� Ȯ��
    public GameResult CheckGameResult()
    {
        if (CheckGameWin(Constants.PlayerType.PlayerA, _board))
            return GameResult.Win;

        if (CheckGameWin(Constants.PlayerType.PlayerB, _board))
            return GameResult.Lose;

        if (CheckGameDraw(_board))
            return GameResult.Draw;

        return GameResult.None;
    }

    // ������ Ȯ��
    public bool CheckGameDraw(Constants.PlayerType[,] board)
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            for (var col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == Constants.PlayerType.None) return false;
            }
        }
        return true;
    }

    // �̰���� Ȯ��
    private bool CheckGameWin(Constants.PlayerType playerType, Constants.PlayerType[,] board)
    {
        // row üũ �� ���ڸ� �¸�
        for (var row = 0; row < board.GetLength(0); row++)
        {
            if (board[row, 0] == playerType &&
                board[row, 1] == playerType &&
                board[row, 2] == playerType)
            {
                return true;
            }
        }

        // col üũ �� ���ڸ� �¸�
        for (var col = 0; col < board.GetLength(1); col++)
        {
            if (board[0, col] == playerType &&
                board[1, col] == playerType &&
                board[2, col] == playerType)
            {
                return true;
            }
        }

        // �밢�� üũ �� ���ڸ� �¸�
        if (board[0, 0] == playerType &&
            board[1, 1] == playerType &&
            board[2, 2] == playerType)
        {
            return true;
        }
        if (board[0, 2] == playerType &&
            board[1, 1] == playerType &&
            board[2, 0] == playerType)
        {
            return true;
        }

        // ���� �� �̱�
        return false;
    }
}
