import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {CommonService} from 'src/app/shared/services/common.service';
import {CreateAndUpdateModalComponent} from '../../inquiry/create-and-update-modal/create-and-update-modal.component';

@Component({
  selector: 'app-property-form',
  templateUrl: './property-form.component.html'
})
export class PropertyFormComponent implements OnInit {

  form!: FormGroup;
  mode = 'Create';
  isSubmitted = false;

  selectedPropertyTypeId!: string;
  selectedPropertyStatusId!: string;
  propertyStatusHolder: any[] = [];
  propertyTypeHolder: any[] = [];

  selectedCityId!: string;
  cityDropdownHolder: any[] = [];

  propertyOwnerHolder: any[] = [];
  propertyBuyerHolder: any[] = [];
  selectedPropertyOwnerId!: number;
  selectedPropertyBuyerId!: number;

  constructor(
    public dialogRef: MatDialogRef<CreateAndUpdateModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private commonService: CommonService
  ) {
  }

  ngOnInit(): void {
    this.getPropertyStatus();
    this.getPropertyType();
    this.getCityDropdown();
    this.getBuyerList();
    this.getOwenerList();
    this.form = this.fb.group({
      id: [null],
      address1: ['', [Validators.required]],
      address2: [''],
      pincode: ['', [Validators.required]],
    });

    if (this.data) {
      console.log('Edit Data : ', this.data);
      this.commonService.getRequestWithId(`Property/get`, this.data.id).subscribe((result) => {
        console.log('Edit Data API : ', result);
        this.selectedCityId = result.cityId;
        this.selectedPropertyBuyerId = result.propertyBuyerId;
        this.selectedPropertyOwnerId = result.propertyOwnerId;
        this.selectedPropertyStatusId = result.propertyStatusId;
        this.selectedPropertyTypeId = result.propertyTypeId;
        this.form.patchValue({
          id: this.data.id,
          address1: result.address1,
          address2: result.address2,
          pincode: result.pincode,
        });
      });
      this.mode = 'Update';
      // this.selectedPropertyOwnerId = this.data.propertyOwnerId;
      // this.selectedPropertyBuyerId = this.data.propertyBuyerId;
      // this.selectedPropertyTypeId = this.data.propertyTypeId;
      // this.selectedPropertyStatusId = this.data.propertyStatusId;
      // this.selectedCityId = this.data.cityId;
      // this.form.patchValue({
      //   id: this.data.id,
      //   address1: this.data.address1,
      //   address2: this.data.address2,
      //   pincode: this.data.pincode,
      // });

      console.log('patchValue : ', this.form.value);

    }
  }

  getPropertyStatus() {
    this.commonService.getRequest('Property/getPropertyStatus').subscribe((result) => {
      this.propertyStatusHolder = result;
      console.log('PropertyStatusHolder : ', this.propertyStatusHolder);
    })
  }

  getPropertyType() {
    this.commonService.getRequest('Property/getPropertyType').subscribe((result) => {
      this.propertyTypeHolder = result;
      console.log('PropertyTypeHolder : ', this.propertyTypeHolder);
    })
  }

  getCityDropdown() {
    this.commonService.getRequest('StateCity/getCityDropdown').subscribe((result) => {
      this.cityDropdownHolder = result;
      console.log('City Holder : ', this.cityDropdownHolder);
    })
  }

  getBuyerList() {
    this.commonService.getRequest('UserMaster/getBuyerList').subscribe((result) => {
      this.propertyBuyerHolder = result;
    })
  }

  getOwenerList() {
    this.commonService.getRequest('UserMaster/getSellerList').subscribe((result) => {
      this.propertyOwnerHolder = result;
    })
  }

  get f() {
    return this.form.controls;
  }

  onSubmit(): void {
    console.log('Form Data : ', this.form.valid);
    this.isSubmitted = true;
    if (this.form.invalid) {
      return;
    }
    let formData = {
      ...this.form.value,
      propertyOwnerId: this.selectedPropertyOwnerId,
      propertyBuyerId: this.selectedPropertyBuyerId,
      propertyTypeId: this.selectedPropertyTypeId,
      propertyStatusId: this.selectedPropertyStatusId,
      cityId: this.selectedCityId,
    };
    console.log('Form Data : ', formData);
    this.commonService.postRequest('Property/createOrUpdate', formData).subscribe((resp) => {
      console.log('Save Resp', resp);
      this.dialogRef.close(true);
    })

  }

}
