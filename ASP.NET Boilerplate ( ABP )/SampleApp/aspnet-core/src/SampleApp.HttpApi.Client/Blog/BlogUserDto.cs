// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectExtending;
using Volo.Blogging.Posts;

// ReSharper disable once CheckNamespace
namespace Volo.Blogging.Posts;

public class BlogUserDto : EntityDto<Guid>
{
    public Guid? TenantId { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public Dictionary<string, object> ExtraProperties { get; set; }
}