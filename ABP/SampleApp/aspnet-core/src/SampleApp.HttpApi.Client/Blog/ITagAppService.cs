// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Blogging.Tagging;
using Volo.Blogging.Tagging.Dtos;

// ReSharper disable once CheckNamespace
namespace Volo.Blogging;

public interface ITagAppService : IApplicationService
{
    Task<List<TagDto>> GetPopularTagsAsync(Guid blogId, GetPopularTagsInput input);
}
