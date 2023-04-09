class FrenchFries
{
    protected int portion;
    protected int sauce;
    public float price = 0;

    public void selectionFrenchFries()
    {
        do {
            Console.WriteLine("Вибирiть картошку \n1)Маленька\n2)Середня\n3)Велика");
            portion = Convert.ToInt32(Console.ReadLine());
        } while(portion >= 3 && portion<=1);
        switch (portion)
        {
            case 1:
                price += 50;
                break;
            case 2:
                price += 100;
                break;
            case 3:
                price += 150;
                break;
        }
        string ok;
        Console.WriteLine("Бажаєте до картошкi соус, натиснiть : +/-");
        ok = Console.ReadLine();
        if (ok == "+")
        {
            do
            {
                Console.WriteLine("Вибирiть соус \n1)Кечуп\n2)Сирний");
                sauce = Convert.ToInt32(Console.ReadLine());
            } while (portion >= 2 && portion <= 1);
            switch (sauce)
            {
                case 1:
                    price += 10;
                    break;
                case 2:
                    price += 12;
                    break;
            }
        }
    }
}
class Colla
{
    protected int portion;
    public float price = 0;

    public void selectionColla()
    {
        do
        {
            Console.WriteLine("Вибирiть колу \n1)Маленька\n2)Середня\n3)Велика");
            portion = Convert.ToInt32(Console.ReadLine());
        } while (portion >= 3 && portion <= 1);
        switch (portion)
        {
            case 1:
                price += 50;
                break;
            case 2:
                price += 100;
                break;
            case 3:
                price += 150;
                break;
        }
    }
}

class Burger
{
    protected int type;
    public float price = 0;
    public void selectionBurger()
    {
        do
        {
            Console.WriteLine("Вибирiть бургер \n1)Гамбургер\n2)Чiзбургер\n3)Дабл Чiзбургер\n4)МакЧiкен\n5)Бiг Тейстi");
            type = Convert.ToInt32(Console.ReadLine());
        } while (type >= 5 && type <= 1);
        switch (type)
        {
            case 1:
                price += 185;
                break;
            case 2:
                price += 166;
                break;
            case 3:
                price += 176;
                break;
            case 4:
                price += 200;
                break;
            case 5:
                price += 154;
                break;
        }
    }
}

class Facade
{
    protected float pric = 0;
    protected FrenchFries FrenchFries;
    protected Colla Colla;
    protected Burger burger;

    public Facade()
    {
        this.FrenchFries = new FrenchFries();
        this.Colla = new Colla();
        this.burger = new Burger();
    }

    public void Start() {
        string ok;
        Console.WriteLine("Бажаєте взяти кратошку, натиснiть : +/-");
        ok = Console.ReadLine();
        if (ok == "+")
        {
            FrenchFries.selectionFrenchFries();
            pric = FrenchFries.price;
            Console.WriteLine("\n================================\n");
        }
        Console.WriteLine("Бажаєте взяти колу, натиснiть : +/-");
        ok = Console.ReadLine();
        if (ok == "+")
        {
            Colla.selectionColla();
            pric += Colla.price;
            Console.WriteLine("\n================================\n");
        }
        Console.WriteLine("Бажаєте взяти бургер, натиснiть : +/-");
        ok = Console.ReadLine();
        if (ok == "+")
        {
            burger.selectionBurger();
            pric += burger.price;
            Console.WriteLine("\n================================\n");
        }
        Console.WriteLine($"Ваше замовлення приняте.\nВартiсть замовлення : {pric}.\nДякую за замовлення");
    }
}

    class Program
{
    static void Main(string[] args)
    {
        Facade facade = new Facade();
        facade.Start();
    }
}