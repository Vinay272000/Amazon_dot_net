using AmazonClone.Models;
using AmazonClone.ViewModels;
using AutoMapper;

namespace AmazonClone.AutoMappers
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile() {
            CreateMap<CategoryVM, Category>()
            .ForMember(category => category.CategoryId, opt => opt.MapFrom(categoryVm => categoryVm.CategoryId))
            .ForMember(category => category.CategoryName, opt => opt.MapFrom(categoryVm => categoryVm.CategoryName));
        }
    }
}
