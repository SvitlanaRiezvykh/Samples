using System.Xml.Linq;

namespace EmployeeManagament.Helpers
{
    public static class XElementExtension
    {
        public static void SetValueIfNotEmpty(this XElement element, string elementName, string valueToSet)
        {
            if (!string.IsNullOrEmpty(valueToSet))
            {
                element.SetElementValue(elementName, valueToSet);
            }
        }
    }
}
