using System;

namespace KitchenManagement.Employees
{
    public abstract class CookingEmployee : Employee
    {
        // protected bool hasKnife;
        public CookingEmployee(string name, DateTime birthDate, int salary, Kitchen kitchen) 
            : base(name, birthDate, salary, kitchen)
        {
        }

        // TODO!
        protected override void OnUpdate()
        {
        }

        
    }
}