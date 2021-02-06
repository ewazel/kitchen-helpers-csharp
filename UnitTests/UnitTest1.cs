using System;
using Codecool.KitchenManagement;
using Codecool.KitchenManagement.Employees;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TryToGiveIngredient_WhenHelperHasIngredient_ReturnsTrue()
        {
            bool validHelper = false;
            Ingredient ingredient = Ingredient.Carrot;
            bool result = false;

            while (!validHelper)
            {
                KitchenHelper helper = new KitchenHelper(null, DateTime.Today, 0);
                if (helper.HasIngredient(ingredient))
                {
                    result = helper.TryToGiveIngredient(ingredient);
                    validHelper = true;
                }
            }
            
            Assert.AreEqual(true, result);
        }
    }
}