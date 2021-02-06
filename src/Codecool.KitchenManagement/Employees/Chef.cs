using System;
using System.Linq;
using Codecool.KitchenManagement.Equipment;

namespace KitchenManagement.Employees
{
    public class Chef : CookingEmployee
    {
        Random random = new Random();
        public static Chef Singleton { get; private set; }

        public Chef(string name, DateTime birthDate, int salary, Kitchen kitchen) 
            : base(name, birthDate, salary, kitchen)
        {
            Singleton = this;
            OnUpdate();
        }
        
        protected override void OnUpdate()
        {
            if (IsCooking())
            {
                RequestIngredients();
            }
            else
            {
                Shout("GRRRRR!");
            }
            
        }

        private bool IsCooking()
        {
            return random.Next(0, 2) > 0;
        }

        private void RequestIngredients()
        {
            Ingredient ingredient = ChooseIngredient();
            
            bool gotIngredient = Kitchen.listOfEmployees.Where(employee => employee.GetType() == typeof(KitchenHelper))
                .Any(employee => GetIngredient((KitchenHelper) employee, ingredient));

            if (!gotIngredient)
            {
                foreach (var employee in Kitchen.listOfEmployees.Where(employee => employee.GetType() == typeof(KitchenHelper)))
                {
                    employee.Shout("We're all out");
                }
            }
        }

        private Ingredient ChooseIngredient()
        {
            Array values = Enum.GetValues(typeof(Ingredient));
            return (Ingredient)values.GetValue(random.Next(values.Length));
        }

        private bool GetIngredient(KitchenHelper helper, Ingredient ingredient)
        {
            return helper.TryToGiveIngredient(ingredient);
        }
    }
}