using System;

namespace ChainOfResponsibilityPattern
{
    public class Creature
    {
        public string Name;
        public int Attack, Defence;
        public Creature(string Name, int Attack, int Defence)
        {
            this.Name = Name;
            this.Attack = Attack;
            this.Defence = Defence;
        }

        public override string ToString()
        {
            return $"Name {Name}, Attack {Attack}, Defence {Defence}";
        }
    }

    public class CreatureModifier
    {
        protected Creature creature;
        protected CreatureModifier next;

        public CreatureModifier(Creature creature)
        {
            this.creature = creature;
        }

        public void Add(CreatureModifier cm) // Creating the chain.
        {
            if (next != null) next.Add(cm);
            else next = cm;
        }

        public virtual void Handle()
        {
            next?.Handle();
        }
    }

    public class AttackModifier : CreatureModifier
    {
        public AttackModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Doubling {creature.Name}'s attack");
            creature.Attack *= 2;
            base.Handle();
        }
    }

    public class DefenceModifier : CreatureModifier
    {
        public DefenceModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Increasing {creature.Name}'s defence");
            creature.Defence += 3;
            base.Handle();
        }
    }

    public class NoModifierSpell : CreatureModifier
    {
        public NoModifierSpell(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine("Modification is turned off by a curse spell.");
            // Do nothing.
        }
    }

    class Demo1
    {
        static void Main(string[] args)
        {
            var goblin = new Creature("Goblin", 2, 2);
            Console.WriteLine(goblin);

            var root = new CreatureModifier(goblin);
            root.Add(new NoModifierSpell(goblin));    // Stops modification on creature.

            root.Add(new AttackModifier(goblin));
            root.Add(new DefenceModifier(goblin));

            root.Handle();

            Console.WriteLine(goblin);
        }
    }
}
