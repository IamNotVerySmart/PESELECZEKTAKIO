//tworzenie zmiennych
int month = 0;
int year = 0;
string gender = "";
DateTime today = DateTime.Now;
string path = @"pesel.txt";

Console.WriteLine("Do you want to input(1) pesel or see saved(2)?");
string choice = Console.ReadLine()!;
if (choice == "1")
{//zbieranie wartosci
    Console.WriteLine("give name");
    string name = Console.ReadLine()!;
    Console.WriteLine("give surname");
    string surname = Console.ReadLine()!;
    Console.WriteLine("give pesel");
    string pesel = Console.ReadLine()!;

    int pYear = int.Parse(pesel.Substring(0, 2));
    int pMonth = int.Parse(pesel.Substring(2, 2));
    int pDay = int.Parse(pesel.Substring(4, 2));
    int pGender = int.Parse(pesel.Substring(10, 1));

    //sprawdzanie i przypisywanie roku urodznenia
    if (pMonth >= 81 && pMonth <= 92)
    {
        month = pMonth - 80;
        year = 1800 + pYear;
    }
    if (pMonth >= 01 && pMonth <= 12)
    {
        month = pMonth;
        year = 1900 + pYear;
    }
    if (pMonth >= 21 && pMonth <= 32)
    {
        month = pMonth - 20;
        year = 2000 + pYear;
    }
    //sprawdzanie plci
    if (pGender == 0 || pGender == 2 || pGender == 4 || pGender == 6 || pGender == 8)
    {
        gender = "female";
    }
    else { gender = "male"; }
    int age = 0;
    //obliczanie wieku
    int CalculateAge()
    {
        int t1 = today.Day;
        int t2 = today.Month;
        int t3 = today.Year - year;
        if (t2 <= month)
        {
            if (t1 <= pDay)
            {
                age = t3 - 1;
            }
        }
        else
        {
            age = t3;
        }
        return age;
    }
    CalculateAge();
    //wypisywanie podanych danych/zapisywanie do pliku
    Console.WriteLine($"name: {name} surname: {surname} pesel: {pesel} age: {age} gender: {gender}");
    string[] save = { $"{name};{surname};{pesel};{age};{gender}" };

    File.AppendAllLines(path, save);
    Console.WriteLine($"data has been saved to {path}");
}
if(choice == "2")
{
    //zczytywanie z pliku
    Console.WriteLine(File.ReadAllText(path));
}
//52060616679