using System;

namespace Bridge
{
    public class Abstraction
    {
        protected IImplementation _implementation;

        public Abstraction(IImplementation implementation)
        {
            this._implementation = implementation;
        }

        public virtual string Operation()
        {
            return "Abstract: Base operation with:\n" + _implementation.Operation();
        }
    }

    public class ExtendAbstraction : Abstraction
    {
        public ExtendAbstraction(IImplementation implementation) : base (implementation)
        {
            
        }

        public override string Operation()
        {
            return "ExtendedAbstraction: extended operation" + base.Operation();
        }
    }

    public interface IImplementation
    {
        public string Operation();
    }

    public class ConcreteImplementation : IImplementation
    {
        public string Operation()
        {
            return "Concrete Implementation: The result in platform\n";
        }
    }

    public class Client
    {
        public void ClientCode(Abstraction abstraction)
        {
            Console.Write(abstraction.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Abstraction abstraction;

            abstraction = new Abstraction(new ConcreteImplementation());
            client.ClientCode(abstraction);

            Console.WriteLine();
        }
    }
}
