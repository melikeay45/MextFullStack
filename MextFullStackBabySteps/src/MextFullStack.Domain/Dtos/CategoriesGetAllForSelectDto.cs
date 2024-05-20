using MextFullStack.Domain.Entities;

namespace MextFullStack.Domain.Dtos
{
    public sealed class CategoriesGetAllForSelectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static CategoriesGetAllForSelectDto FromCategory(Category category)
        {
            return new CategoriesGetAllForSelectDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
