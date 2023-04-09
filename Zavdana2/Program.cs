public interface IInventory
{
    void Equip();
}

public abstract class Hero : IInventory
{
    public string Name;

    abstract public void Equip();

    public Hero(string name)
    {
        Name = name;
    }
}

// клас воїна
public class Warrior : Hero
{
    public Warrior(string name) : base(name)
    {
    }

    public override void Equip() { }
}

// клас мага
public class Mage : Hero
{
    public Mage(string name) : base(name)
    {
    }

    public override void Equip() { }
}

// клас паладина
public class Paladin : Hero
{
    public Paladin(string name) : base(name)
    {
    }

    public override void Equip() { }
}

public abstract class BaseInventoryDecorator : IInventory
{
    protected IInventory _inventory;

    public BaseInventoryDecorator(IInventory inventory)
    {
        _inventory = inventory;
    }

    public virtual void Equip()
    {
        _inventory.Equip();
    }
}

// конкретний декоратор для одягу
public class ClothesDecorator : BaseInventoryDecorator
{
    public ClothesDecorator(IInventory inventory) : base(inventory)
    {
    }

    public override void Equip()
    {
        base.Equip();
        Console.WriteLine("Equip clothes");
    }
}

// конкретний декоратор для зброї
public class WeaponDecorator : BaseInventoryDecorator
{
    public WeaponDecorator(IInventory inventory) : base(inventory)
    {
    }

    public override void Equip()
    {
        base.Equip();
        Console.WriteLine("Equip weapon");
    }
}

// конкретний декоратор для артефактів
public class ArtifactDecorator : BaseInventoryDecorator
{
    public ArtifactDecorator(IInventory inventory) : base(inventory)
    {
    }

    public override void Equip()
    {
        base.Equip();
        Console.WriteLine("Equip artifacts");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // створення героїв
        Hero warrior = new Warrior("Leo");
        Hero mage = new Mage("Vana");

        // створення інвентарю і декорування його
        IInventory inventory1 = new ClothesDecorator(new ArtifactDecorator(new WeaponDecorator(warrior)));

        IInventory inventory2 = new ArtifactDecorator(new WeaponDecorator(mage));

        //Екіпіровуєм інвентарь
        inventory1.Equip();
        Console.WriteLine("\n");
        inventory2.Equip();

    }
}