int[] intsTools = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] intsSubstanced = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
List<int> challenges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

Queue<int> tools = new Queue<int>(intsTools);
Stack<int> substances = new Stack<int>(intsSubstanced);

while (tools.Count > 0 && substances.Count > 0)
{
    bool isFound = false;
    int currentTool = tools.Dequeue();
    int currentSubstance = substances.Pop();
    int result = currentTool * currentSubstance;

    for (int i = 0; i < challenges.Count; i++)
    {
        if (result == challenges[i])
        {
            challenges.RemoveAt(i);
            isFound = true;
            break;
        }

    }
    if (isFound)
    {
        if (challenges.Count == 0)
        {
            Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            if (tools.Count > 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }
            if (substances.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            Environment.Exit(0);
        }

    }
    else
    {
        currentTool += 1;
        tools.Enqueue(currentTool);
        currentSubstance -= 1;
        if (currentSubstance == 0)
        {
            continue;
        }
        else
        {
            substances.Push(currentSubstance);
        }
    }
    


}
Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
if (tools.Count > 0)
{
    Console.WriteLine($"Tools: {string.Join(", ", tools)}");
}
if (substances.Count > 0)
{
    Console.WriteLine($"Substances: {string.Join(", ", substances)}");
}
if (challenges.Count > 0)
{
    Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
}

