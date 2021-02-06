using System;
using Codecool.KitchenManagement;

namespace KitchenManagement.Employees
{
    public class Cook : CookingEmployee
    {
        public Cook(string name, DateTime birthDate, int salary) 
            : base(name, birthDate, salary)
        {
            HasKnife = false;
        }
        
        protected override void OnUpdate()
        {
            if (HasKnife)
            {
                Shout("I'm cooking!");
            }
            else
            {
                HasKnife = Util.RandomBool();
            }
        }

    }
}