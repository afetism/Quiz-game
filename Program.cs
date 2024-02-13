// See https://aka.ms/new-console-template for more information
using System.Drawing;

string[,] Questions ={ {"Azerbaycanin paytaxti haradir?","Baki","Agdam","Naxchivan","Baki"},
    {"Azerbaycanin ilk Dovlet hansi olmusdur?","Albaniya","Manna","Atropatina","Manna"},
    {"241543903 yazib internetde axtariqda bashini hara yerlesdiren insan gorererik?","soyuducu","paltaryuyan","avtomobil","soyuducu"},
    {"Idmanci ne qiranda secinir?","Rekord","Guldan","Chene","Rekord" },
    {"Azerbaycanda ilk aptek harda acilib?","Banke","Oxut","Qedimkend","Banke" }
};
var green ="\u001b[32m";
var red = ".\u001b[31m";
var reset = "\u001b[0m";


int result = 0;

for (int i = 0; i<Questions.GetLength(0); i++)
{
    string correctAnswer = Questions[i, 4];
    string[] shuffleArray = shuffleAnswer(1, 4, i);
    Console.WriteLine($"Result: {result}");
    Console.WriteLine($"{i+1}. {Questions[i, 0]}");
    int choose = 0;
    setMenu(choose, shuffleArray);
    while(true)
    {
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"{i+1}. {Questions[i, 0]}");
            int choose_= moveInArray(key,ref choose, shuffleArray.Length);
            if (choose_==0)setMenu(choose, shuffleArray);
            else
            {
            Console.Clear();
            if (correctAnswer==shuffleArray[choose])
            {
                result+=10;
                Console.ForegroundColor=ConsoleColor.Green;
                Console.WriteLine($"Result: {result}");
                Console.WriteLine($"{i+1}. {Questions[i, 0]}");
                Console.WriteLine("Correct Answer");
                Console.ForegroundColor= ConsoleColor.White;
            }

            else
            {

                result= Math.Max(0, result-10);
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine($"Result: {result}");
                Console.WriteLine($"{i+1}. {Questions[i, 0]}");
                Console.WriteLine("Incorrect Answer");
                Console.ForegroundColor= ConsoleColor.White;
            }
            break;
             }
    }



}
Console.Clear();
Console.WriteLine("Oyun Bitdi!");
Console.WriteLine($"Your result: {result}");

int moveInArray(ConsoleKeyInfo key,ref int choose,int size)
{
    if (key.Key==ConsoleKey.RightArrow)
    {
        if (choose<size-1)
            choose++;
        else if (choose == size-1)
            choose =0;
    }
    else if (key.Key==ConsoleKey.LeftArrow)
    {
        if (choose>0)
            choose--;
        else if (choose==0)
            choose =size-1;
    }
    else if (key.Key==ConsoleKey.Enter)
        return 1;
    return 0;
}
void setMenu(int choose,string[] shuffleArray)
{
    for(int i=0; i<shuffleArray.Length; i++)
    {
        if(choose == i)
        {
            Console.WriteLine($"{green}A.{shuffleArray[0]}{reset} B.{shuffleArray[1]} C.{shuffleArray[2]}");
            break;
        }
        if (choose == 1)
        {
            Console.WriteLine($"A.{shuffleArray[0]}{green} B.{shuffleArray[1]}{reset} C.{shuffleArray[2]}");
            break;
        }
        if (choose == 2)
        {
            Console.WriteLine($"A.{shuffleArray[0]} B.{shuffleArray[1]} {green}C.{shuffleArray[2]}{reset}");
            break;
        }
    }
}

string[] shuffleAnswer(int from,int until,int i)
{
    string[] suffleArray = new string[until-from];
    int index = 0;
    Random random = new Random();
    bool[] checkArray = new bool[until-from+1];

    while (index<until-from)
    {
        int randomNum = random.Next(from, until);
        if (!checkArray[randomNum])
        {
            suffleArray[index++]=Questions[i, randomNum];
            checkArray[randomNum]=true;
        }
    }
    
    return suffleArray; 
}


