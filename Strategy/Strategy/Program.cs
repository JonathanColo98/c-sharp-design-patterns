using System;
using System.Collections.Generic;

namespace Strategy
{
    public class Context
    {
        private IStrategy<object> _strategy;

        public Context() { }

        public Context(IStrategy<object> strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy<object> strategy)
        {
            this._strategy = strategy;
        }

        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
            object result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

            string resultStr = string.Empty;
            foreach (object element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }

    public interface IStrategy<T>
    {
        public T DoAlgorithm(T data);
    }

    class ConcreteStrategyA : IStrategy<object>
    {
        public object DoAlgorithm(object data)
        {
            List<string> list = data as List<string>;
            list.Sort();

            return list;
        }
    }

    class ConcreteStrategyB : IStrategy<object>
    {
        public object DoAlgorithm(object data)
        {
            List<string> list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
    }
}
