import { Component, OnInit } from '@angular/core';
import { GetListCityResponse } from '../../../models/responses/cities/get-list-city-response';
import { GetListDistrictResponse } from '../../../models/responses/districts/get-list-district-response';
import { GetListNeighborhoodResponse } from '../../../models/responses/neighborhoods/get-list-neighborhood-response';
import { GetListStreetResponse } from '../../../models/responses/streets/get-list-street-response';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AddressService } from '../../../services/concretes/address.service';
import { PageResponse } from '../../../../core/models/page/page-response';
import { CityService } from '../../../services/concretes/city.service';
import { DistrictService } from '../../../services/concretes/district.service';
import { NeigborhoodService } from '../../../services/concretes/neigborhood.service';
import { StreetService } from '../../../services/concretes/street.service';
import { CreateAllAddressRequest } from '../../../models/requests/addresses/create-all-address-request';

@Component({
  selector: 'app-add-branch-form',
  standalone: true,
  imports: [FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './add-branch-form.component.html',
  styleUrl: './add-branch-form.component.scss'
})
export class AddBranchFormComponent implements OnInit {

  data: any;
  cities: GetListCityResponse[] = [];
  districts: GetListDistrictResponse[] = [];
  neighborhoods: GetListNeighborhoodResponse[] = [];
  streets: GetListStreetResponse[] = [];


  selectedCity: string = '';
  selectedDistrict: string = '';
  selectedNeighborhood: string = '';
  selectedStreet: string = '';

  
  name: string = '';
  description: string = '';
  addressForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private addressService: AddressService,
    private cityService: CityService,
    private districtService: DistrictService,
    private neighborhoodService: NeigborhoodService,
    private streetService: StreetService
  ) {}

  ngOnInit(): void {
    this.createForm();
    this.loadCities();
    this.loadDistricts();
    this.loadNeighborhoods();
    this.loadStreets();
  }

  createForm() {
    this.addressForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      cityId: ['', Validators.required],
      districtId: ['', Validators.required],
      neighborhoodId: ['', Validators.required],
      streetId: ['', Validators.required],
    });
  }

  
  loadCities() {
    this.cityService
      .getAllCities()
      .subscribe((data: PageResponse<GetListCityResponse>) => {
        this.cities = data.items;
      });
  }
  loadDistricts() {
    this.districtService
      .getDistrictsByCityId(this.selectedCity)
      .subscribe((data: PageResponse<GetListDistrictResponse>) => {
        this.districts = data.items;
      });
  }

  loadNeighborhoods() {
    this.neighborhoodService
      .getNeighborhoodsByDistrictId(this.selectedDistrict)
      .subscribe((data: PageResponse<GetListNeighborhoodResponse>) => {
        this.neighborhoods = data.items;
      });
  }

  loadStreets() {
    this.streetService
      .getStreetsByNeighborhoodId(this.selectedNeighborhood)
      .subscribe((data: PageResponse<GetListStreetResponse>) => {
        this.streets = data.items;
      });
  }

  onSubmit() {
    if (this.addressForm.valid) {
      const address = this.addressForm.value;
      console.log('Address saved:', address);
    } else {
      console.error('Form is invalid');
    }
  }
  address() {
    if (this.addressForm.valid) {
      const address = this.addressForm.value;
      console.log('Address saved:', address);

      const addressFormModel: CreateAllAddressRequest = {
        name: this.addressForm.value.name,
        description: this.addressForm.value.description,
        cityId: this.addressForm.value.cityId,
        districtId: this.addressForm.value.districtId,
        neighborhoodId: this.addressForm.value.neighborhoodId,
        streetId: this.addressForm.value.streetId,
      };
    } else {
      console.error('Form is invalid');
    }
  }

}
