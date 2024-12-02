using Microsoft.AspNetCore.Builder;
using static System.Reflection.Metadata.BlobBuilder;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using ProyectoAwosCarrilloShop.Data.Models;

namespace ProyectoAwosCarrilloShop.Data
{
    public class Initialer
    {
        /*
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBcontext>();

                if (!context.Carritos.Any())
                {
                    context.Carritos.AddRange(new Carrito()
                    {
                        
                    },
                      new Books()
                      {
                          Titulo = "2nd Book Title",
                          Descripccion = "2nd Book Description",
                          IsRead = true,
                          Genero = "Biography",
                          CoverUrl = "https...",
                          DateAdded = DateTime.Now,

                      });
                    context.SaveChanges();
                }
            }
        }*/
    }
}
