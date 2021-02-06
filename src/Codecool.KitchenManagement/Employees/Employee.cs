using System;

namespace KitchenManagement.Employees
{
    public abstract class Employee
    {
        public string Name { get; }
        public DateTime BirthDate { get; }
        public int Salary { get; }
        
        public Employee(string name, DateTime birthDate, int salary)
        {
            Name = name;
            BirthDate = birthDate;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{Name}, born {BirthDate}, salary: {Salary}";
        }

        public double Tax()
        {
            return 0.99 * Salary;
        }
        
        public void Shout(string text)
        {
            Console.WriteLine(text);
        }

        protected abstract void OnUpdate();
    }
}