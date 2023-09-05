using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoice.Controllers // Replace with your actual namespace
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private static List<Invoice> Invoices = new List<Invoice>();

        [HttpGet]
        public ActionResult<List<Invoice>> Get()
        {
            return Ok(Invoices);
        }

        [HttpGet("{invoiceId}")]
        public ActionResult<Invoice> Get(int invoiceId)
        {
            var invoice = Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        public ActionResult Post(Invoice invoice)
        {
            if (Invoices.Any(i => i.InvoiceId == invoice.InvoiceId))
            {
                return Conflict("Invoice with the same ID already exists.");
            }

            Invoices.Add(invoice);
            return CreatedAtAction(nameof(Get), new { invoiceId = invoice.InvoiceId }, invoice);
        }

        [HttpPut("{invoiceId}")]
        public ActionResult Put(int invoiceId, Invoice updatedInvoice)
        {
            var existingInvoice = Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
            if (existingInvoice == null)
            {
                return NotFound("Invoice not found.");
            }

            existingInvoice.InvoiceNumber = updatedInvoice.InvoiceNumber;
            existingInvoice.InvoiceCurrencyId = updatedInvoice.InvoiceCurrencyId;
            existingInvoice.VendorId = updatedInvoice.VendorId;
            existingInvoice.InvoiceAmount = updatedInvoice.InvoiceAmount;
            existingInvoice.InvoiceReceivedDate = updatedInvoice.InvoiceReceivedDate;
            existingInvoice.InvoiceDueDate = updatedInvoice.InvoiceDueDate;
            existingInvoice.IsActive = updatedInvoice.IsActive;

            return Ok();
        }

        [HttpDelete("{invoiceId}")]
        public ActionResult Delete(int invoiceId)
        {
            var invoice = Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }

            Invoices.Remove(invoice);
            return NoContent();
        }
    }
}
