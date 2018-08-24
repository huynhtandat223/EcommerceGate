import { NgModule }              from '@angular/core';
import { RouterModule, Routes }  from '@angular/router';

const appRoutes: Routes = [
    {
      path: 'products',
      loadChildren: './products/products.module#ProductsModule'
    },
    {
      path: 'systems',
      loadChildren: './systems/systems.module#SystemsModule'
    },
    {
      path: '',
      redirectTo: '',
      pathMatch: 'full'
    }
  ];
 
@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: false } // <-- debugging purposes only
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule {}