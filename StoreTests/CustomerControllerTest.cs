using Xunit;
using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Moq;
using StoreBL;
using StoreModels;
using MvcStore;
using MvcStore.Controllers;
using MvcStore.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Microsoft.Extensions.Logging.Abstractions;
namespace StoreTests
{
    public class CustomerControllerTest
    {
        [Fact]
        public void CustomerControllerShouldReturnIndex()
        {
            var mockRepo = new Mock<IStoreBL>();
            mockRepo.Setup(x => x.GetCustomers())
                .Returns(new List<Customer>()
                {
                    new Customer
                    {
                        Id = 1,
                        CustomerName = "Joe",
                        CustomerEmail = "joeschmoe@fake.email"
                    },
                    new Customer
                    {
                        Id = 2,
                        CustomerName = "Jack",
                        CustomerEmail = "jack@email.com"
                    }
                });
            var logger = new NullLogger<CustomerController>();
            var controller = new CustomerController(mockRepo.Object, new Mapper(), logger);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CustomerIndexVM>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
    }
}