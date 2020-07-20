namespace VisitorPattern
{
    public class HardFood : IVisitable
    {
        private double price;
        public HardFood(double price)
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