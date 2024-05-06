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
import { NeigborhoodService } from '../../../services/concretes/neighborhood.service';
import { StreetService } from '../../../services/concretes/street.service';
import { CreateAddressRequest } from '../../../models/requests/addresses/create-address-request';
import { AddressListItemDto } from '../../../models/requests/addresses/address-list-item.dto';

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
    // this.loadDistricts();
    // this.loadNeighborhoods();
    // this.loadStreets();
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
      console.log('city içinde');
  }
  loadDistricts() {
    this.districtService
      .getDistrictsByCityId(this.selectedCity)
      .subscribe((data: PageResponse<GetListDistrictResponse>) => {
        this.districts = data.items;
      });
      console.log('district içinde');
  }

  loadNeighborhoods() {
    this.neighborhoodService
      .getNeighborhoodsByDistrictId(this.selectedDistrict)
      .subscribe((data: PageResponse<GetListNeighborhoodResponse>) => {
        this.neighborhoods = data.items;
      });
      console.log('neighborhood içinde');
  }

  loadStreets() {
    this.streetService
      .getStreetsByNeighborhoodId(this.selectedNeighborhood)
      .subscribe((data: PageResponse<GetListStreetResponse>) => {
        this.streets = data.items;
      });
      console.log('street içinde');
  }

  onSubmit() {
    if (this.addressForm.valid) {
      const addressData: CreateAddressRequest<AddressListItemDto> = {
        addressListItemDto: {
          cityId: this.addressForm.value.cityId,
          districtId: this.addressForm.value.districtId,
          neighborhoodId: this.addressForm.value.neighborhoodId,  
        },
        streetId: this.addressForm.value.streetId,
        name: this.addressForm.value.name,
        description: this.addressForm.value.description,
      };

      this.addressService.createAddress(addressData).subscribe(response => {
        console.log('Address created successfully:', response);
        this.addressForm.reset();
      }, error => {
        console.error('Error creating address:', error);
      });
    } else {
      console.error('Form is invalid');
    }
  }
}

  
