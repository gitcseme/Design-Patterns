using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern
{
    public class TaxVisitor : IVisitor
    {
        public double visit(HardFood hardFood)
        {
            return hardFood.getPrice() + hardFood.getPrice() * 0.10;
        }

        public double visit(Tobacco tobacco)
        {
            return tobacco.getPrice() + tobacco.getPrice() * 0.50;
        }

        public double visit(Chocolate chocolate)
        {
            return chocolate.getPrice() + chocolate.getPrice() * 0.30;
        }
    }
}
