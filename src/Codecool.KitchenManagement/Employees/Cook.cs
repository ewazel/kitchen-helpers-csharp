using System;

namespace KitchenManagement.Employees
{
    public class Cook : CookingEmployee
    {
        public Cook(string name, DateTime birthDate, int salary, Kitchen kitchen) 
            : base(name, birthDate, salary, kitchen)
        {
        }
        
        protected override void OnUpdate()
        {
            // haKnife!
            Shout("I'm cooking!");
        }
    }
}