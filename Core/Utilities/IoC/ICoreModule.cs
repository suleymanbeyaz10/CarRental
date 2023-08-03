using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //Her yerde kullanılabilecek bağımlılıklarımızın çözümlemelerini yapmak için kullanımına ihtiyaç duyduk 
        void Load(IServiceCollection serviceCollection);
    }
}
