using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.DomainServices;
using Xunit;

namespace UnikPedel.Domain.Test.BookingTest
{
    public class BookingEditTest
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly List<Entities.Booking> _exsistingBookings;

        public BookingEditTest()
        {
            _exsistingBookings = new List<Entities.Booking>(new[]
            {
            new Entities.Booking(1, new DateTime(2022, 1, 1, 10, 0, 0), new DateTime(2022, 1, 1, 11, 0, 0),1,2),
            new Entities.Booking(2, new DateTime(2022, 1, 1, 14, 0, 0), new DateTime(2022, 1, 1, 15, 0, 0),1,2)
        });
            var bookingDomainServiceMock = new Mock<IBookingDomainService>();
            bookingDomainServiceMock.Setup(foo => foo.GetExsistingBookings()).Returns(_exsistingBookings);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(_ => bookingDomainServiceMock.Object);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        [Theory]
        [InlineData("2022-1-1 08:00", "2022-1-1 09:00",1)]
        public void Given_No_Overlap_And_Edit__Then_Booking_Is_Created(string startStr, string slutStr, int lejemålId)
        {
            // Arrange
            var start = DateTime.Parse(startStr);
            var slut = DateTime.Parse(slutStr);
            var LejemålId = lejemålId;
            var booking = _exsistingBookings[0];
            booking._serviceProvider = _serviceProvider;

            // Act
            booking.Update(start, slut,LejemålId);

            //Assert
            Assert.NotNull(booking);
        }

        [Fact]
        public void Given_Start_Is_Default_Value__Then_ArgumentOutOfRangeException_Is_Thrown()
        {
            // Arrange
            var expected = "Start dato skal være udfyldt (Parameter 'startTid')";
            var booking = _exsistingBookings[0];
            booking._serviceProvider = _serviceProvider;

            // Act
            Action action = () => booking.Update(default, booking.SlutTid,booking.LejemaalId);

            //Assert
            var caughtException = Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.Equal(expected, caughtException.Message);
        }

        [Fact]
        public void Given_Slut_Is_Default_Value__Then_ArgumentOutOfRangeException_Is_Thrown()
        {
            // Arrange
            var expected = "Slut dato skal være udfyldt (Parameter 'slutTid')";
            var booking = _exsistingBookings[0];
            booking._serviceProvider = _serviceProvider;

            // Act
            Action action = () => booking.Update(booking.StartTid, default,booking.LejemaalId);

            //Assert
            var caughtException = Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.Equal(expected, caughtException.Message);
        }

        [Theory]
        [InlineData("2022-1-1 08:00", "2022-1-1 07:59",1)]
        [InlineData("2022-1-1 08:00", "2022-1-1 08:00",1)]
        public void Given_Slut_Is_Not_After_Start__Then_Exception_Is_Thrown(string startStr, string slutStr, int lejemålId)
        {
            // Arrange
            var start = DateTime.Parse(startStr);
            var slut = DateTime.Parse(slutStr);
            var expected = $"Slut dato/tid skal være senere end start (start, slut): {start}, {slut}";
            var booking = _exsistingBookings[0];
            booking._serviceProvider = _serviceProvider;

            // Act
            Action action = () => booking.Update(start, slut,lejemålId);

            //Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Equal(expected, caughtException.Message);
        }
    }
}
