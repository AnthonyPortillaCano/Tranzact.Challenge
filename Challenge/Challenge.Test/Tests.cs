using AutoMapper;
using Challenge.Data.Context;
using Challenge.Data.Interfaces;
using Challenge.Data.Models;
using Challenge.Data.Repositories;
using Challenge.External.Interfaces;
using Challenge.Services.Implementations;
using Challenge.Services.Interfaces;
using Challenge.Services.Models;
using Challenge.WebApi.Controllers;
using Challenge.WebApi.Models;
using Moq;
using Xunit;

namespace Challenge.Test
{
    public class Tests
    {
      

        [Fact]
        public void GetProductByIdTest()
        {
            //Arrange
            var mockRepo = new Mock<IMapper>();
            var productMock = new Mock<IProductService>();
            var controller = new ProductController(mockRepo.Object, productMock.Object);

            //Act
            var result = controller.GetById(1);

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void InsertProductRepository()
        {
            StoreDatabaseContext _storeDatabaseContext=new StoreDatabaseContext();
           var productRepository = new ProductRepository(_storeDatabaseContext);
            var product = new Product
            {
                Code = "TEST1",
                ProductTypeId = 1,
                State=1,
               ProductDetail=new ProductDetail{ Description="PruebaTest",Observations="ObservacionTest"}
            };
            var result= productRepository.InsertProduct(product);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void InsertProduct()
        {
            //Arrange
            var mockRepo = new Mock<IMapper>();
            var productMock = new Mock<IProductService>();
            var controller = new ProductController(mockRepo.Object, productMock.Object);

            var obj = new ProductInsertRequest
            {
                Code = "TEST1",
                Description = "Test1",
                ExpirationDate = new System.DateTime(),
                Observations = "Test1",
                ProductTypeId = 1
            };
        
            //Act
            var result = controller.Insert(obj);

            //Assert
            Assert.NotNull( result);
        }

         [Fact]
        public void UpdateProduct()
        {
            //Arrange
            var mockRepo = new Mock<IMapper>();
            var productMock = new Mock<IProductService>();
            var controller = new ProductController(mockRepo.Object, productMock.Object);

            var obj = new ProductUpdateRequest
            {
                ProductId = 1,
                State = 1,
                Code = "TEST2",
                Description = "Test2",
                ExpirationDate = new System.DateTime(),
                Observations = "Test2",
                ProductTypeId = 2
            };

            //Act
            var result = controller.Update(obj);

            //Assert
            Assert.NotNull(result);
        }
    }
}