// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using Volo.Abp.ObjectExtending;
using Volo.Blogging.Files;

// ReSharper disable once CheckNamespace
namespace Volo.Blogging.Files;

public class FileUploadInputDto
{
    public IRemoteStreamContent File { get; set; }

    public string Name { get; set; }
}
