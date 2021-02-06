using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.KitchenManagement;
using Codecool.KitchenManagement.Equipment;

namespace KitchenManagement.Employees
{
    public class Chef : CookingEmployee
    {
        public static Chef Singleton { get; private set; }
        
        private Kitchen Kitchen;

        private bool _isCooking;

        public Chef(string name, DateTime birthDate, int salary, Kitchen kitchen) 
            : base(name, birthDate, salary)
        {
            Singleton = this;
            HasKnife = true;
            OnUpdate();
            Kitchen = kitchen;
        }
        
        protected sealed override void OnUpdate()
        {
            _isCooking = Util.RandomBool();
            if (_isCooking)
            {
                RequestIngredients();
            }
            else
            {
                Shout("GRRRRR!");
            }
            
        }

        private void RequestIngredients()
        {
            Ingredient ingredient = ChooseIngredient();
            List<Employee> listOfHelpers = Kitchen.GetAllEmployees<KitchenHelper>();
            
            bool gotIngredient = listOfHelpers.Any(employee => GetIngredient((KitchenHelper) employee, ingredient));

            if (!gotIngredient)
            {
                foreach (var employee in listOfHelpers)
                {
                    employee.Shout("We're all out");
                }
            }
        }

        private Ingredient ChooseIngredient()
        {
            Array values = Enum.GetValues(typeof(Ingredient));
            return (Ingredient)values.GetValue(Util.RandomInt(0, values.Length));
        }

        private bool GetIngredient(KitchenHelper helper, Ingredient ingredient)
        {
            return helper.TryToGiveIngredient(ingredient);
        }
    }
}