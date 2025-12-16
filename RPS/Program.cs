List<string> allowedSigns = ["rock", "paper", "scissors"];
Dictionary<string,  List<string>> winningMap = []; // WM
winningMap["rock"] = ["scissors", "lizard"];
winningMap["paper"] = ["rock", "spock"];
winningMap["scissors"] = ["paper", "lizard"];
winningMap["lizard"] = ["paper", "spock"]; 
winningMap["spock"] = ["rock", "scissors"];


string GetCorrectSign(string playerName)
{
    Console.WriteLine($"{playerName}, choose your sign ({string.Join('/', allowedSigns)})");
    string sign = Console.ReadLine()!;

    while (!allowedSigns.Contains(sign, StringComparer.OrdinalIgnoreCase))
    {
        Console.WriteLine($"{playerName}, choose correct sign ({string.Join('/', allowedSigns)})");
        sign = Console.ReadLine()!;
    }
    return sign;
}

string GetCorrectRandomSign(string playerName)
{
    int signIndex = Random.Shared.Next(allowedSigns.Count);
    string sign = allowedSigns[signIndex];
    Console.WriteLine($"{playerName} selected {sign}");

    return sign;
}

const StringComparison stringComparison = StringComparison.OrdinalIgnoreCase;

int firstPlayerPoints = 0;
int secondPlayerPoints = 0;
Console.WriteLine("Player 1, what's your name?");
string firstPlayerName = Console.ReadLine()!;
Console.WriteLine("Player 2, what's your name?");
string secondPlayerName = Console.ReadLine()!;

Console.WriteLine("How many wins?");
string maxWinsText = Console.ReadLine()!;
//int maxWins = int.Parse(maxWinsText);
bool parsingResult = uint.TryParse(maxWinsText, out uint maxWins);

while (!parsingResult)
{
    maxWinsText = Console.ReadLine()!;
    parsingResult = uint.TryParse(maxWinsText, out maxWins);
}


while (firstPlayerPoints < maxWins && secondPlayerPoints < maxWins)
{
    Console.WriteLine("Let's play Rock-Paper-Scissors!");

    string firstSign = GetCorrectSign($"{firstPlayerName}"); // P1
    string secondSign = GetCorrectSign($"{secondPlayerName}"); // P2

    List<string> signsLosingWithFirstSign = winningMap[firstSign];




    if (firstSign.Equals(secondSign, stringComparison))
    {
        Console.WriteLine("It's a draw!");
    }
    else if (signsLosingWithFirstSign.Contains(secondSign, StringComparer.OrdinalIgnoreCase))
    {
        Console.WriteLine("First player won!");
        //firstPlayerPoints = firstPlayerPoints + 1;
            firstPlayerPoints++;
        //firstPlayerPoints =+ 1;
    }
    else
    {
        Console.WriteLine("Second player won!");
        //secondPlayerPoints = secondPlayerPoints +1;
            secondPlayerPoints++;
        //secondPlayerPoints =+ 1;
    }

    Console.WriteLine($"{firstPlayerName}: {firstPlayerPoints}");
    Console.WriteLine($"{secondPlayerName}: {secondPlayerPoints}");

    //if(firstPlayerPoints >= maxWins || secondPlayerPoints >= maxWins)
    //{
    //    break;
    //}
}   
