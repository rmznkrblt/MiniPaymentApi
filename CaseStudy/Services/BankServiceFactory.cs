
using CaseStudy.Services.Interfaces;

namespace CaseStudy.Services
{    

    public class BankServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public BankServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IBank GetBankService(string bankId)
        {
            return bankId switch
            {
                "Akbank" => _serviceProvider.GetService<Akbank>(),
                "Garanti" => _serviceProvider.GetService<Garanti>(),
                "YapiKredi" => _serviceProvider.GetService<YapiKredi>(),
                _ => throw new Exception("Invalid BankId")
            };
        }
    }

}
