// import { Component } from '@angular/core';
// import { Router } from '@angular/router';
// import { VendorService } from '../services/vendor.service';
// import { Vendor } from '../vendor';

// @Component({
//   selector: 'app-add-vendor',
//   templateUrl: './add-vendor.component.html',
//   styleUrls: ['./add-vendor.component.css']
// })
// export class AddVendorComponent {

//   newVendor: Vendor = {
//     vendorID: 0,
//     vendorLongName: '',
//     vendorCode: '',
//     vendorPhoneNumber: '',
//     vendorEmail: '',
//     vendorCreatedOn: '',
//     isActive: false
//   };

//   constructor(private vendorService: VendorService, private router: Router) { }

//   submitForm(): void {
//     console.log('Entered Vendor Data:', this.newVendor);
//     // Call the VendorService to add the vendor
//     this.vendorService.addVendor(this.newVendor).subscribe(() => {
//       // Redirect to the view-vendor page to display the added vendor
//       this.router.navigate(['/vendor-operations/view']);
//     });
//   }
// }
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Vendor } from '../vendor';

@Component({
  selector: 'app-add-vendor',
  templateUrl: './add-vendor.component.html',
  styleUrls: ['./add-vendor.component.css']
})
export class AddVendorComponent implements OnInit {
  newVendor: Vendor = {
    vendorID: 0,
    vendorLongName: '',
    vendorCode: '',
    vendorPhoneNumber: '',
    vendorEmail: '',
    vendorCreatedOn: '',
    isActive: false
  };

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit(): void {}

  addVendor(): void {
    // Send POST request to add the new vendor
    this.http.post('https://localhost:7159/api/Vendor', this.newVendor)
      .subscribe(
        () => {
          console.log('Vendor added successfully');
          // Redirect to the view-vendor page
          this.router.navigate(['/vendor-operations/view']);
        },
        (error) => {
          console.error('Error adding vendor:', error);
        }
      );
  }
}
