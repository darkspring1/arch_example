using Domain.Persistent;
using Domain.Persistent.EF;
using StructureMap;

namespace API.Ioc
{
    public class ApiRegistry : Registry
    {
        const string connectionString = "Host=localhost;Port=5432;Database=SocialMass;Username=postgres;Password=postgres";
        public ApiRegistry()
        {
      
            For<IEntityFrameworkDataContext>()
                .Use<EFDataContext>()
                .Ctor<string>("connectionString").Is(connectionString);


            //For<IUnitOfWork>().Use<EfUnitOfWork>();
            For<IUnitOfWork>().Use<FakeUnitOfWork>();
        }
    }
}
