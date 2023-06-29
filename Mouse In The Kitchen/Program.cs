int[] dimensions = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
char[,] matrix = new char[dimensions[0], dimensions[1]];

int mouseRow = 0;
int mouseCol = 0;
int totalCheese = 0;
int cheeseFound = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    string currentRow = Console.ReadLine();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = currentRow[col];
        if (matrix[row, col] == 'M')
        {
            mouseRow = row;
            mouseCol = col;
        }
        if (matrix[row, col] == 'C')
        {
            totalCheese++;
        }
    }
}

string command;

while((command = Console.ReadLine()) != "danger")
{

    string direction = command;

    if (direction == "left")
    {
        if(isValidPosition(mouseRow,mouseCol - 1, matrix)) 
        {
            if(isThereATrap(mouseRow, mouseCol - 1, matrix))
            {
               
                matrix[mouseRow, mouseCol] = '*';
                matrix[mouseRow, mouseCol - 1] = 'M';
                mouseCol -= 1;
                Console.WriteLine("Mouse is trapped!");
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
            else if (isThereAWall(mouseRow, mouseCol - 1, matrix))
            {
                
                continue;
            }
            else if(isThereACheese(mouseRow,mouseCol - 1, matrix))
            {
               cheeseFound++;
            }
            matrix[mouseRow, mouseCol] = '*';
            matrix[mouseRow, mouseCol - 1] = 'M';
            mouseCol -= 1;
        }
        else
        {
            Console.WriteLine("No more cheese for tonight!");
            PrintMatrix(matrix);
            Environment.Exit(0);
        }
    }
    else if (direction == "right")
    {
        if (isValidPosition(mouseRow, mouseCol + 1, matrix))
        {
            if (isThereATrap(mouseRow, mouseCol + 1, matrix))
            {

                matrix[mouseRow, mouseCol] = '*';
                matrix[mouseRow, mouseCol + 1] = 'M';
                mouseCol += 1;
                Console.WriteLine("Mouse is trapped!");
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
            else if (isThereAWall(mouseRow, mouseCol + 1, matrix))
            {
              

                continue;
            }
            else if (isThereACheese(mouseRow, mouseCol + 1, matrix))
            {
                cheeseFound++;
            }
            matrix[mouseRow, mouseCol] = '*';
            matrix[mouseRow, mouseCol + 1] = 'M';
            mouseCol += 1;
        }
        else
        {
            Console.WriteLine("No more cheese for tonight!");
            PrintMatrix(matrix);
            Environment.Exit(0);
        }
    }
    else if (direction == "up")
    {
        if (isValidPosition(mouseRow - 1, mouseCol, matrix))
        {
            if (isThereATrap(mouseRow - 1, mouseCol, matrix))
            {

                matrix[mouseRow, mouseCol] = '*';
                matrix[mouseRow - 1, mouseCol] = 'M';
                mouseRow -= 1;
                Console.WriteLine("Mouse is trapped!");
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
            else if (isThereAWall(mouseRow - 1, mouseCol, matrix))
            {
               
                continue;
            }
            else if (isThereACheese(mouseRow - 1, mouseCol, matrix))
            {
                cheeseFound++;
            }
            matrix[mouseRow, mouseCol] = '*';
            matrix[mouseRow - 1, mouseCol] = 'M';
            mouseRow -= 1;
        }
        else
        {
            Console.WriteLine("No more cheese for tonight!");
            PrintMatrix(matrix);
            Environment.Exit(0);
        }
    }
    else if (direction == "down")
    {
        if (isValidPosition(mouseRow + 1, mouseCol, matrix))
        {
            if (isThereATrap(mouseRow + 1, mouseCol, matrix))
            {

                matrix[mouseRow, mouseCol] = '*';
                matrix[mouseRow + 1, mouseCol] = 'M';
                mouseRow += 1;
                Console.WriteLine("Mouse is trapped!");
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
            else if (isThereAWall(mouseRow + 1, mouseCol, matrix))
            {
                
                continue;
            }
            else if (isThereACheese(mouseRow + 1, mouseCol, matrix))
            {
                cheeseFound++;
            }
            matrix[mouseRow, mouseCol] = '*';
            matrix[mouseRow + 1, mouseCol] = 'M';
            mouseRow += 1;
        }
        else
        {
            Console.WriteLine("No more cheese for tonight!");
            PrintMatrix(matrix);
            Environment.Exit(0);
        }
    }
    if (cheeseFound == totalCheese)
    {
        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
        PrintMatrix(matrix);
        Environment.Exit(0);
    }
    
    
}
Console.WriteLine("Mouse will come back later!");
PrintMatrix(matrix);

bool isThereACheese(int row, int col, char[,] matrix)
{
    if (matrix[row, col] == 'C')
    {
        return true;
    }
    return false;
}

bool isThereAWall(int row, int col, char[,] matrix)
{
    if (matrix[row, col] == '@')
    {
        return true;
    }
    return false;
}

bool isThereATrap(int row, int col, char[,] matrix)
{
    if (matrix[row, col] == 'T')
    {
        return true;
    }
    return false;
}

void PrintMatrix(char[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col]);
        }
        Console.WriteLine();
    }
}

bool isValidPosition(int row, int col, char[,] matrix)
{
    //check if the position is valid
    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
    {
        return true;
    }
    return false;
}