using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using UnikPedel.Domain.DomainServices;
using Xunit;

namespace UnikPedel.Domain.Test
{
    public class ViceværtTest
    {
        private readonly IServiceProvider _serviceProvider;

        public ViceværtTest()
        {
            var exsistingBookings = new List<Entities.Vicevaert>(new[]
         {
            new Entities.Vicevaert(1, "Karl","Karlsen",60918171,"karlkarlsen@gmail.com"),
            new Entities.Vicevaert( 2,"Test","Testen",136734352,"testtestenn@gmail.com")
        });
            var bookingDomainServiceMock = new Mock<IVicevaertDomainService>();
            bookingDomainServiceMock.Setup(foo => foo.GetExsistingVicevaerter()).Returns(exsistingBookings);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(_ => bookingDomainServiceMock.Object);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }


        // checker om man får den forventede exception hvis Telefon nummer er udfyldt
        [Fact]
        public void Given_Telefon_Is_Default_Value__Then_ArgumentOutOfRangeException_Is_Thrown()
        {
            // Arrange
            
            var navn = "John";
            var efternavn = "Doe";
            var email = "test@ok.com";
            var expected = "Telefon nummer skal være udfyldt (Parameter 'telefon')";
            var _Serviceprovider = _serviceProvider;

            // Act
            Action action = () => new Entities.Vicevaert(_Serviceprovider, navn,efternavn,default,email);

            //Assert
            var caughtException = Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.Equal(expected, caughtException.Message);
        }


        // checker om man får den forventede exception hvis Emsil nummer er udfyldt
        [Fact]
       
        public void Given_Email_Is_Default_Value__Then_ArgumentOutOfRangeException_Is_Thrown()
        {
            // Arrange
            var navn = "John";
            var efternavn = "Doe";
            var telefon = 90809020;
            var expected = "Email skal være udfyldt (Parameter 'email')";
            var _Serviceprovider = _serviceProvider;

            // Act
            Action action = () => new Entities.Vicevaert(_Serviceprovider, navn, efternavn, telefon, default);

            //Assert
            var caughtException = Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.Equal(expected, caughtException.Message);
        }


            [Fact]
        //"Test","Testen",136734352,"testtestenn@gmail.com"
        public void Given_Email_Is_Samme__Then_Exception_Is_Thrown()     
        {
            // Arrange
            var ForNavn = "Robert";
            var efternavn = "Robertson";
            var telefon = 1636276; 
            var email = "testtestenn@gmail.com";
            var expected = "Der findes en vicevært med det sammen Telefon nummer eller Email";
            var _ServiceProvider=_serviceProvider;
            // Act
            Action action = () => new Entities.Vicevaert(_ServiceProvider,ForNavn,efternavn,telefon,email);

            //Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Equal(expected, caughtException.Message);
        }

        [Fact]
       //  "Karl","Karlsen",60918171,"karlkarlsen@gmail.com"
        public void Given_Telefon_Is_Samme__Then_Exception_Is_Thrown()
        {
            // Arrange
            var ForNavn = "Kasper";
            var efternavn = "Kasperson";
            var telefon = 60918171;
            var email = "kasperson<2gmai.com";
            var expected = "Der findes en vicevært med det sammen Telefon nummer eller Email";
            var _ServiceProvider = _serviceProvider;
            // Act
            Action action = () => new Entities.Vicevaert(_ServiceProvider, ForNavn, efternavn, telefon, email);

            //Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Equal(expected, caughtException.Message);
        }











    }
}
