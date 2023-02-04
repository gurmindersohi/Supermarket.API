﻿namespace Supermarket.Services.Automapper
{
	using AutoMapper;
	using Supermarket.DataTransferModels.Categories;
	using Supermarket.DataTransferModels.Response;
	using Supermarket.Domain.Entities;

	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, ReadDto>();

            CreateMap<Category, SearchDto>();

            CreateMap<PaginatedResult<Category>, PaginatedResult<SearchDto>>();

            CreateMap<InsertDto, Category>(MemberList.Source);

            CreateMap<UpdateDto, Category>(MemberList.Source);
        }
	}
}

