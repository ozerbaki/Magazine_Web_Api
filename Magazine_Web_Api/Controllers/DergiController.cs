using Magazine_Web_Api.Context;
using Magazine_Web_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Magazine_Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DergiController : ControllerBase
    {
        private readonly DergiContext _dbContext;

        public DergiController(DergiContext dbContext)
        {
            _dbContext = dbContext;
        }

        //DergiContext _dbContext = new DergiContext();


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _dbContext.Dergi.ToListAsync();
            //RedirectToAction("Hata");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _dbContext.Dergi.ToListAsync();

            var dergi = result.FirstOrDefault(x => x.DergiId == id);
            if (dergi is null)
            {
                return NotFound("Dergi Bulunamadı");
            }
            else
            {
                return Ok(dergi);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Dergi dergi)
        {
            var result = await _dbContext.Dergi.ToListAsync();
            dergi.DergiId = 0;

            if (((int)dergi.YayinPeriyodu <= 0 || (int)dergi.YayinPeriyodu > 3) || ((int)dergi.YayinTuru <= 0 || (int)dergi.YayinTuru > 4))
            {
                return NotFound("Yayın türü veya Yayın periyodu geçersiz.");
            }
            else
            {
                _dbContext.Dergi.Add(dergi);
                _dbContext.SaveChanges();
                return Ok(dergi);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Dergi dergi)
        {
            var result = await _dbContext.Dergi.ToListAsync();

            var editdergi = result.FirstOrDefault(x => x.DergiId == dergi.DergiId);
            if (editdergi is null)
            {
                return NotFound("Geçersiz ID");
            }
            else
            {
                if (((int)dergi.YayinPeriyodu <= 0 || (int)dergi.YayinPeriyodu > 3) || ((int)dergi.YayinTuru <= 0 || (int)dergi.YayinTuru > 4))
                {
                    return NotFound("Yayın türü veya Yayın periyodu geçersiz.");
                }
                else
                {
                    editdergi.DergiAdi = dergi.DergiAdi;
                    editdergi.İmtiyazSahibi = dergi.İmtiyazSahibi;
                    editdergi.YayinPeriyodu = dergi.YayinPeriyodu;
                    editdergi.YayinTuru = dergi.YayinTuru;

                    _dbContext.SaveChanges();
                }
            }
            return Ok(dergi);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _dbContext.Dergi.ToListAsync();
            var deletedergi = result.FirstOrDefault(x => x.DergiId == Id);
            if (deletedergi is null)
            {
                return NotFound("Geçersiz ID");
            }
            else
            {
                _dbContext.Dergi.Remove(deletedergi);
                await _dbContext.SaveChangesAsync();

                return Ok($"{Id} numaralı dergi silindi.");
            }
            
        }

    }
}
