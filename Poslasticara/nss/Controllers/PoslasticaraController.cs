using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nss.Models;

namespace nss.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoslasticaraController : ControllerBase
    {
       
       public PoslasticaraContext Context {get;set;}
        
        public PoslasticaraController(PoslasticaraContext context)
        {
           Context=context;
        }
        [Route("PreuzmiPoslasticare")]
        [HttpGet]
        public async Task<List<Poslasticara>> PreuzmiPoslasticare()
            {
               return await Context.Poslasticare.Include(p=>p.Stolovii).ThenInclude(q=>q.Narudzbinaa).ToListAsync();//
               // return await Context.Poslasticare.Include(p=>p.Stolovii).ToListAsync();
            }
        [Route("UpisiPoslasticaru")]
        [HttpPost]
        public async Task UpisiPoslasticaru([FromBody] Poslasticara poslasticara)
        {
            Context.Poslasticare.Add(poslasticara);
            await Context.SaveChangesAsync();
        }
        [Route("IzmeniPoslasticaru")]
        [HttpPut]
        public async Task IzmeniPoslasticaru([FromBody] Poslasticara poslasticara)
        {
            Context.Update<Poslasticara>(poslasticara);
             await Context.SaveChangesAsync();
        }
        [Route("IzbrisiPoslasticaru/{id}")]
        [HttpDelete]
        public async Task IzbrisiPoslasticaru(int id)
        {
            var poslasticara=await Context.Poslasticare.FindAsync(id);
            Context.Remove(poslasticara);
            await Context.SaveChangesAsync();
        }
        /////////////////////////////////////////////
        [Route("PreuzmiStolove")]
        [HttpGet]
        public async Task<List<Stolovi>> PreuzmiStolove()
            {
                return await Context.Stolovii.Include(p=>p.Poslasticara).ToListAsync();
            }


        [Route("UpisStolova/{idPoslasticare}")]
        [HttpPost]
        public async Task<IActionResult> UpisiSto(int idPoslasticare,[FromBody] Stolovi sto)
        {
            var poslasticara=await Context.Poslasticare.FindAsync(idPoslasticare);
            sto.Poslasticara=poslasticara; 
            Context.Stolovii.Add(sto);
            await Context.SaveChangesAsync();
            return Ok(sto.ID);
        }

        [Route("IzmeniSto")]
        [HttpPut]
        public async Task IzmeniSto([FromBody] Stolovi stoo)
        {
            Context.Update<Stolovi>(stoo);
             await Context.SaveChangesAsync();
        }

        [Route("IzbrisiSto/{id}")]
        [HttpDelete]
        public async Task IzbrisiSto(int id)
        {
            
            var stoo=await Context.Stolovii.FindAsync(id);
           var listaNarudzbina = (from n in Context.Narudzbine  //u narudzbinama, gde se sto narudzbine poklapa sa onim koji brisemo, selektuj te narudzbine
                                    where n.Stolove == stoo    
                                    select n);
            foreach(Narudzbina n in listaNarudzbina)
                Context.Remove(n);

            
            Context.Remove(stoo);
            await Context.SaveChangesAsync();
          /*  var stoo=Context.Stolovii.Where(p=>p.ID==id).Include(p=>p.Poslasticara).FirstOrDefault();

          
            if(stoo!=null)
            {
                var pos=stoo.Poslasticara;
                Context.Remove(pic);
                await Context.SaveChangesAsync();
                // return Ok();
            }   
            else
            {
                return StatusCode(406);
            }*/
        
        }
     

       /* [Route("UpisNarudzbine/{idStola}")]
        [HttpPost]
        public async Task UpisNarudzbine(int idStola,[FromBody] Narudzbina nar)
        {
            var sto=await Context.Stolovii.FindAsync(idStola);
            nar.Sto = sto; 
            Context.Narudzbine.Add(nar);
            await Context.SaveChangesAsync();
        }*/
        [Route("UpisNarudzbine/{idStola}")]
        [HttpPost]
        public async Task<IActionResult> UpisNarudzbine(int idStola,[FromBody] Narudzbina nar)
        {
            //var narudzbina=await Context.Poslasticare.FindAsync(idStola);
            var dobijenisto= Context.Stolovii.Where(p=>p.ID==idStola).ToList().Last();//context.stolovi
            if(dobijenisto==null)
                return StatusCode(501);

            nar.Stolove = dobijenisto; 
            
            //nar.Stolove=dobijenisto;
            Context.Narudzbine.Add(nar);
            await Context.SaveChangesAsync();
            return Ok(200);
        }
    }
}
