using System;

namespace VisitorPattern
{
    /**
     * The visitor pattern is used when we have to perform the same action on many objects of different types.
     * The TaxVisitor is allowed to use object of these types. thus it calculates tax based on object type.
     */

    class Program
    {
        static void Main(string[] args)
        {
            TaxVisitor taxVisitor = new TaxVisitor();

            HardFood biskit = new HardFood(20.18);
            Tobacco goldLief = new Tobacco(50.518);
            Chocolate kitkat = new Chocolate(70.958);

            Console.WriteLine("price+tax: " + biskit.accept(taxVisitor));
            Console.WriteLine("price+tax: " + goldLief.accept(taxVisitor));
            Console.WriteLine("price+tax: " + kitkat.accept(taxVisitor));
        }
    }
}
