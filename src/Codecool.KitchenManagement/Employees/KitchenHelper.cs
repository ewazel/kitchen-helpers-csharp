using System;
using System.Collections.Generic;
using Codecool.KitchenManagement.Equipment;

namespace KitchenManagement.Employees
{
    public class KitchenHelper : Employee
    {
        private Dictionary<Ingredient, int> _bucketOfIngredients =
            new Dictionary<Ingredient, int>()
            {
                {Ingredient.Meat, 0},
                {Ingredient.Potato, 0},
                {Ingredient.Carrot, 0},
            };
        
        
        public KitchenHelper(string name, DateTime birthDate, int salary, Kitchen kitchen) 
            : base(name, birthDate, salary, kitchen)
        {
            OnUpdate();
        }
        
        protected override void OnUpdate()
        {
            foreach (var key in _bucketOfIngredients.Keys)
            {
                TakeIngredients(key);
            }
        }

        private void TakeIngredients(Ingredient key)
        {
            int maxAmount = 3;
            Random random = new Random();
            // TODO: add ingredient!
            _bucketOfIngredients[key] = random.Next(maxAmount + 1);
            
            //TODO: to test: randomInt.cs to generate number within given limits
        }

        /// <summary>
        /// useful while testing
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public bool hasIngredient(Ingredient ingredient)
        {
            if (_bucketOfIngredients.ContainsKey(ingredient))
            {
                return _bucketOfIngredients[ingredient] > 0;
            }

            return false;
        }

        public bool TryToGiveIngredient(Ingredient ingredient)
        {
            if (_bucketOfIngredients[ingredient] > 0)
            {
                _bucketOfIngredients[ingredient]--;
                return true;
            }
            return false;
        }
    }
}