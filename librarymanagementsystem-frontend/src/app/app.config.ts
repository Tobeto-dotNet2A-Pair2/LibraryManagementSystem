import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { getAppProviders } from './shared/providers/app-providers';
import { AddressBaseService } from './features/services/abstracts/address-base.service';
import { AddressService } from './features/services/concretes/address.service';
import { HttpClient, HttpClientModule, provideHttpClient } from '@angular/common/http';
import { MaterialBaseService } from './features/services/abstracts/material-base.service';
import { MaterialService } from './features/services/concretes/material.service';
import { MaterialCopyBaseService } from './features/services/abstracts/material-copy-base.service';
import { MaterialCopyService } from './features/services/concretes/material-copy.service';
import { provideToastr } from 'ngx-toastr';

export const appConfig: ApplicationConfig = {
  providers: [getAppProviders(),
          provideRouter(routes),
          provideToastr(),
          importProvidersFrom(HttpClientModule),
          provideHttpClient(),
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
            }
         ],
};

