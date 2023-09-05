import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Vendor } from '../vendor';

@Injectable({
  providedIn: 'root'
})
export class VendorService {

  private apiUrl = 'https://localhost:7159'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  addVendor(vendor: Vendor): Observable<any> {
    return this.http.post(`https://localhost:7159/api/Vendor`, vendor);
  }

  deleteVendor(vendorId: number): Observable<void> {
    const url = `https://localhost:7159/api/Vendor/${vendorId}`;
    return this.http.delete<void>(url);
  }
  
  // Other methods like fetching vendors, updating vendors, etc.
}
