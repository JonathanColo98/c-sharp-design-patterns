using System;
using System.Collections.Generic;

namespace Visitor
{
    public interface IComponent
    {
        public void Accept(IVisitor visitor);
    }

    public class ConcreteComponent1 : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteComponentA(this);
        }

        public string MethodConcreteComponentA()
        {
            return "A";
        }
    }

    public class ConcreteComponent2 : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteComponentB(this);
        }

        public string MethodConcreteComponentB()
        {
            return "B";
        }
    }

    public interface IVisitor
    {
        public void VisitConcreteComponentA(ConcreteComponent1 element);

        public void VisitConcreteComponentB(ConcreteComponent2 element);
    }

    public class ConcreteVisitorA : IVisitor
    {
        public void VisitConcreteComponentA(ConcreteComponent1 element)
        {
            Console.WriteLine(element.MethodConcreteComponentA() + " + ConcreteVisitor1");
        }

        public void VisitConcreteComponentB(ConcreteComponent2 element)
        {
            Console.WriteLine(element.MethodConcreteComponentB() + " + ConcreteVisitor1");
        }
    }

    public class ConcreteVisitorB : IVisitor
    {
        public void VisitConcreteComponentA(ConcreteComponent1 element)
        {
            Console.WriteLine(element.MethodConcreteComponentA() + " + ConcreteVisitor2");
        }

        public void VisitConcreteComponentB(ConcreteComponent2 element)
        {
            Console.WriteLine(element.MethodConcreteComponentB() + " + ConcreteVisitor2");
        }
    }
    public class Client
    {
        public static void ClientCode(List<IComponent> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IComponent> components = new List<IComponent>
            {
                new ConcreteComponent1(),
                new ConcreteComponent2()
            };

            Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
            var visitor1 = new ConcreteVisitorA();
            Client.ClientCode(components, visitor1);

            Console.WriteLine();

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            var visitor2 = new ConcreteVisitorB();
            Client.ClientCode(components, visitor2);
        }
    }
}
