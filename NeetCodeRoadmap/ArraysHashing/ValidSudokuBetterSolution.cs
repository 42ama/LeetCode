
/// <summary>
/// Не использовать структуру и сделать ранний выход дало достаточный прирост скорости.
/// </summary>
public class ValidSudokuBetterSolution
{
    public bool IsValidSudoku(char[][] board)
    {
        var currentRowSet = new HashSet<char>();

        var columns = new HashSet<char>[board.Length];
        for (int i = 0; i < columns.Length; i++)
        {
            columns[i] = new HashSet<char>();
        }

        var boxes = new HashSet<char>[board.Length, board.Length];

        for (int rowIndex = 0; rowIndex < board.Length; rowIndex++)
        {
            var currentRow = board[rowIndex];
            for (int symbolInRowIndex = 0; symbolInRowIndex < currentRow.Length; symbolInRowIndex++)
            {
                var currentSymbol = currentRow[symbolInRowIndex];

                if (currentSymbol == '.') { continue; }

                // Добавляем в строку
                var isFoundInRow = CheckAndAddToSet(currentRowSet, currentSymbol);
                if (isFoundInRow)
                {
                    return false;
                }

                // Добавляем в колонку
                var isFoundInColumn = CheckAndAddToSet(columns[symbolInRowIndex], currentSymbol);
                if (isFoundInColumn)
                {
                    return false;
                }

                var xForBox = GetBracket(symbolInRowIndex);
                var yForBox = GetBracket(rowIndex);
                var currentBox = boxes[xForBox, yForBox];
                if (currentBox != null)
                {
                    var isFoundInBox = CheckAndAddToSet(currentBox, currentSymbol);
                    if (isFoundInBox)
                    {
                        return false;
                    }
                }
                else
                {
                    boxes[xForBox, yForBox] = new HashSet<char>();
                    CheckAndAddToSet(boxes[xForBox, yForBox], currentSymbol);
                }
            }

            currentRowSet = new HashSet<char>();
        }

        return true;
    }

    /// <returns>true если элемент уже был в сете, false если это точка или новый элемент</returns>
    private bool CheckAndAddToSet(ISet<char> set, char symbol)
    {
        if (set.Contains(symbol))
        {
            return true;
        }
        else
        {
            set.Add(symbol);
            return false;
        }
    }

    private int GetBracket(int value)
    {
        return value / 3;
    }
}