﻿using Allegory.Module.Customers;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Linq;
using Volo.Abp.MultiTenancy;

namespace Allegory.Module;

public class ModuleDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly ICurrentTenant _currentTenant;
    private readonly CustomerManager _customerManager;
    private readonly IRepository<Customer, Guid> _customerRepository;
    private readonly IRepository<CustomerGroup, Guid> _customerGroupRepository;

    public ModuleDataSeedContributor(
        IGuidGenerator guidGenerator, 
        ICurrentTenant currentTenant,
        CustomerManager customerManager,
        IRepository<Customer, Guid> customerRepository,
        IRepository<CustomerGroup, Guid> customerGroupRepository   
        )
    {
        //_guidGenerator = GetRequire
        //_currentTenant = currentTenant;
        //_customerManager = customerManager;
        //_customerRepository = customerRepository;
        //_customerGroupRepository = customerGroupRepository; 
        //_customerGroupRepository = GetRequiredService<IRepository<CustomerGroup, Guid>>();
        //_customerRepository = GetRequiredService<IRepository<Customer, Guid>>();
        //_customerManager = GetRequiredService<CustomerManager>();
        //_asyncExecuter = GetRequiredService<IAsyncQueryableExecuter>();

        _guidGenerator = guidGenerator;
        _currentTenant = currentTenant;
        _customerManager = customerManager;
        _customerRepository = customerRepository;
        _customerGroupRepository = customerGroupRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        /* Instead of returning the Task.CompletedTask, you can insert your test data
         * at this point!
         */

        using (_currentTenant.Change(context?.TenantId))
        {
            //return Task.CompletedTask;
            await CreateCustomerGroups();
            await CreateCustomers();
        }
    }

    async Task CreateCustomerGroups()
    {
        var group1 = await _customerManager.CreateCustomerGroupAsync("A Grubu", "a grubu açıklaması");
        await _customerGroupRepository.InsertAsync(group1);

        var group2 = await _customerManager.CreateCustomerGroupAsync("B Grubu", "b grubu açıklaması");
        await _customerGroupRepository.InsertAsync(group2);

        var group3 = await _customerManager.CreateCustomerGroupAsync("C Grubu", "c grubu açıklaması");
        await _customerGroupRepository.InsertAsync(group3);

        for (int i = 0; i < 10; i++)
        {
            var customer = new Customer(_guidGenerator.Create(), "Müşteri - " + i.ToString(), "Soyad" + i.ToString());
            await _customerManager.SetCustomerGroupAsync(customer, group1);
            customer.AddContactInformation("Cep", ContactInformationType.Phone, "123456789");
            customer.Address = new Address("TR", "Ankara", "Gölbaşı", "Adres1", "Adres2");
            await _customerRepository.InsertAsync(customer, autoSave: true);
        }

    }

    async Task CreateCustomers()
    {
        var customer1 = new Customer(_guidGenerator.Create(), "Ali", "CAN");
        await _customerRepository.InsertAsync(customer1);

        var customer2 = new Customer(_guidGenerator.Create(), "Mehmet", "BERBER");
        await _customerRepository.InsertAsync(customer2);

        var customer3 = new Customer(_guidGenerator.Create(), "Ayşe", "KIRAN");
        await _customerRepository.InsertAsync(customer3);
    }
}
