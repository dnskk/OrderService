using System;
using System.Collections.Generic;
using System.Text;
using OrderService.Application.Repositories;
using OrderService.Database;
using OrderService.Models;
using Xunit;

namespace OrderService.Tests
{
    public class PostamatPerositoryTest
    {
        [Fact]
        public void GetPostamatTest()
        {
            var repository = GetPostamatRepository();

            var postamat = repository.Get(1);

            Assert.NotNull(postamat);
        }

        [Fact]
        public void TryAddPostamatTest()
        {
            var repository = GetPostamatRepository();

            var postamat = new Postamat
            {
                Address = "Lenina 10",
                IsWorking = true
            };

            Assert.Throws<Exception>(() => repository.Add(postamat));
        }

        [Fact]
        public void TryUpdatePostamatTest()
        {
            var repository = GetPostamatRepository();

            var postamat = repository.Get(1);
            postamat.Address = "Lenina 10";

            Assert.Throws<Exception>(() => repository.Update(postamat));
        }

        [Fact]
        public void TryRemovePostamatTest()
        {
            var repository = GetPostamatRepository();

            var postamat = repository.Get(1);

            Assert.Throws<Exception>(() => repository.Remove(postamat.Id));
        }

        private PostamatRepository GetPostamatRepository()
        {
            return new PostamatRepository(PostamatDatabase.Instance);
        }
    }
}
