import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { getAppProviders } from './shared/providers/app-providers';
import { AddressBaseService } from './features/services/abstracts/address-base.service';
import { AddressService } from './features/services/concretes/address.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MaterialBaseService } from './features/services/abstracts/material-base.service';
import { MaterialService } from './features/services/concretes/material.service';
import { MaterialCopyBaseService } from './features/services/abstracts/material-copy-base.service';
import { MaterialCopyService } from './features/services/concretes/material-copy.service';
import { provideToastr } from 'ngx-toastr';
import { CityBaseService } from './features/services/abstracts/city-base.service';
import { CityService } from './features/services/concretes/city.service';
import { DistrictBaseService } from './features/services/abstracts/district-base.service';
import { DistrictService } from './features/services/concretes/district.service';
import { NeigborhoodService } from './features/services/concretes/neighborhood.service';
import { NeighborhoodBaseService } from './features/services/abstracts/neighborhood-base.service';
import { StreetBaseService } from './features/services/abstracts/street-base.service';
import { StreetService } from './features/services/concretes/street.service';

export const appConfig: ApplicationConfig = {
  providers: [getAppProviders(),
          provideRouter(routes),
          provideToastr(),
          HttpClientModule,
          HttpClient,
            {
              provide:AddressBaseService,
              useClass:AddressService,
            },
            {
              provide:MaterialBaseService,
              useClass: MaterialService,
            },
            {
              provide:MaterialCopyBaseService,
              useClass:MaterialCopyService,
            },
            {
              provide:CityBaseService,
              useClass:CityService,
            },
            {
              provide:DistrictBaseService,
              useClass:DistrictService,
            },
            {
              provide:NeighborhoodBaseService,
              useClass:NeigborhoodService,
            },
            {
              provide:StreetBaseService,
              useClass:StreetService,
            },
        

         ],
};

