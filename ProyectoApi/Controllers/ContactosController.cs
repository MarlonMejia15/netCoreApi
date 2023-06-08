using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoApi.Data;
using ProyectoApi.Models;
using System.Diagnostics;

namespace ProyectoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactosController : Controller
    {
        private readonly ContactoAPIDbContext dbContext;

        public ContactosController(ContactoAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactos()
        {
           
           return Ok(await dbContext.Contactos.ToListAsync());
            
        }

        [HttpPost]
        public async Task<IActionResult> AgregarContacto(AgregarContacto contacto)
        {
            var nuevoContacto = new Contacto()
            {
                Id = Guid.NewGuid(),
                Direccion = contacto.Direccion,
                Correo = contacto.Correo,
                NombreCompleto = contacto.NombreCompleto,
                Telefono = contacto.Telefono
            };
            
            await dbContext.Contactos.AddAsync(nuevoContacto);
            await dbContext.SaveChangesAsync();
            return Ok(nuevoContacto);

        }


    }
}
