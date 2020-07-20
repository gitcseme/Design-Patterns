using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorPattern
{
    public interface IVisitor
    {
        double visit(HardFood hardFood);
        double visit(Tobacco tobacco);
        double visit(Chocolate chocolate);
    }
}
