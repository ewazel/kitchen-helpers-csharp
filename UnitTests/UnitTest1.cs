using System;
using Codecool.KitchenManagement.Equipment;
using KitchenManagement.Employees;
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
                if (helper.hasIngredient(ingredient))
                {
                    result = helper.TryToGiveIngredient(ingredient);
                    validHelper = true;
                }
            }
            
            Assert.AreEqual(true, result);
        }
    }
}