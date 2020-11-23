using ClevelandBlogs.Data;
using ClevelandBlogs.Models.AddModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClevelandBlogs.Services
{
    public class AddService
    {
        private readonly Guid _userId;

        public AddService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAdd(AddCreate model)
        {
            var entity =
                new Add()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Adds.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AddListItem> GetAdds()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Adds
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AddListItem
                                {
                                    AddId = e.AddId,
                                    Title = e.Title,
                                    Content = e.Content,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }

        }

        public AddDetail GetAddById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Adds
                        .Single(e => e.AddId == id && e.OwnerId == _userId);
                return
                    new AddDetail
                    {
                        AddId = entity.AddId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateAdd(AddEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Adds
                        .Single(e => e.AddId == model.AddId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAdd(int addId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Adds
                        .Single(e => e.AddId == addId && e.OwnerId == _userId);

                ctx.Adds.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
