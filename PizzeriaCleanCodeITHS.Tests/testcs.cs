using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using PizzeriaCleacCodeIths.Models;
using Xunit;

namespace PizzeriaCleanCodeITHS.Tests
{
    public class Testcs
    {
        [Theory]
        public void Test(IFixture fixture)
        {
            var x = fixture.Build<OrderRequestModel>()
                .With(c => c.Pizzas, new List<string>()
                {
                    null
                }).Create();

            x.Pizzas.First().Should().BeNull(); 
        }
    }
}
