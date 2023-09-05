import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { VendorService } from '../services/vendor.service';
import { Vendor } from '../vendor';

@Component({
  selector: 'app-delete-vendor',
  templateUrl: './delete-vendor.component.html',
  styleUrls: ['./delete-vendor.component.css']
})
export class DeleteVendorComponent {

  vendorToDeleteId: number = 0; // ID of the vendor to be deleted

  constructor(private vendorService: VendorService, private router: Router) { }

  deleteVendor(): void {
    if (this.vendorToDeleteId > 0) {
      this.vendorService.deleteVendor(this.vendorToDeleteId).subscribe(
        () => {
          console.log('Vendor deleted successfully');
          this.router.navigate(['/vendor-operations/view']); // Navigate back to the View Vendor page
        },
        (error) => {
          console.error('Error deleting vendor:', error);
        }
      );
    }
  }
}
