using System;

namespace Codecool.KitchenManagement.Employees
{
    public abstract class CookingEmployee : Employee
    {
        protected bool HasKnife;
        public CookingEmployee(string name, DateTime birthDate, int salary) 
            : base(name, birthDate, salary)
        {
        }

    }
}