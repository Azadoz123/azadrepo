// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectExtending;
using Volo.Blogging.Posts;
using Volo.Blogging.Tagging.Dtos;

// ReSharper disable once CheckNamespace
namespace Volo.Blogging.Posts;

public class PostWithDetailsDto : FullAuditedEntityDto<Guid>
{
    public Guid BlogId { get; set; }

    public string Title { get; set; }

    public string CoverImage { get; set; }

    public string Url { get; set; }

    public string Content { get; set; }

    public string Description { get; set; }

    public int ReadCount { get; set; }

    public int CommentCount { get; set; }

    public BlogUserDto Writer { get; set; }

    public TagDto[] Tags { get; set; }

    public string ConcurrencyStamp { get; set; }
}
