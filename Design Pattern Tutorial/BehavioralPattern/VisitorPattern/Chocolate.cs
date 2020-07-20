namespace VisitorPattern
{
    public class Chocolate : IVisitable
    {
        private double price;
        public Chocolate(double price)
        {
            this.price = price;
        }

        public double accept(IVisitor visitor)
        {
            return visitor.visit(this);
        }

        public double getPrice() => price;
    }
}