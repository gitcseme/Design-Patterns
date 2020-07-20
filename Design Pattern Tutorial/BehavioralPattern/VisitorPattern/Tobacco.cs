namespace VisitorPattern
{
    public class Tobacco : IVisitable
    {
        private double price;
        public Tobacco(double price)
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