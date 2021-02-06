using System;

namespace Codecool.KitchenManagement.Employees
{
    public class Cook : CookingEmployee
    {
        public Cook(string name, DateTime birthDate, int salary) 
            : base(name, birthDate, salary)
        {
            HasKnife = false;
            OnUpdate();
        }
        
        protected sealed override void OnUpdate()
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