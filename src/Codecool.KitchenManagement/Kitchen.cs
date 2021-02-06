using System;
using System.Collections.Generic;

namespace KitchenManagement.Employees
{
    public class Kitchen
    {
        private int amountOfCooks;
        private int amountOfKitchenHelpers;
        
        public  List<Employee> listOfEmployees = new List<Employee>();

        
        public Kitchen(int amountOfCooks, int amountOfKitchenHelpers)
        {
            GenerateEmployee<Chef>(1);
            GenerateEmployee<Cook>(amountOfCooks);
            GenerateEmployee<KitchenHelper>(amountOfKitchenHelpers);
        }
        
        private void GenerateEmployee<T>(int amountOfEmployees)
            where T : Employee
        {
            for (int i = 0; i < amountOfEmployees; i++)
            {
                var employee = Activator.CreateInstance(typeof(T), new object[] { this }) as T;
                listOfEmployees.Add(employee);
            }
        }

        public bool isValid()
        {
            return listOfEmployees.Contains(Chef.Singleton);
        }
        
    }
}