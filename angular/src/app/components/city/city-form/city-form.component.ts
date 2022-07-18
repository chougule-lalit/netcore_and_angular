import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CommonService } from 'src/app/shared/services/common.service';
import { CreateAndUpdateModalComponent } from '../../inquiry/create-and-update-modal/create-and-update-modal.component';

@Component({
  selector: 'app-city-form',
  templateUrl: './city-form.component.html'
})
export class CityFormComponent implements OnInit {
  form!: FormGroup;
  mode = 'Create';
  isSubmitted = false;
  selectedStateId!: string;
  states: any[] = [];
  constructor(
    public dialogRef: MatDialogRef<CreateAndUpdateModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private commonService: CommonService
  ) {
    this.getStateDropdown();
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      id: [null],
      name: ['', [Validators.required]],
      stateId: ['']
    });
    if (this.data) {
      console.log('Edit Data : ', this.data);
      this.mode = 'Update';
      this.selectedStateId = this.data.stateId;
      this.form.patchValue({
        id: this.data.id,
        name: this.data.name,
        stateId: this.data.stateId
      })
    }
  }

  get f() {
    return this.form.controls;
  }

  getStateDropdown() {
    this.commonService.getRequest('StateCity/getStateDropdown').subscribe((result) => {
      this.states = result;
      console.log('States : ', this.states);

    })
  }

  onSubmit(): void {
    this.form.patchValue({
      stateId: this.selectedStateId
    })
    console.log('Form Data : ', this.form.value);
    this.isSubmitted = true;
    if (this.form.invalid) {
      return;
    }
    this.commonService.postRequest('StateCity/createOrUpdateCity', this.form.value).subscribe((resp) => {
      console.log('Save Resp', resp);
      this.dialogRef.close(true);
    })
  }
}
