using System.Collections.Generic;
using System.Collections.Immutable;
using OrderService.Models;

namespace OrderService.Database
{
    public class PostamatDatabase
    {
        private static PostamatDatabase _instance;

        public ImmutableList<Postamat> Postamats { get; }

        public static PostamatDatabase Instance
        {
            get
            {
                return _instance ??= new PostamatDatabase();
            }
        }

        private PostamatDatabase()
        {
            Postamats = ImmutableList.CreateRange(GeneratePostamats());
        }

        private List<Postamat> GeneratePostamats()
        {
            var postamats = new List<Postamat>();

            for (var i = 0; i < 10; i++)
            {
                var postamat = new Postamat
                {
                    Id = i,
                    Address = $"Baker street 2{i}",
                    IsWorking = i % 3 != 0
                };

                postamats.Add(postamat);
            }

            return postamats;
        }
    }
}
