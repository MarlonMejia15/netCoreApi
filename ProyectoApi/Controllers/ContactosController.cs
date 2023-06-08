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

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContacto([FromRoute] Guid id)
        {

            var contacto = await dbContext.Contactos.FindAsync(id);
            if (contacto == null) return NotFound();

            return Ok(contacto);


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


        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> ModificarContacto([FromRoute] Guid id, ModificarContacto contacto)
        {
            var contactoModificar =await dbContext.Contactos.FindAsync(id);
            if(contactoModificar == null) return NotFound();

            contactoModificar.NombreCompleto = contacto.NombreCompleto;
            contactoModificar.Correo = contacto.Correo;
            contactoModificar.Direccion = contacto.Direccion;
            contactoModificar.Telefono = contacto.Telefono;

            await dbContext.SaveChangesAsync();

            return Ok(contactoModificar);

        }


        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> EliminarContacto([FromRoute] Guid id)
        {
            var contactoEliminar = await dbContext.Contactos.FindAsync(id);
            if (contactoEliminar == null) return NotFound();

            dbContext.Remove(contactoEliminar);
            await dbContext.SaveChangesAsync();

            return Ok(contactoEliminar);

        }

    }
}
