using System;

namespace IkMeKursaDarbs
{
    public class ConstraintAttribute : Attribute
    {
        public string Constraint { get; set; }
        public string DataType { get; set; }
        public ConstraintAttribute(string constraint, string dataType = null)
        {
            this.Constraint = constraint;
            this.DataType = dataType;
        }
    }
}