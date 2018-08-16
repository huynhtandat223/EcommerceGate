import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SystemsRoutingModule } from './systems-routing.module';
import { AccountsComponent } from './accounts/accounts.component';

@NgModule({
  imports: [
    CommonModule,
    SystemsRoutingModule
  ],
  declarations: [AccountsComponent]
})
export class SystemsModule { }
