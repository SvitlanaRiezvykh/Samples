using System.Collections.Generic;
using System.Xml.Linq;

namespace EmployeeManagament.Helpers
{
    public class XElementBuilder
    {
        private readonly List<XElement> Content;

        public XElementBuilder()
        {
            Content = new List<XElement>();
        }

        public XElementBuilder AddNodeIfNotEmpty(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Content.Add(new XElement(name, value));
            }

            return this;
        }
        
        public List<XElement> Build()
        {
            return Content;
        }
    }
}
