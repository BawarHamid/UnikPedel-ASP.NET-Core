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
    public class BookingOverlapTest
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly List<Entities.Booking> _exsistingBookings;

        public BookingOverlapTest()
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


        // Eksisterende booking: "2022-1-1 10:00" - "2022-1-1 11:00"
        [Theory]
        [InlineData("2022-1-1 08:00", "2022-1-1 10:30","1", "Slut rækker ind i eksisterende booking")]
        [InlineData("2022-1-1 08:00", "2022-1-1 10:00","1", "Slut berører eksisterende booking")]
        [InlineData("2022-1-1 10:30", "2022-1-1 12:00","1", "Start rækker ind i eksisterende booking")]
        [InlineData("2022-1-1 11:00", "2022-1-1 12:00","1", "Start berører eksisterende booking")]
        [InlineData("2022-1-1 10:30", "2022-1-1 10:45","1", "Ny boking ligger inde i eksisterende booking")]
        [InlineData("2022-1-1 09:00", "2022-1-1 12:00","1", "Eksisterende booking ligger inde i ny booking")]
        public void Given_Overlap__Then_IsOverlapping_Is_True(string startStr, string slutStr, string lejemålId, string userMessage)
        {
            // Arrange
            var start = DateTime.Parse(startStr);
            var slut = DateTime.Parse(slutStr);
            var LejemålId = int.Parse(lejemålId);
            var booking = new BookingStub(3, start, slut,LejemålId,2);
            booking._serviceProvider = _serviceProvider;

            // Act
            var actual = booking.IsOverlapping();

            //Assert
            Assert.True(actual, userMessage);
        }


        [Theory]
        [InlineData("2022-1-1 08:00", "2022-1-1 09:00",1)]
        public void Given_No_Overlap_And_Edit__Then_Booking_Is_Created(string startStr, string slutStr,int lejemålId)
        {
            // Arrange
            var start = DateTime.Parse(startStr);
            var slut = DateTime.Parse(slutStr);
             var LejemålId=lejemålId;
            var booking = _exsistingBookings[0];
            booking._serviceProvider = _serviceProvider;

            // Act
            booking.Update(start, slut,LejemålId);

            //Assert
            Assert.NotNull(booking);
        }

        // Eksisterende booking: "2022-1-1 14:00" - "2022-1-1 15:00"
        [Theory]
        [InlineData("2022-1-1 13:39", "2022-1-1 14:30",1,"Slut rækker ind i eksisterende booking")]
        public void Given_Overlap_And_Edit__Then_Booking_Then_Exception_Is_Thrown(string startStr, string slutStr,int lejemålId, string userMessage)
        {
            // Arrange
            var start = DateTime.Parse(startStr);
            var slut = DateTime.Parse(slutStr);
            var LejemålId = lejemålId;    
            var booking = _exsistingBookings[0];
            booking._serviceProvider = _serviceProvider;
            var expected = "Booking overlapper med eksisterende booking";

            // Act
            Action action = () => booking.Update(start, slut,LejemålId);

            //Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.True(expected.Equals(caughtException.Message), userMessage);
        }

        public class BookingStub : Entities.Booking
        {
            public BookingStub(int id, DateTime start, DateTime slut,  int lejemålId, int lejerId) : base(id, start, slut, lejemålId,lejerId)
            {
            }

           

            public new bool IsOverlapping()
            {
                return base.IsOverlapping();
            }
        }
    }
}
