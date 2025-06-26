using System;

// Интерфейсы продуктов AbstractProduct
public interface IChair
{
    void SitOn();
}

public interface ITable
{
    void PutItem();
}

// Конкретные реализации интерфейсов продуктов ConcreteAbstractProduct
class ModernChair : IChair
{
    public void SitOn() => Console.WriteLine("Сесть на стул");
}

class ModernTable : ITable
{
    public void PutItem() => Console.WriteLine("Поставить предмет на стол");
}

class ClassicChair : IChair
{
    public void SitOn() => Console.WriteLine("Сесть на кресло");
}

class ClassicTable : ITable
{
    public void PutItem() => Console.WriteLine("Поставить предмет на чайный столик");
}

// Интерфейс фабрики AbstractFactory 
public interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}

// Конкретные фабрики ConcreteFactory 
class FurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new ModernChair();
    public ITable CreateTable() => new ModernTable();
}

class AlternativeFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new ClassicChair();
    public ITable CreateTable() => new ClassicTable();
}

// Client работа с фабриками для создания продуктов 
class FurnitureStore
{
    private readonly IFurnitureFactory _factory;

    public FurnitureStore(IFurnitureFactory factory) => _factory = factory;

    public void ShowFurniture()
    {
        var chair = _factory.CreateChair();
        var table = _factory.CreateTable();

        chair.SitOn();
        table.PutItem();
    }
}

class Program
{
    static void Main()
    {
        var Store = new FurnitureStore(new FurnitureFactory());
        Store.ShowFurniture();

        var AlternativeStore = new FurnitureStore(new AlternativeFurnitureFactory());
        AlternativeStore.ShowFurniture();
    }
}
