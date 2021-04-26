using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorksModel;


namespace KaspiBdAdo
{
    class WorkWithEntity
    {
        public static void SelectFromProduction()
        {
            using (AdventureWorks context = new AdventureWorks())
            {
                var res = context.Product.ToList();
                foreach (var phone in res)
                {
                    Console.WriteLine($"{phone.ProductID}, {phone.Name}, {phone.ProductNumber}");
                    
                }
            }
        }
    }
}
