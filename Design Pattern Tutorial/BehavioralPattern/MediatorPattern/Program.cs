using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatorPattern
{
    public class Person
    {
        public string Name { get; set; }
        private List<string> chatLog = new List<string>();
        public ChatRoom Room;

        public Person(string Name, ChatRoom Room)
        {
            this.Name = Name;
            this.Room = Room;
        }

        public void Say(string Message) // Brodcast
        {
            Room.Broadcast(this.Name, Message);
        }

        public void PrivateMessage(string Receiver, string Message)
        {
            Room.PrivateMessage(this.Name, Receiver, Message);
        }

        public void Receive(string Sender, string Message)
        {
            string s = $"{Sender}: '{Message}'";
            chatLog.Add(s);
            Console.WriteLine($"[{this.Name}'s chat session] {s}");
        }
    }

    public class ChatRoom
    {
        private List<Person> people = new List<Person>();

        public void Join(Person person)
        {
            string joinMsg = $"{person.Name} join the chat";
            Broadcast("Room", joinMsg);
            people.Add(person);
        }

        public void Broadcast(string Source, string Message)
        {
            foreach (var person in people)
            {
                if (person.Name != Source)
                    person.Receive(Source, Message);
            }
        }

        public void PrivateMessage(string Source, string Destination, string message)
        {
            people.FirstOrDefault(p => p.Name == Destination)?.Receive(Source, message);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ChatRoom room = new ChatRoom();

            var jhon = new Person("Jhon", room);
            room.Join(jhon);
            var popy = new Person("Popy", room);
            room.Join(popy);

            jhon.Say("Hi");
            popy.Say("Oh, hey jhon");

            var simon = new Person("Simon", room);
            room.Join(simon);
            simon.Say("Hey every one!");

            popy.PrivateMessage("Simon", "Love u Simy (-_-)");
        }
    }
}
