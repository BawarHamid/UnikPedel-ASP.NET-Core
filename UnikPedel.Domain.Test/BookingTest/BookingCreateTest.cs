using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using UnikPedel.Domain.DomainServices;
using Xunit;

namespace UnikPedel.Domain.Test
{
    public class BookingCreateTests
    {
        private readonly IServiceProvider _serviceProvider;

        // laver man liste af bookinger 
        public BookingCreateTests()
        {
            var exsistingBookings = new List<Entities.Booking>(new[]
            {
            new Entities.Booking(1, new DateTime(2022, 1, 1, 10, 0, 0), new DateTime(2022, 1, 1, 11, 0, 0),1,2 ),
            new Entities.Booking(2, new DateTime(2022, 1, 1, 14, 0, 0), new DateTime(2022, 1, 1, 15, 0, 0),1,2)
        });
            var bookingDomainServiceMock = new Mock<IBookingDomainService>();
            bookingDomainServiceMock.Setup(foo => foo.GetExsistingBookings()).Returns(exsistingBookings);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(_ => bookingDomainServiceMock.Object);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        // checker om man får den forventede exception hvis starttid er ikke udfyldt
        [Fact]
        public void Given_Start_Is_Default_Value__Then_ArgumentOutOfRangeException_Is_Thrown()
        {
            // Arrange
            var slut = DateTime.Parse("2022-1-1 09:00");
            var expected = "Start dato skal være udfyldt (Parameter 'startTid')";

            // Act
            Action action = () => new Entities.Booking(_serviceProvider, default, slut, 1, 2);

            //Assert
            var caughtException = Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.Equal(expected, caughtException.Message);
        }

        // checker om man får den forventede exception hvis slutTid er ikke udfyldt
        [Fact]
        public void Given_Slut_Is_Default_Value__Then_ArgumentOutOfRangeException_Is_Thrown()
        {
            // Arrange
            var start = DateTime.Parse("2022-1-1 08:00");
            var expected = "Slut dato skal være udfyldt (Parameter 'slutTid')";

            // Act
            Action action = () => new Entities.Booking(_serviceProvider, start, default, 1, 2);

            //Assert
            var caughtException = Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.Equal(expected, caughtException.Message);
        }

        // checker om sluttuid er støre end start tid og vi får den forventede exception
        [Theory]
        [InlineData("2022-1-1 08:00", "2022-1-1 07:59")]
        [InlineData("2022-1-1 08:00", "2022-1-1 08:00")]
        public void Given_Slut_Is_Not_After_Start__Then_Exception_Is_Thrown(string startStr, string slutStr)
        {
            // Arrange
            var start = DateTime.Parse(startStr);
            var slut = DateTime.Parse(slutStr);
            var expected = $"Slut dato/tid skal være senere end start (start, slut): {start}, {slut}";

            // Act
            Action action = () => new Entities.Booking(_serviceProvider, start, slut, 1, 2);

            //Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Equal(expected, caughtException.Message);
        }
    }
}