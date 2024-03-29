﻿using Allegory.Module.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Allegory.Module.Customers;

//public class CustomerRepository_Tests : ModuleEntityFrameworkCoreTestBase
//{
//    private readonly ICustomerRepository _customerRepository;

//    public CustomerRepository_Tests()
//    {
//        _customerRepository = GetRequiredService<ICustomerRepository>();
//    }

//    [Fact]
//    public async Task Customer_Should_Be_Greater_Than_0()
//    {
//        var result = await _customerRepository.GetCountAsync();
//        result.ShouldBeGreaterThan(0);
//    }

//    [Fact]
//    public async  Task Get_With_Details()
//    {
//        var result = await _customerRepository.GetPagedListAsync(0, 10, nameof(Customer.Id), includeDetails: true);

//        result.Sum(y=>y.ContactInformations.Count).ShouldBeGreaterThan(0);
//    }
//}

public class CustomerRepository_Tests : CustomerRepository_Tests<ModuleEntityFrameworkCoreTestModule>
{

}