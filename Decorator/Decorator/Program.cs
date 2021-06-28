using System;

namespace Decorator
{

    public abstract class Component<T>
    {
        public abstract T Operation();
    }

    public class ConcreteComponent : Component<string>
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    public abstract class Decorator : Component<string>
    {
        protected Component<string> _component;

        public Decorator(Component<string> component)
        {
            this._component = component;
        }

        public void SetComponent(Component<string> component)
        {
            this._component = component;
        }

        // The Decorator delegates all work to the wrapped component.
        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component<string> comp) : base(comp) {}

        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component<string> comp) : base(comp) {}

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }


    public class Client
    {
     
        public void ClientCode(Component<string> component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            var simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(simple);
            Console.WriteLine();

            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got a decorated component:");
            client.ClientCode(decorator2);
        }
    }
    
}
