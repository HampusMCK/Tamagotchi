class Tamagotchi
{
    ExOpponents e = new();
    int hunger;
    int boredom;
    public int money = 100;
    List<string> words = new();
    public List<store> ownedFood = new();
    public List<store> ownedItems = new();
    public List<store> dressed = new();
    public bool isAlive = true;
    Random gen = new();
    public string name;

    public void Feed()
    {
        Console.WriteLine($"What would you like to feed {name} with?");
        for (int i = 0; i < ownedFood.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ownedFood[i].ItemName}, Hunger Decrease: {ownedFood[i].HungerDecrease}");
        }
        string FeedChoise = Console.ReadLine();
        int FC;
        int.TryParse(FeedChoise, out FC);
        for (int i = 0; i < ownedFood.Count; i++)
        {
            if (FC == i + 1)
            {
                hunger -= ownedFood[i].HungerDecrease;
            }
        }
        if (hunger < 0)
        {
            hunger = 0;
        }
    }

    public void Hi()
    {
        int choise = gen.Next(words.Count);
        Console.WriteLine(words[choise]);
        ReduceBoredom();
    }

    public void Teach()
    {
        Console.WriteLine($"What would you like to teach {name}?");
        string newWord = Console.ReadLine();
        words.Add(newWord);
        Console.WriteLine($"You taught {name} to say '{newWord}'");
        ReduceBoredom();
    }

    public void Tick()
    {
        boredom += gen.Next(3);
        hunger += gen.Next(5);
        if (hunger >= 100 || boredom >= 200)
        {
            isAlive = false;
        }
    }

    public void PrintStats()
    {
        string aliveTrue;
        if (isAlive)
        {
            aliveTrue = "alive";
        }
        else
        {
            aliveTrue = "dead";
        }
        Console.WriteLine($"Hunger: {hunger}/100, Boredom: {boredom}/200, {name} is {aliveTrue}");
    }

    public bool GetAlive()
    {
        if (isAlive)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void ReduceBoredom()
    {
        boredom = boredom / 2;
    }

    public void DressUp()
    {
        Console.WriteLine($"what would you like to dress {name} in? {name} is currently wearing {dressed.Count} items");
        for (int i = 0; i < ownedItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ownedItems[i].ItemName}, Exhibition Score: {ownedItems[i].ExhibitionScore}");
        }
        string dressChoise = Console.ReadLine();
        int DC;
        int.TryParse(dressChoise, out DC);
        for (int i = 0; i < ownedItems.Count; i++)
        {
            if (DC == i + 1)
            {
                dressed.Add(ownedItems[i]);
                ownedItems.RemoveAt(i);
            }
        }
        if (dressed.Count > 2)
        {
            ownedItems.Add(dressed[0]);
            dressed.RemoveAt(0);
        }
        ReduceBoredom();
    }

    public void Exhibition()
    {
        Console.Clear();
        int win;
        int ExScore = 5;
        if (dressed.Count > 0)
        {
            ExScore = dressed[0].ExhibitionScore + dressed[1].ExhibitionScore;
        }
        int diff;
        Console.WriteLine($"At What Grade Would You Like to Compete In? 1 (Avg. Exh.points: 15, 1st price: $30), 2 (AVg. Exh.points: 30, 1st price: $50), or 3 (Avg. Exh.points: 60, 1st price: $100)");
        string DiffChoise = Console.ReadLine();
        int DiC;
        int.TryParse(DiffChoise, out DiC);
        if (DiC == 1)
        {
            e.AddOps1();
            win = gen.Next(151);
            win += ExScore;
            if (win >= 45)
            {
                Console.WriteLine("Congratulations! You won $30");
                money += 30;
            }
            else
            {
                Console.WriteLine("You Lost! );");
            }
            e.op1.RemoveRange(0, 3);
        }
        else if (DiC == 2)
        {
            e.AddOps2();
            win = gen.Next(151);
            win += ExScore;
            if (win >= 60)
            {
                Console.WriteLine("Congratulations! You won $50");
                money += 50;
            }
            else
            {
                Console.WriteLine("You Lost! );");
            }
            e.op2.RemoveRange(0, 3);
        }
        else if (DiC == 3)
        {
            e.AddOps3();
            win = gen.Next(151);
            win += ExScore;
            if (win >= 90)
            {
                Console.WriteLine("Congratulations! You won $100");
                money += 100;
            }
            else
            {
                Console.WriteLine("You Lost! );");
            }
            e.op3.RemoveRange(0, 3);
        }
        ReduceBoredom();
    }
}
