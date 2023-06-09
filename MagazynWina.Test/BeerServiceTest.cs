﻿using MagazynWina.App;
using MagazynWina.App.AbstractInteface;
using MagazynWina.App.Concrete;
using MagazynWina.App.Manager;
using MagazynWina.Domain.Model;
using FluentAssertions;
using Moq;
using Xunit;

namespace MagazynWina.Tests
{
    public class BeerServiceTest
    {
        [Fact]
        public void AddNewBeer_ProvidingAddNewBeerComplete_AddingNewBeer()
        {
            //Arrange
            var service = new BeerService();
            Beer beer = GenerateNewBeerForTest();
            //Act
            var returnedBeer = service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Assert
            Assert.Equal(beer.Id, returnedBeer.Id);
        }

        [Fact]
        public void TestBeerRemoveById_ProvidingRemoveByIdCompleted_TestBeerRemoveByID()
        {
            //Arrange
            var service = new BeerService();
            Beer beer = GenerateNewBeerForTest();
            service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Act
            service.DeleteBeerFromList(beer.Id);
            //Assert
            var returnedBeer = service.GetBeerDetailsById(beer.Id);
            returnedBeer.Should().BeNull();
        }

        [Fact]
        public void TestUpdatesOBeerDetailsById_ProviddingUpdatesBeerDetails_UpdatesBeerDetails()
        {
            //Arrange
            var service = new BeerService();
            Beer beer = GenerateNewBeerForTest();
            service.AddNewBeerToList(beer.Id+1, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Act
            var beerId = service.UpdateBeer(beer.Id, beer.Name, 5, 10);
            //Assert
            var returnedBeer = service.GetBeerDetailsById(beerId);
            returnedBeer.Quantity.Should().Be(10);
            returnedBeer.Blg.Should().Be(5);
        }

        [Fact]
        public void TestBeerDetailsById_ProviddingBeerShowsDetailsById_ShowingBeerDetailsById()
        {
            //Arrange
            var service = new BeerService();
            Beer beer = GenerateNewBeerForTest();
            service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Act2
            var returnedBeer = service.GetBeerDetailsById(beer.Id);
            //Assert
            returnedBeer.Id.Should().Be(beer.Id);
            returnedBeer.Quantity.Should().Be(beer.Quantity);
            returnedBeer.Blg.Should().Be(beer.Blg);
        }

        [Fact]
        public void TestBeerDetailsById_ProviddingBeerDontShowsDetailsById_DontShowingBeerDetailsById()
        {
            //Arrange
            var service = new BeerService();
            int id = 10;
            //Act
            var returnedBeer = service.GetBeerDetailsById(id);
            //Assert
            returnedBeer.Should().BeNull();
        }

        [Fact]
        public void TestGetAllBeersObject_ProviddingGetAllBeersObjects_GetAllBeersObjects()
        {
            //Arrange
            Beer beerTest1 = GenerateNewBeerForTest();
            var service = new BeerService();
            service.AddNewBeerToList(beerTest1.Id, beerTest1.Name, beerTest1.Blg, beerTest1.YearProduction, beerTest1.Quantity, beerTest1.Yeast, beerTest1.TypeOfBeer);
            service.AddNewBeerToList(beerTest1.Id, beerTest1.Name, beerTest1.Blg, beerTest1.YearProduction, beerTest1.Quantity, beerTest1.Yeast, beerTest1.TypeOfBeer);
            //Act
            int id = service.GetAllBeerObjects();
            //Assert
            id.Should().BeGreaterThan(0);
        }

        [Fact]
        public void TestGetNotAllBeersObject_ProviddingGetNoOneBeerObjects_GetNoOneBeerObjects()
        {
            //Arrange
            var service = new BeerService();
            //Act
            int id = service.GetAllBeerObjects();
            //Assert
            id.Should().Be(0);
        }

        [Fact]
        public void TestNewBeerId_ProviddingAddNewBeerWithNewId_AddingDifferentIdForNewBeers()
        {
            //Arrange
            var service = new BeerService();
            Beer beerTest1 = GenerateNewBeerForTest();
            service.AddNewBeerToList(beerTest1.Id, beerTest1.Name, beerTest1.Blg, beerTest1.YearProduction, beerTest1.Quantity, beerTest1.Yeast, beerTest1.TypeOfBeer);
            service.AddNewBeerToList(beerTest1.Id, beerTest1.Name, beerTest1.Blg, beerTest1.YearProduction, beerTest1.Quantity, beerTest1.Yeast, beerTest1.TypeOfBeer);
            //Act
            var returnedBeer = service.GetBeerDetailsById(beerTest1.Id);
            var returnedBeer2 = service.GetBeerDetailsById(beerTest1.Id+ 1);
            //Assert
            returnedBeer.Id.Should().Be(beerTest1.Id);
            returnedBeer2.Id.Should().NotBe(beerTest1.Id);
            returnedBeer2.Id.Should().Be(2);
            returnedBeer2.Id.Should().BeGreaterThan(returnedBeer.Id);
        }

        private Beer GenerateNewBeerForTest()
        {
            Beer beer = new Beer(1, "nameTest", 0, 0, 0, "yeast", "PaleAle");
            return beer;
        }
    }
}
