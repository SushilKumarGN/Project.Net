using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Currency.Controllers // Replace with your actual namespace
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private static List<Currency> Currencies = new List<Currency>();

        [HttpGet]
        public ActionResult<List<Currency>> Get()
        {
            return Ok(Currencies);
        }

        [HttpGet("{currencyId}")]
        public ActionResult<Currency> Get(int currencyId)
        {
            var currency = Currencies.FirstOrDefault(c => c.CurrencyId == currencyId);
            if (currency == null)
            {
                return NotFound();
            }
            return Ok(currency);
        }

        [HttpPost]
        public ActionResult Post(Currency currency)
        {
            if (Currencies.Any(c => c.CurrencyId == currency.CurrencyId))
            {
                return Conflict("Currency with the same ID already exists.");
            }

            Currencies.Add(currency);
            return CreatedAtAction(nameof(Get), new { currencyId = currency.CurrencyId }, currency);
        }

        [HttpPut("{currencyId}")]
        public ActionResult Put(int currencyId, Currency updatedCurrency)
        {
            var existingCurrency = Currencies.FirstOrDefault(c => c.CurrencyId == currencyId);
            if (existingCurrency == null)
            {
                return NotFound("Currency not found.");
            }

            existingCurrency.CurrencyName = updatedCurrency.CurrencyName;
            existingCurrency.CurrencyCode = updatedCurrency.CurrencyCode;

            return Ok();
        }

        [HttpDelete("{currencyId}")]
        public ActionResult Delete(int currencyId)
        {
            var currency = Currencies.FirstOrDefault(c => c.CurrencyId == currencyId);
            if (currency == null)
            {
                return NotFound();
            }

            Currencies.Remove(currency);
            return NoContent();
        }
    }
}
