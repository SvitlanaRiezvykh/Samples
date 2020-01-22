using System;
using System.ServiceModel.Web;
using EmployeeManagament.Services;

namespace EmployeeManagamentHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/EmployeeManagament/");

            Console.WriteLine("Service is hosted at: " + baseAddress.AbsoluteUri);

            using (WebServiceHost host = new WebServiceHost(typeof(EmployeeService), baseAddress))
            {
                host.Open();

                Console.WriteLine("Press any key to terminate");
                Console.ReadLine();
            }
        }
    }
}
