import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ViewVendorComponent } from './view-vendor/view-vendor.component';
import { AddVendorComponent } from './add-vendor/add-vendor.component';
import { TopNavigationComponent } from './top-navigation/top-navigation.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DeleteVendorComponent } from './delete-vendor/delete-vendor.component';
//import { AddVendorModule } from './add-vendor.module'; // Import the AddVendorModule

@NgModule({
  declarations: [
    AppComponent,
    ViewVendorComponent,
    AddVendorComponent,
    TopNavigationComponent,
    DeleteVendorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
