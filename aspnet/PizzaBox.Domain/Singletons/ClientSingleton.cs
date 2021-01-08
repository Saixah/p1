using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using System;
using System.Linq;

namespace PizzaBox.Domain.Singleton
{
    public class ClientSingleton
    {
        private static ClientSingleton _instance;
        private const string path = @"pizzaworld.xml";

        public static ClientSingleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ClientSingleton();
                }

                return _instance;
            }
        }

        public List<Store> Stores { get; set; }

        public ClientSingleton()
        {
            Read();
        }

        public void MakeAStore()
        {
            Stores.Add(new Store());
            Save();
        }

        private void Save()
        {
            var file = new StreamWriter(path);
            var xml = new XmlSerializer(typeof(List<Store>));

            xml.Serialize(file,Stores);
        }

        public void Read()
        {
            if (File.Exists(path))
            {
                var file = new StreamReader(path);
                var xml = new XmlSerializer(typeof(List<Store>));

                Stores = xml.Deserialize(file) as List<Store>;

            }
            else
            {
                Stores = new List<Store>();
            }
        }

        public void DisplayStores()
        {
            foreach(Store store in Stores)
            {
                Console.WriteLine(store.ToString());
            }
        }

        public Store SelectStore()
        {
            int.TryParse(Console.ReadLine(),out int input);
            return Stores.ElementAtOrDefault(input);
        }
    }
}
