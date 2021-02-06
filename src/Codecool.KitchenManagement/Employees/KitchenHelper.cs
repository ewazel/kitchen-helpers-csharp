using System;
using System.Collections.Generic;

namespace Codecool.KitchenManagement.Employees
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
        
        
        public KitchenHelper(string name, DateTime birthDate, int salary) 
            : base(name, birthDate, salary)
        {
            OnUpdate();
        }
        
        protected sealed override void OnUpdate()
        {
            foreach (var key in _bucketOfIngredients.Keys)
            {
                TakeIngredients(key);
            }
        }

        private void TakeIngredients(Ingredient key)
        {
            const int maxAmount = 3;
            int currentAmount = _bucketOfIngredients[key];
            if (_bucketOfIngredients[key] < maxAmount)
            {
                _bucketOfIngredients[key] = Util.RandomInt(0, maxAmount - currentAmount + 1);
            }
        }

        /// <summary>
        /// useful while testing
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        public bool HasIngredient(Ingredient ingredient)
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