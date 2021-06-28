using System;

namespace AbstractFactory
{

    public interface IAbstractFactory
    {
        public IAbstractProductA CreateProductA();

        public IAbstractProductB CreateProductB();
    }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    public class ConcreteProductA1 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of the product A1.";
        }
    }

    public class ConcreteProductB1 : IAbstractProductB
    {
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            throw new NotImplementedException();
        }

        public string UsefulFunctionB()
        {
            throw new NotImplementedException();
        }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    public interface IAbstractProductA
    {
        public string UsefulFunctionA();
    }

    public interface IAbstractProductB
    {
        public string UsefulFunctionB();

        public string AnotherUsefulFunctionB(IAbstractProductA collaborator);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
