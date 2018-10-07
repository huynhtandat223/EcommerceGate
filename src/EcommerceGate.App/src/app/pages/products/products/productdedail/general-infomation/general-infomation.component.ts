import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-general-infomation',
  templateUrl: './general-infomation.component.html',
  styleUrls: ['./general-infomation.component.css']
})
export class GeneralInfomationComponent implements OnInit {
  @Input('formGroup') formGroup: FormGroup;
  @Output() onFormSubmit = new EventEmitter<any>();

  constructor() { }

  ngOnInit() {
  }

  onSubmit(){
    if(this.formGroup.valid){
      var value = this.formGroup.value;
      this.onFormSubmit.emit(value);
    }
  }
}
