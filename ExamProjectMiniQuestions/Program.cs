internal class Program
{
    static void Main(string[] args)
    {
        string[] questions =
            {
                "1.Azerbaycanin paytaxti haradir?",
                "2.Paytaxti Azerbaycan olan olke hansidir?",
                "3.Baki Dovlet Universiteti hansi metro stansiya yaxinliginda yerlesir?",
                "4.Dunyadaki en boyuk cayin adi nedir?",
                "5.Butulka ev hansi regionda yerlesir?",
                "6.Qarabagin merkezi hansi seherdir?",
                "7.Hansi soz ingilis dilinde salam menasini ifade edir?",
                "8.Rus dilinde nece rod var?",
                "9.Screen Azerbaycan diline tercumede hansi menani ifade edir?",
                "10.Asagidakilardan hansilar back-end proqramlasdirma dillerine ziddir?"
            };
        string[][] answers =
        {
                new string[] {"Baki","Gence","Mingecevir"},
                new string[] {"Turkiye","Azerbaycan","Gurcustan"},
                new string[] {"Azadliq","Genclik","Elmler"},
                new string[] {"Nil","Cil","Volga"},
                new string[] {"Tovuz","Gence","Sirvan"},
                new string[] {"Susa","Agdam","Fizuli"},
                new string[]{"Hi","Bye","Weather"},
                new string[] {"2","4","3" },
                new string[] {"Monitor","Ekran","Klaviatura" },
                new string[] {"Javascript","C#","SCSS" }
            };
        int[] trueAnswersIndex = { 0, 1, 2, 0, 1, 0, 0, 2, 1, 2 };
        Exam(questions, answers, trueAnswersIndex);
    }
    static void Exam(string[] questions, string[][] answers, int[] trueAnswersIndex)
    {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        int Balance = 0;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\t\t\t\t~~~~~~~~~~~Let's start~~~~~~~~~");
        Console.ResetColor();
        for (int i = 0; i < questions.Length; i++)
        {
            string[] fixedAnswers = FixedAnswers(answers[i], trueAnswersIndex[i], out int newTrueIndex);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\tQuestion {i + 1}");
            Console.ResetColor();
            Console.WriteLine(questions[i]);
            Console.WriteLine($"a){fixedAnswers[0]}");
            Console.WriteLine($"b){fixedAnswers[1]}");
            Console.WriteLine($"c){fixedAnswers[2]}");
            Console.WriteLine("Enter your answer:(a,b,c)");
            string yourAnswer = Console.ReadLine().ToLower();
            int fixedIndex = -1;
            if (yourAnswer == "a") fixedIndex = 0;
            else if (yourAnswer == "b") fixedIndex = 1;
            else if (yourAnswer == "c") fixedIndex = 2;
            if (fixedIndex == -1)
            {
                Console.WriteLine("Wrong choice!");
                i--;
                continue;
            }
            if (fixedIndex == newTrueIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("True answer!");
                Balance += 10;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong answer!");
                if (Balance == 0)
                {
                    Balance = 0;
                }
                else if (Balance >= 10)
                {
                    Balance -= 10;
                }
            }
            Console.ResetColor();
            if (Balance < 0)
            {
                Console.WriteLine($"Total count:{0}");
            }
            else
            {
                Console.WriteLine($"Total count: {Balance}");
            }
        }
        Console.WriteLine($"Exam finished! Your Balance:{Balance}.");
    }
    static string[] FixedAnswers(string[] answers, int trueIndex, out int newTrueIndex)
    {
        string[] fixedAnswers = new string[answers.Length];
        bool[] checkChoiceIndexs = new bool[answers.Length];
        Random random = new Random();
        newTrueIndex = -1;
        for (int i = 0; i < answers.Length; i++)
        {
            int index;
            while (true)
            {
                index = random.Next(0, answers.Length);
                if (!checkChoiceIndexs[index]) break;
            }

            checkChoiceIndexs[index] = true;
            fixedAnswers[i] = answers[index];
            if (index == trueIndex)
            {
                newTrueIndex = i;
            }
        }
        return fixedAnswers;
    }
}