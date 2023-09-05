import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vendor } from '../vendor'; // Import the Vendor interface

@Component({
  selector: 'app-view-vendor',
  templateUrl: './view-vendor.component.html',
  styleUrls: ['./view-vendor.component.css']
})
export class ViewVendorComponent implements OnInit {
  vendors: Vendor[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchVendors();
  }

  fetchVendors(): void {
    this.http.get<Vendor[]>('https://localhost:7159/api/Vendor')
      .subscribe(
        (vendors) => {
          this.vendors = vendors;
        },
        (error) => {
          console.error('Error fetching vendors:', error);
        }
      );
  }
}
