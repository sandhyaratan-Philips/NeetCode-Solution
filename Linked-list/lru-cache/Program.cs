using System;
using System.Collections.Generic;

namespace lru_cache
{
    class node
    {
        public int key { get; set; }
        public int value { get; set; }
        public node(int _key, int _value)
        {
            key = _key;
            value = _value;
        }

        public node next = null;
        public node prv = null;
    }
    class Program
    {
        static int _capacity = 0;
        Dictionary<int, node> valuePairs;
        node left;
        node right;

        public Program(int capacity)
        {
            _capacity = capacity;
            valuePairs = new Dictionary<int, node>();
            left = new node(0, 0); //lru
            right = new node(0, 0); //mru
            left.next = right;
            right.prv = left;
        }

        void remove(node node)
        {
            node nxt = node.next;
            node prv = node.prv;
            prv.next = nxt;
            nxt.prv = prv;
        }

        void insert(node node)
        {
            node nxt = right;
            node prv = right.prv;
            prv.next = nxt.prv = node;
            node.next = nxt;
            node.prv = prv;

        }

        public int Get(int key)
        {
            if (valuePairs.ContainsKey(key))
            {
                remove(valuePairs[key]);
                insert(valuePairs[key]);
                return valuePairs[key].value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (valuePairs.ContainsKey(key))
            {
                remove(valuePairs[key]);
            }
            valuePairs[key] = new node(key, value);
            insert(valuePairs[key]);

            if (valuePairs.Count > _capacity)
            {
                node lru = left.next;
                remove(lru);
                valuePairs.Remove(lru.key);

            }
        }
        static void Main(string[] args)
        {
            Program obj = new Program(2);
            obj.Put(1, 1);
            obj.Put(2, 2);
            Console.WriteLine("get: " + obj.Get(1));
            obj.Put(3, 3);
            Console.WriteLine("get: " + obj.Get(2));

            //Console.WriteLine("Hello World!");
        }
    }
}
