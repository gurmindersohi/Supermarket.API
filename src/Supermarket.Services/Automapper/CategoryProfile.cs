namespace Supermarket.Services.Automapper
{
	using AutoMapper;
	using Supermarket.DataTransferModels.Categories;
	using Supermarket.Domain.Entities;

	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, ReadDto>();

            CreateMap<InsertDto, Category>(MemberList.Source);

            CreateMap<UpdateDto, Category>(MemberList.Source);
        }
	}
}

