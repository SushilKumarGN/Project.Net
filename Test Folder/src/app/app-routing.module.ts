import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewVendorComponent } from './view-vendor/view-vendor.component';
import { AddVendorComponent } from './add-vendor/add-vendor.component';
import { DeleteVendorComponent } from './delete-vendor/delete-vendor.component';

const routes: Routes = [
  // Other routes...
  {
    path: 'view-vendor',
    component: ViewVendorComponent
  },
  {
    path: 'add-vendor',
    component: AddVendorComponent
  },
  { path: 'delete', component: DeleteVendorComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
