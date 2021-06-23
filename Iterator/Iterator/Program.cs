using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterator
{
    public abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => this.Current();

        // Ritorna la chiave dell'elemento corrente
        public abstract int Key();

        // Ritorna l'elemento corrente
        public abstract object Current();

        // Prosegue verso il prossimo elemento
        public abstract bool MoveNext();

        // Resetta l'iteratore al primo elemento
        public abstract void Reset();
    }

    public abstract class IteratorAggregate : IEnumerable
    {
        // Ritorna un iteratore
        public abstract IEnumerator GetEnumerator();
    }

    public class AlphabeticalOrderIterator : Iterator
    {
        private WordsCollection _collection;
        private int _position = -1;
        private bool _reverse = false;

        public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
        {
            this._collection = collection;
            this._reverse = reverse;

            if (reverse)
            {
                this._position = collection.GetItems().Count;
            }
        }

        public override object Current()
        {
            return this._collection.GetItems()[_position];
        }

        public override int Key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < this._collection.GetItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position = this._reverse ? this._collection.GetItems().Count - 1 : 0;
        }
    }

    public class WordsCollection : IteratorAggregate
    {
        private List<string> _collection = new List<string>();
        private bool _direction = false;

        public void ReverseDirection()
        {
            this._direction = !_direction;
        }
        public List<string> GetItems()
        {
            return this._collection;
        }

        public void AddItem(string item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new AlphabeticalOrderIterator(this, _direction);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WordsCollection collection = new WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("Straight traversal:");

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nReverse traversal:");

            collection.ReverseDirection();

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }
    }
}
