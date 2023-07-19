// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectExtending;
using Volo.Blogging.Comments.Dtos;
using Volo.Blogging.Posts;

// ReSharper disable once CheckNamespace
namespace Volo.Blogging.Comments.Dtos;

public class CommentWithDetailsDto : FullAuditedEntityDto<Guid>
{
    public Guid? RepliedCommentId { get; set; }

    public string Text { get; set; }

    public BlogUserDto Writer { get; set; }

    public string ConcurrencyStamp { get; set; }
}