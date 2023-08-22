public class ValidSudokuSolution
{
    public bool IsValidSudoku(char[][] board)
    {
        var currentRowSet = new HashSet<char>();

        var columns = new HashSet<char>[board.Length];
        for (int i = 0; i < columns.Length; i++)
        {
            columns[i] = new HashSet<char>();
        }

        var boxes = new Dictionary<Coordinate, HashSet<char>>();

        for (int rowIndex = 0; rowIndex < board.Length; rowIndex++)
        {
            var currentRow = board[rowIndex];
            for (int symbolInRowIndex = 0; symbolInRowIndex < currentRow.Length; symbolInRowIndex++)
            {
                var currentSymbol = currentRow[symbolInRowIndex];

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

                var coordinateBracket = GetCoordianteBracket(symbolInRowIndex, rowIndex);
                if (boxes.TryGetValue(coordinateBracket, out var boxSet))
                {
                    var isFoundInBox = CheckAndAddToSet(boxSet, currentSymbol);
                    if (isFoundInBox)
                    {
                        return false;
                    }
                }
                else
                {
                    boxes.Add(coordinateBracket, new HashSet<char>());
                    CheckAndAddToSet(boxes[coordinateBracket], currentSymbol);
                }
            }

            currentRowSet = new HashSet<char>();
        }

        return true;
    }

    /// <returns>true если элемент уже был в сете, false если это точка или новый элемент</returns>
    private bool CheckAndAddToSet(ISet<char> set, char symbol)
    {
        if (symbol == '.') { return false; }

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

    private Coordinate GetCoordianteBracket(int x, int y)
    {
        return new Coordinate
        {
            RowBracket = GetBracket(x),
            ColumnBracket = GetBracket(y)
        };
    }

    private int GetBracket(int value)
    {
        return value / 3;
    }

    private struct Coordinate
    {
        public int RowBracket;
        public int ColumnBracket;
    }
}