using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vendor.Controllers // Replace with your actual namespace
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    public class VendorController : ControllerBase
    {
        private static List<VendorItem> Vendors = new List<VendorItem>();

        [HttpGet]
        public ActionResult<List<VendorItem>> Get()
        {
            return Ok(Vendors);
        }

        [HttpGet("{vendorId}")]
        public ActionResult<VendorItem> Get(int vendorId)
        {
            var vendor = Vendors.FirstOrDefault(v => v.VendorID == vendorId);
            if (vendor == null)
            {
                return NotFound();
            }
            return Ok(vendor);
        }

        [HttpPost]
        public ActionResult Post(VendorItem vendor)
        {
            if (Vendors.Any(v => v.VendorID == vendor.VendorID))
            {
                return Conflict("Vendor with the same ID already exists.");
            }

            Vendors.Add(vendor);
            return CreatedAtAction(nameof(Get), new { vendorId = vendor.VendorID }, vendor);
        }

        [HttpPut("{vendorId}")]
        public ActionResult Put(int vendorId, VendorItem updatedVendor)
        {
            var existingVendor = Vendors.FirstOrDefault(v => v.VendorID == vendorId);
            if (existingVendor == null)
            {
                return NotFound("Vendor not found.");
            }

            existingVendor.VendorLongName = updatedVendor.VendorLongName; 
            existingVendor.VendorCode = updatedVendor.VendorCode;
            existingVendor.VendorPhoneNumber = updatedVendor.VendorPhoneNumber;
            existingVendor.VendorEmail = updatedVendor.VendorEmail;
            existingVendor.IsActive = updatedVendor.IsActive;

            return Ok();
        }

        [HttpDelete("{vendorId}")]
        public ActionResult Delete(int vendorId)
        {
            var vendor = Vendors.FirstOrDefault(v => v.VendorID == vendorId);
            if (vendor == null)
            {
                return NotFound();
            }

            Vendors.Remove(vendor);
            return NoContent();
        }
    }
}
