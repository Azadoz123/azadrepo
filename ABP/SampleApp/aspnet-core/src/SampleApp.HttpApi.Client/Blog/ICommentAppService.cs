// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Blogging.Comments;
using Volo.Blogging.Comments.Dtos;

// ReSharper disable once CheckNamespace
namespace Volo.Blogging;

public interface ICommentAppService : IApplicationService
{
    Task<List<CommentWithRepliesDto>> GetHierarchicalListOfPostAsync(Guid postId);

    Task<CommentWithDetailsDto> CreateAsync(CreateCommentDto input);

    Task<CommentWithDetailsDto> UpdateAsync(Guid id, UpdateCommentDto input);

    Task DeleteAsync(Guid id);
}
