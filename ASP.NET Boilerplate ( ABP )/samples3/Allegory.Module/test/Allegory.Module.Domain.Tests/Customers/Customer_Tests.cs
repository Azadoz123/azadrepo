﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Guids;
using Xunit;

namespace Allegory.Module.Customers
{
    public class Customer_Tests: ModuleDomainTestBase
    {
        private IGuidGenerator _guidGenerator;

        public Customer_Tests()
        {
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public Customer Create_A_Valid_Customer()
        {
            var customer = new Customer(
                _guidGenerator.Create(),
                "Ahmet Faruk",
                "ULU");

            customer.Address = new Address("TR", "Ankara", "Gölbaşı", "adres 1", "adres 2");

            customer.AddContactInformation("Cep telefonu", ContactInformationType.Phone, "5300123456");
            customer.AddContactInformation("Şahsi mail", ContactInformationType.Email, "ahmetfarukulu@gmail.com");

            return customer;
        }

        [Fact]
        public void Customer_Name_Or_Surname_Cannot_Empty()
        {
            var nameException = Assert.Throws<ArgumentException>(() =>
            {
                var customer = new Customer(_guidGenerator.Create(), "   ", "soy isim");
            });

            var surnameException = Assert.Throws<ArgumentException>(() =>
            {
                var customer = new Customer(_guidGenerator.Create(), "Ahmet", null);
            });

            Assert.Equal(nameof(Customer.Name), nameException.ParamName);
            Assert.Equal(nameof(Customer.Surname), surnameException.ParamName);
        }

        [Fact]
        public void Contact_Information_Name_Must_Unique_Each_Customer()
        {
            var exception = Assert.Throws<UserFriendlyException>(() =>
            {
                var customer = Create_A_Valid_Customer();
                customer.AddContactInformation("Cep telefonu", ContactInformationType.Phone, "5322222");
            });

            Assert.Equal("Cep telefonu isminde iletişim bilgisi kayıtlı", exception.Message);
        }

        [Fact]
        public void Contact_Information_Name_Or_Value_Cannot_Empty()
        {
            var nameException = Assert.Throws<ArgumentException>(() =>
            {
                var customer = Create_A_Valid_Customer();
                customer.AddContactInformation("  ", ContactInformationType.Phone, "522");
            });

            var valueException = Assert.Throws<ArgumentException>(() =>
            {
                var customer = Create_A_Valid_Customer();
                customer.AddContactInformation("Telefon", ContactInformationType.Phone, "");
            });

            Assert.Equal(nameof(ContactInformation.Name), nameException.ParamName);
            Assert.Equal(nameof(ContactInformation.Value), valueException.ParamName);
        }
    }
}
